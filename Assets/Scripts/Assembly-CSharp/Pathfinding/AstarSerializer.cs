using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Pathfinding
{
	public class AstarSerializer
	{
		public class SMask
		{
			public static int SaveNodes = 1;

			public static int SaveNodeConnections = 2;

			public static int SaveNodeConnectionCosts = 4;

			public static int SaveNodePositions = 8;

			public static int RunLengthEncoding = 16;

			public static string BitName(int i)
			{
				switch (i)
				{
				case 0:
					return "Nodes";
				case 1:
					return "Node Connections";
				case 2:
					return "Node Connection Costs";
				case 3:
					return "Node Positions";
				case 4:
					return "Run Length Encoding";
				default:
					return null;
				}
			}
		}

		public enum SerializerError
		{
			Nothing = 0,
			WrongMagic = 1,
			WrongVersion = 2,
			DoesNotExist = 3
		}

		public struct BitMask
		{
			private int value;

			public BitMask(int v)
			{
				value = v;
			}

			public override bool Equals(object o)
			{
				if (o == null)
				{
					return false;
				}
				return (((BitMask)o).value & value) == value;
			}

			public override int GetHashCode()
			{
				return value;
			}

			public static bool operator ==(BitMask mask, int value)
			{
				return (mask.value & value) == value;
			}

			public static bool operator !=(BitMask mask, int value)
			{
				return (mask.value & value) != value;
			}

			public static BitMask operator |(BitMask mask, int value)
			{
				mask.value |= value;
				return mask;
			}

			public static BitMask operator &(BitMask mask, int value)
			{
				mask.value &= value;
				return mask;
			}

			public static BitMask operator +(BitMask mask, int value)
			{
				mask.value |= value;
				return mask;
			}

			public static BitMask operator -(BitMask mask, int value)
			{
				mask.value &= ~value;
				return mask;
			}

			public static implicit operator BitMask(int v)
			{
				return new BitMask(v);
			}

			public static implicit operator int(BitMask v)
			{
				return v.value;
			}
		}

		public delegate UnityEngine.Object ReadUnityReference_Editor(AstarSerializer serializer, string name, int instanceID, Type type);

		public delegate void WriteUnityReference_Editor(AstarSerializer serializer, UnityEngine.Object ob);

		public delegate void DeSerializationInterrupt(AstarSerializer serializer, bool newer, Guid guid);

		public BinaryWriter writerStream;

		public BinaryReader readerStream;

		public AstarPath active;

		public AstarData astarData;

		public bool replaceOldGraphs = true;

		public BitMask mask = -1 & ~SMask.SaveNodes;

		public static bool IgnoreVersionDifferences;

		public bool onlySaveSettings;

		public bool compress = true;

		public int deserializingGraphIndex;

		public string[] loadedGraphGuids;

		public int[] graphRefGuids;

		public SerializerError error;

		public Dictionary<string, int> anchors;

		public static ReadUnityReference_Editor readUnityReference_Editor;

		public static WriteUnityReference_Editor writeUnityReference_Editor;

		public Dictionary<string, int> serializedVariables = new Dictionary<string, int>();

		public Hashtable serializedData;

		public string sPrefix = string.Empty;

		public byte prefix;

		public int counter;

		public int positionAtCounter = -1;

		public long positionAtError = -1L;

		protected AstarSerializer()
		{
		}

		public AstarSerializer(AstarPath script)
		{
			active = script;
			astarData = script.astarData;
			mask = -1;
			mask -= SMask.SaveNodes;
		}

		public static AstarSerializer GetDeserializer(Version version, AstarPath script)
		{
			if (version == AstarPath.Version)
			{
				return new AstarSerializer(script);
			}
			if (version > AstarPath.Version)
			{
				return new AstarSerializer(script);
			}
			if (version > new Version(3, 0, 1))
			{
				return new AstarSerializer3_04(script);
			}
			return new AstarSerializer3_01(script);
		}

		public void SetUpGraphRefs(NavGraph[] graphs)
		{
			graphRefGuids = new int[loadedGraphGuids.Length];
			for (int i = 0; i < loadedGraphGuids.Length; i++)
			{
				Guid guid = new Guid(loadedGraphGuids[i]);
				graphRefGuids[i] = -1;
				for (int j = 0; j < graphs.Length; j++)
				{
					if (graphs[j].guid == guid)
					{
						graphRefGuids[i] = i;
					}
				}
			}
		}

		public void OpenSerialize()
		{
			onlySaveSettings = true;
			MemoryStream output = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(output);
			writerStream = binaryWriter;
			writerStream.Write(0);
			anchors = new Dictionary<string, int>();
			SerializeSerializationInfo();
			InitializeSerializeNodes();
		}

		public AstarSerializer OpenDeserialize(byte[] data)
		{
			MemoryStream input = new MemoryStream(data);
			readerStream = new BinaryReader(input);
			DeserializeAnchors();
			return DeserializeSerializationInfo();
		}

		public void SerializeSerializationInfo()
		{
			AddAnchor("SerializerSettings");
			BinaryWriter binaryWriter = writerStream;
			binaryWriter.Write(AstarPath.Version.ToString());
			binaryWriter.Write(astarData.graphs.Length);
			for (int i = 0; i < astarData.graphs.Length; i++)
			{
				binaryWriter.Write(astarData.graphs[i].guid.ToString());
			}
			binaryWriter.Write(mask);
		}

		public AstarSerializer DeserializeSerializationInfo()
		{
			if (!MoveToAnchor("SerializerSettings"))
			{
				throw new NullReferenceException("Anchor SerializerSettings was not found in the data");
			}
			BinaryReader binaryReader = readerStream;
			Version version = null;
			try
			{
				version = new Version(binaryReader.ReadString());
			}
			catch (Exception innerException)
			{
				Debug.LogError("Couldn't parse A* version ");
				error = SerializerError.WrongVersion;
				throw new FormatException("Couldn't parse A* version", innerException);
			}
			AstarSerializer astarSerializer = this;
			if (!IgnoreVersionDifferences)
			{
				if (version > AstarPath.Version)
				{
					Debug.LogError(string.Concat("Loading graph saved with a newer version of the A* Pathfinding Project, trying to load, but you might get errors.\nFile version: ", version, " Current A* version: ", AstarPath.Version));
				}
				else if (version != AstarPath.Version)
				{
					Debug.LogWarning(string.Concat("Loading graphs saved with an older version of the A* Pathfinding Project, trying to load.\nFile version: ", version, " Current A* version: ", AstarPath.Version));
					astarSerializer = new AstarSerializer3_01(active);
					astarSerializer.readerStream = readerStream;
					astarSerializer.anchors = anchors;
				}
			}
			int num = binaryReader.ReadInt32();
			astarSerializer.loadedGraphGuids = new string[num];
			for (int i = 0; i < num; i++)
			{
				astarSerializer.loadedGraphGuids[i] = binaryReader.ReadString();
			}
			astarSerializer.mask = binaryReader.ReadInt32();
			return astarSerializer;
		}

		public void SerializeSettings(NavGraph graph, AstarPath active)
		{
			ISerializableGraph serializableGraph = graph as ISerializableGraph;
			if (serializableGraph == null)
			{
				Debug.LogError("The graph specified is not serializable, the graph is of type " + graph.GetType());
			}
			else
			{
				serializableGraph.SerializeSettings(this);
			}
		}

		public void InitializeSerializeNodes()
		{
			if (!(mask == SMask.SaveNodes))
			{
				return;
			}
			AstarData astarData = active.astarData;
			for (int i = 0; i < astarData.graphs.Length; i++)
			{
				NavGraph navGraph = astarData.graphs[i];
				if (navGraph.nodes != null)
				{
					for (int j = 0; j < navGraph.nodes.Length; j++)
					{
						navGraph.nodes[j].h = i;
						navGraph.nodes[j].g = j;
					}
				}
			}
		}

		public void SerializeNodes(NavGraph graph, AstarPath active)
		{
			if (mask == SMask.SaveNodes)
			{
				writerStream.Write(0);
			}
		}

		public void DeserializeNodes(NavGraph graph, NavGraph[] graphs, int graphIndex, AstarPath active)
		{
			if (mask == SMask.SaveNodes)
			{
				readerStream.ReadInt32();
			}
		}

		public void SerializeEditorSettings(NavGraph graph, ISerializableGraphEditor editor, AstarPath active)
		{
			if (editor == null)
			{
				Debug.LogError("The editor specified is Null");
				return;
			}
			positionAtCounter = (int)writerStream.BaseStream.Position;
			writerStream.Write(0);
			counter = 0;
			editor.SerializeSettings(graph, this);
		}

		public void DeSerializeEditorSettings(NavGraph graph, ISerializableGraphEditor editor, AstarPath active)
		{
			if (editor == null)
			{
				Debug.LogError("The editor specified is Null");
			}
			else
			{
				editor.DeSerializeSettings(graph, this);
			}
		}

		public void DeSerializeSettings(NavGraph graph, AstarPath active)
		{
			ISerializableGraph serializableGraph = graph as ISerializableGraph;
			if (serializableGraph == null)
			{
				Debug.LogError("The graph specified is not (de)serializable (how it could be serialized in the first place is a mystery) the graph was of type " + graph.GetType());
				return;
			}
			graph.open = readerStream.ReadBoolean();
			serializableGraph.DeSerializeSettings(this);
		}

		public void SerializeAnchors()
		{
			if (anchors == null)
			{
				Debug.LogError("The anchors dictionary is null");
				return;
			}
			int value = (int)writerStream.BaseStream.Position;
			writerStream.Write(anchors.Count);
			foreach (KeyValuePair<string, int> anchor in anchors)
			{
				writerStream.Write(anchor.Key);
				writerStream.Write(anchor.Value);
			}
			int num = (int)writerStream.BaseStream.Position;
			writerStream.BaseStream.Position = 0L;
			writerStream.Write(value);
			writerStream.BaseStream.Position = num;
		}

		public void DeserializeAnchors()
		{
			readerStream.BaseStream.Position = 0L;
			int num = readerStream.ReadInt32();
			int num2 = (int)readerStream.BaseStream.Position;
			readerStream.BaseStream.Position = num;
			int num3 = readerStream.ReadInt32();
			anchors = new Dictionary<string, int>(num3);
			for (int i = 0; i < num3; i++)
			{
				anchors.Add(readerStream.ReadString(), readerStream.ReadInt32());
			}
			readerStream.BaseStream.Position = num2;
		}

		public void AddVariableAnchor(string name)
		{
			AddAnchor(sPrefix + "#" + name);
		}

		public void AddAnchor(string name)
		{
			anchors.Add(name, (int)writerStream.BaseStream.Position);
		}

		public bool MoveToVariableAnchor(string name)
		{
			return MoveToAnchor(sPrefix + "#" + name);
		}

		public bool MoveToAnchor(string name)
		{
			int value;
			if (anchors.TryGetValue(name, out value))
			{
				readerStream.BaseStream.Position = value;
				return true;
			}
			return false;
		}

		public virtual void SerializeUserConnections(UserConnection[] userConnections)
		{
			BinaryWriter binaryWriter = writerStream;
			AddAnchor("UserConnections");
			if (userConnections != null)
			{
				binaryWriter.Write(userConnections.Length);
				foreach (UserConnection userConnection in userConnections)
				{
					binaryWriter.Write(userConnection.p1.x);
					binaryWriter.Write(userConnection.p1.y);
					binaryWriter.Write(userConnection.p1.z);
					binaryWriter.Write(userConnection.p2.x);
					binaryWriter.Write(userConnection.p2.y);
					binaryWriter.Write(userConnection.p2.z);
					binaryWriter.Write(userConnection.doOverrideCost);
					binaryWriter.Write(userConnection.overrideCost);
					binaryWriter.Write(userConnection.oneWay);
					binaryWriter.Write(userConnection.width);
					binaryWriter.Write((int)userConnection.type);
				}
			}
			else
			{
				binaryWriter.Write(0);
			}
		}

		public virtual UserConnection[] DeserializeUserConnections()
		{
			BinaryReader binaryReader = readerStream;
			if (MoveToAnchor("UserConnections"))
			{
				int num = binaryReader.ReadInt32();
				UserConnection[] array = new UserConnection[num];
				for (int i = 0; i < num; i++)
				{
					UserConnection userConnection = new UserConnection();
					userConnection.p1 = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
					userConnection.p2 = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
					userConnection.doOverrideCost = binaryReader.ReadBoolean();
					userConnection.overrideCost = binaryReader.ReadInt32();
					userConnection.oneWay = binaryReader.ReadBoolean();
					userConnection.width = binaryReader.ReadSingle();
					userConnection.type = (ConnectionType)binaryReader.ReadInt32();
					array[i] = userConnection;
				}
				return array;
			}
			return new UserConnection[0];
		}

		public void WriteError()
		{
			if (positionAtError != -1)
			{
				if (writerStream == null)
				{
					Debug.LogError("You should only call the WriteError function when Serializing, not when DeSerializing");
					return;
				}
				long position = writerStream.BaseStream.Position;
				writerStream.BaseStream.Position = positionAtError;
				writerStream.Write(true);
				writerStream.BaseStream.Position = position;
			}
		}

		public void Close()
		{
			if (readerStream != null)
			{
				readerStream.Close();
			}
			if (writerStream != null)
			{
				if (anchors != null)
				{
					SerializeAnchors();
				}
				writerStream.Close();
			}
		}

		public void AddUnityReferenceValue(string key, UnityEngine.Object value)
		{
			BinaryWriter binaryWriter = writerStream;
			AddVariableAnchor(key);
			if (value == null)
			{
				binaryWriter.Write((byte)0);
				return;
			}
			binaryWriter.Write((byte)1);
			if (value == active.gameObject)
			{
				binaryWriter.Write(-128);
			}
			else if (value == active.transform)
			{
				binaryWriter.Write(-129);
			}
			else
			{
				binaryWriter.Write(value.GetInstanceID());
			}
			binaryWriter.Write(value.name);
			Component component = value as Component;
			GameObject gameObject = value as GameObject;
			if (component == null && gameObject == null)
			{
				binaryWriter.Write(string.Empty);
			}
			else
			{
				if (gameObject == null)
				{
					gameObject = component.gameObject;
				}
				string text = gameObject.name;
				while (gameObject.transform.parent != null)
				{
					gameObject = gameObject.transform.parent.gameObject;
					text = gameObject.name + "/" + text;
				}
				binaryWriter.Write(text);
			}
			if (writeUnityReference_Editor != null)
			{
				binaryWriter.Write(true);
				writeUnityReference_Editor(this, value);
			}
			else
			{
				binaryWriter.Write(false);
			}
		}

		public void AddValue(string key, object value)
		{
			BinaryWriter binaryWriter = writerStream;
			AddVariableAnchor(key);
			if (value == null)
			{
				binaryWriter.Write((byte)0);
				return;
			}
			binaryWriter.Write((byte)1);
			Type type = value.GetType();
			if (type == typeof(int))
			{
				binaryWriter.Write((int)value);
				return;
			}
			if (type == typeof(string))
			{
				string value2 = (string)value;
				binaryWriter.Write(value2);
				return;
			}
			if (type == typeof(float))
			{
				binaryWriter.Write((float)value);
				return;
			}
			if (type == typeof(bool))
			{
				binaryWriter.Write((bool)value);
				return;
			}
			if (type == typeof(Vector3))
			{
				Vector3 vector = (Vector3)value;
				binaryWriter.Write(vector.x);
				binaryWriter.Write(vector.y);
				binaryWriter.Write(vector.z);
				return;
			}
			if (type == typeof(Vector2))
			{
				Vector2 vector2 = (Vector2)value;
				binaryWriter.Write(vector2.x);
				binaryWriter.Write(vector2.y);
				return;
			}
			if (type == typeof(Matrix4x4))
			{
				Matrix4x4 matrix4x = (Matrix4x4)value;
				for (int i = 0; i < 16; i++)
				{
					binaryWriter.Write(matrix4x[i]);
				}
				return;
			}
			if (type == typeof(Bounds))
			{
				Bounds bounds = (Bounds)value;
				binaryWriter.Write(bounds.center.x);
				binaryWriter.Write(bounds.center.y);
				binaryWriter.Write(bounds.center.z);
				binaryWriter.Write(bounds.extents.x);
				binaryWriter.Write(bounds.extents.y);
				binaryWriter.Write(bounds.extents.z);
				return;
			}
			ISerializableObject serializableObject = value as ISerializableObject;
			if (serializableObject != null)
			{
				string text = sPrefix;
				sPrefix = sPrefix + key + ".";
				serializableObject.SerializeSettings(this);
				sPrefix = text;
				return;
			}
			UnityEngine.Object obj = value as UnityEngine.Object;
			if (obj != null)
			{
				Debug.LogWarning("Unity Object References should be added using AddUnityReferenceValue");
				WriteError();
				binaryWriter.BaseStream.Position--;
				binaryWriter.Write((byte)2);
			}
			else
			{
				Debug.LogError("Can't serialize type '" + type.Name + "'");
				WriteError();
				binaryWriter.BaseStream.Position--;
				binaryWriter.Write((byte)2);
			}
		}

		public UnityEngine.Object GetUnityReferenceValue(string key, Type type, UnityEngine.Object defaultValue = null)
		{
			if (!MoveToVariableAnchor(key))
			{
				Debug.Log("Couldn't find key '" + key + "' in the data, returning default");
				return ((!(defaultValue == null)) ? defaultValue : GetDefaultValue(type)) as UnityEngine.Object;
			}
			BinaryReader binaryReader = readerStream;
			switch ((int)binaryReader.ReadByte())
			{
			case 0:
				return ((!(defaultValue == null)) ? defaultValue : GetDefaultValue(type)) as UnityEngine.Object;
			case 2:
				Debug.Log("The variable '" + key + "' was not serialized correctly and can therefore not be deserialized");
				return ((!(defaultValue == null)) ? defaultValue : GetDefaultValue(type)) as UnityEngine.Object;
			default:
			{
				int num = binaryReader.ReadInt32();
				string text = binaryReader.ReadString();
				switch (num)
				{
				case -128:
					return active.gameObject;
				case -129:
					return active.transform;
				default:
				{
					string text2 = binaryReader.ReadString();
					UnityEngine.Object obj = null;
					if (text2 != string.Empty)
					{
						GameObject gameObject = GameObject.Find(text2);
						if (gameObject != null)
						{
							if (type == typeof(GameObject))
							{
								return gameObject;
							}
							obj = gameObject.GetComponent(type);
							if (obj != null && obj.name == text)
							{
								return obj;
							}
						}
					}
					bool flag = binaryReader.ReadBoolean();
					if (readUnityReference_Editor != null && flag)
					{
						UnityEngine.Object obj2 = readUnityReference_Editor(this, text, num, type);
						if (obj2 != null && obj2.name == text)
						{
							return obj2;
						}
						if (obj != null)
						{
							return obj;
						}
						return obj2;
					}
					if (obj != null)
					{
						return obj;
					}
					UnityEngine.Object[] array = Resources.FindObjectsOfTypeAll(type);
					UnityEngine.Object obj3 = null;
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i].GetInstanceID() == num)
						{
							obj3 = array[i];
							break;
						}
					}
					if (obj3 != null)
					{
						return obj3;
					}
					return Resources.Load(text);
				}
				}
			}
			}
		}

		public static string StripPathOfFolder(string path, string relativeFolder)
		{
			int num = path.IndexOf(relativeFolder);
			if (num == -1)
			{
				return string.Empty;
			}
			path = path.Remove(0, num + relativeFolder.Length);
			if (path.StartsWith("/"))
			{
				path = path.Remove(0, 1);
			}
			return path;
		}

		public object GetDefaultValue(Type type)
		{
			if (type.IsValueType)
			{
				return Activator.CreateInstance(type);
			}
			return null;
		}

		public object GetValue(string key, Type type, object defaultValue = null)
		{
			if (!MoveToVariableAnchor(key))
			{
				Debug.Log("Couldn't find key '" + key + "' in the data, returning default (" + ((defaultValue != null) ? defaultValue.ToString() : "null") + ")");
				return (defaultValue != null) ? defaultValue : GetDefaultValue(type);
			}
			BinaryReader binaryReader = readerStream;
			switch ((int)binaryReader.ReadByte())
			{
			case 0:
				return (defaultValue != null) ? defaultValue : GetDefaultValue(type);
			case 2:
				Debug.Log("The variable '" + key + "' was not serialized correctly and can therefore not be deserialized");
				return (defaultValue != null) ? defaultValue : GetDefaultValue(type);
			default:
			{
				object obj = null;
				if (type == typeof(int))
				{
					obj = binaryReader.ReadInt32();
				}
				else if (type == typeof(string))
				{
					obj = binaryReader.ReadString();
				}
				else if (type == typeof(float))
				{
					obj = binaryReader.ReadSingle();
				}
				else if (type == typeof(bool))
				{
					obj = binaryReader.ReadBoolean();
				}
				else if (type == typeof(Vector3))
				{
					obj = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
				}
				else if (type == typeof(Vector2))
				{
					obj = new Vector2(binaryReader.ReadSingle(), binaryReader.ReadSingle());
				}
				else if (type == typeof(Matrix4x4))
				{
					Matrix4x4 matrix4x = default(Matrix4x4);
					for (int i = 0; i < 16; i++)
					{
						matrix4x[i] = binaryReader.ReadSingle();
					}
					obj = matrix4x;
				}
				else if (type == typeof(Bounds))
				{
					obj = new Bounds
					{
						center = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle()),
						extents = new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle())
					};
				}
				else
				{
					if (type.GetConstructor(Type.EmptyTypes) != null)
					{
						object obj2 = Activator.CreateInstance(type);
						ISerializableObject serializableObject = (ISerializableObject)obj2;
						if (serializableObject != null)
						{
							string text = sPrefix;
							sPrefix = sPrefix + key + ".";
							serializableObject.DeSerializeSettings(this);
							obj = serializableObject;
							sPrefix = text;
						}
					}
					if (obj == null)
					{
						Debug.LogError("Can't deSerialize type '" + type.Name + "'");
						obj = ((defaultValue != null) ? defaultValue : GetDefaultValue(type));
					}
				}
				return obj;
			}
			}
		}

		public byte[] Compress(byte[] bytes)
		{
			return bytes;
		}

		public byte[] DeCompress(byte[] bytes)
		{
			return bytes;
		}

		public void Sort(int[] a, byte[] b)
		{
			bool flag = true;
			while (flag)
			{
				flag = false;
				for (int i = 0; i < a.Length - 1; i++)
				{
					if (a[i] > a[i + 1])
					{
						int num = a[i];
						a[i] = a[i + 1];
						a[i + 1] = num;
						byte b2 = b[i];
						b[i] = b[i + 1];
						b[i + 1] = b2;
						flag = true;
					}
				}
			}
		}

		public void SaveToFile(string path, byte[] data)
		{
			FileStream fileStream = File.Create(path);
			fileStream.Write(data, 0, data.Length);
			fileStream.Close();
		}

		public byte[] LoadFromFile(string path)
		{
			if (!File.Exists(path))
			{
				error = SerializerError.DoesNotExist;
				Debug.LogError("File does not exist : " + path);
				return new byte[0];
			}
			FileStream fileStream = File.Open(path, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			return array;
		}

		public static void TestLoadFile(string path)
		{
			FileStream fileStream = File.Open(path, FileMode.Open);
			fileStream.Close();
		}
	}
}
