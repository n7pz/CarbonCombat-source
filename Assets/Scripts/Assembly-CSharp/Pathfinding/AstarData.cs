using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	public class AstarData
	{
		public Type[] graphTypes;

		[NonSerialized]
		public NavGraph[] graphs;

		[NonSerialized]
		public UserConnection[] userConnections;

		public bool hasBeenReverted;

		[SerializeField]
		public byte[] data;

		public byte[] data_backup;

		public byte[] data_cachedStartup;

		public bool cacheStartup;

		public bool compress;

		public AstarPath active
		{
			get
			{
				return AstarPath.active;
			}
		}

		public void Awake()
		{
			if (cacheStartup && data_cachedStartup != null)
			{
				LoadFromCache();
				return;
			}
			AstarSerializer serializer = new AstarSerializer(active);
			DeserializeGraphs(serializer);
		}

		public void LoadFromCache()
		{
			if (data_cachedStartup != null && data_cachedStartup.Length > 0)
			{
				AstarSerializer serializer = new AstarSerializer(active);
				DeserializeGraphs(serializer, data_cachedStartup);
			}
			else
			{
				Debug.LogError("Can't load from cache since the cache is empty");
			}
		}

		public void SaveCacheData(int mask)
		{
			AstarSerializer astarSerializer = new AstarSerializer(active);
			astarSerializer.mask = mask;
			data_cachedStartup = SerializeGraphs(astarSerializer);
			cacheStartup = true;
		}

		public byte[] SerializeGraphs(AstarSerializer serializer)
		{
			serializer.OpenSerialize();
			SerializeGraphsPart(serializer);
			serializer.Close();
			byte[] array = (serializer.writerStream.BaseStream as MemoryStream).ToArray();
			Debug.Log("Got a whole bunch of data, " + array.Length + " bytes");
			return array;
		}

		public void SerializeGraphsPart(AstarSerializer serializer)
		{
			SizeProfiler.Initialize();
			serializer.writerStream.Write(graphs.Length);
			serializer.writerStream.Write(graphs.Length);
			int[] array = new int[graphs.Length];
			for (int i = 0; i < graphs.Length; i++)
			{
				NavGraph navGraph = graphs[i];
				int num = serializer.mask;
				serializer.AddAnchor("Graph" + i);
				serializer.writerStream.Write(navGraph.GetType().Name);
				serializer.writerStream.Write(navGraph.guid.ToString());
				serializer.sPrefix = i.ToString();
				serializer.SerializeSettings(navGraph, active);
				serializer.sPrefix = string.Empty;
				array[i] = serializer.mask;
				serializer.mask = num;
			}
			serializer.SerializeUserConnections(userConnections);
		}

		public void DeserializeGraphs(AstarSerializer serializer)
		{
			DeserializeGraphs(serializer, data);
		}

		public void DeserializeGraphs(AstarSerializer serializer, byte[] bytes)
		{
			DateTime utcNow = DateTime.UtcNow;
			if (bytes == null || bytes.Length == 0)
			{
				Debug.Log("No previous data, assigning default");
				graphs = new NavGraph[0];
				return;
			}
			Debug.Log("Deserializing...");
			serializer = serializer.OpenDeserialize(bytes);
			DeserializeGraphsPart(serializer);
			serializer.Close();
			DateTime utcNow2 = DateTime.UtcNow;
			Debug.Log("Deserialization complete - Process took " + ((float)(utcNow2 - utcNow).Ticks * 0.0001f).ToString("0.00") + " ms");
		}

		public void DeserializeGraphsPart(AstarSerializer serializer)
		{
			if (serializer.error != AstarSerializer.SerializerError.Nothing)
			{
				data_backup = (serializer.readerStream.BaseStream as MemoryStream).ToArray();
				Debug.Log(string.Concat("Error encountered : ", serializer.error, "\nWriting data to AstarData.data_backup"));
				graphs = new NavGraph[0];
				return;
			}
			try
			{
				int num = serializer.readerStream.ReadInt32();
				int num2 = serializer.readerStream.ReadInt32();
				if (num != num2)
				{
					Debug.LogError("Data is corrupt (" + num + " != " + num2 + ")");
					graphs = new NavGraph[0];
					return;
				}
				NavGraph[] array = new NavGraph[num];
				for (int i = 0; i < array.Length; i++)
				{
					if (!serializer.MoveToAnchor("Graph" + i))
					{
						Debug.LogError("Couldn't find graph " + i + " in the data");
						Debug.Log("Logging... " + serializer.anchors.Count);
						foreach (KeyValuePair<string, int> anchor in serializer.anchors)
						{
							Debug.Log("KeyValuePair " + anchor.Key);
						}
						array[i] = null;
						continue;
					}
					string text = serializer.readerStream.ReadString();
					Guid guid = new Guid(serializer.readerStream.ReadString());
					NavGraph navGraph = GuidToGraph(guid);
					if (navGraph != null)
					{
						array[i] = navGraph;
					}
					else
					{
						array[i] = CreateGraph(text);
					}
					NavGraph navGraph2 = array[i];
					if (navGraph2 == null)
					{
						Debug.LogError("One of the graphs saved was of an unknown type, the graph was of type '" + text + "'");
						data_backup = data;
						graphs = new NavGraph[0];
						return;
					}
					array[i].guid = guid;
					serializer.sPrefix = i.ToString();
					serializer.DeSerializeSettings(navGraph2, active);
				}
				serializer.SetUpGraphRefs(array);
				userConnections = serializer.DeserializeUserConnections();
				List<NavGraph> list = new List<NavGraph>(array);
				for (int j = 0; j < array.Length; j++)
				{
					if (array[j] == null)
					{
						list.Remove(array[j]);
					}
				}
				graphs = list.ToArray();
			}
			catch (Exception ex)
			{
				data_backup = (serializer.readerStream.BaseStream as MemoryStream).ToArray();
				Debug.LogWarning("Deserializing Error Encountered - Writing data to AstarData.data_backup:\n" + ex.ToString());
				graphs = new NavGraph[0];
			}
		}

		public void FindGraphTypes()
		{
			Assembly assembly = Assembly.GetAssembly(typeof(AstarPath));
			Type[] types = assembly.GetTypes();
			List<Type> list = new List<Type>();
			Type[] array = types;
			foreach (Type type in array)
			{
				for (Type baseType = type.BaseType; baseType != null; baseType = baseType.BaseType)
				{
					if (baseType == typeof(NavGraph))
					{
						list.Add(type);
						break;
					}
				}
			}
			graphTypes = list.ToArray();
			Debug.Log("Found " + graphTypes.Length + " graph types");
		}

		public Type GetGraphType(string type)
		{
			for (int i = 0; i < graphTypes.Length; i++)
			{
				if (graphTypes[i].Name == type)
				{
					return graphTypes[i];
				}
			}
			return null;
		}

		public NavGraph CreateGraph(string type)
		{
			Debug.Log("Creating Graph of type '" + type + "'");
			for (int i = 0; i < graphTypes.Length; i++)
			{
				if (graphTypes[i].Name == type)
				{
					return CreateGraph(graphTypes[i]);
				}
			}
			Debug.LogError("Graph type (" + type + ") wasn't found");
			return null;
		}

		public NavGraph CreateGraph(Type type)
		{
			NavGraph navGraph = Activator.CreateInstance(type) as NavGraph;
			navGraph.active = active;
			return navGraph;
		}

		public NavGraph AddGraph(string type)
		{
			NavGraph navGraph = null;
			for (int i = 0; i < graphTypes.Length; i++)
			{
				if (graphTypes[i].Name == type)
				{
					navGraph = CreateGraph(graphTypes[i]);
				}
			}
			if (navGraph == null)
			{
				Debug.LogError("No NavGraph of type '" + type + "' could be found");
				return null;
			}
			AddGraph(navGraph);
			return navGraph;
		}

		public NavGraph AddGraph(Type type)
		{
			NavGraph navGraph = null;
			for (int i = 0; i < graphTypes.Length; i++)
			{
				if (graphTypes[i] == type)
				{
					navGraph = CreateGraph(graphTypes[i]);
				}
			}
			if (navGraph == null)
			{
				Debug.LogError(string.Concat("No NavGraph of type '", type, "' could be found, ", graphTypes.Length, " graph types are avaliable"));
				return null;
			}
			AddGraph(navGraph);
			return navGraph;
		}

		public void AddGraph(NavGraph graph)
		{
			List<NavGraph> list = new List<NavGraph>(graphs);
			list.Add(graph);
			graphs = list.ToArray();
		}

		public void RemoveGraph(NavGraph graph)
		{
			List<NavGraph> list = new List<NavGraph>(graphs);
			list.Remove(graph);
			graphs = list.ToArray();
			graph.SafeOnDestroy();
		}

		public static NavGraph GetGraph(Node node)
		{
			if (node == null)
			{
				return null;
			}
			AstarPath astarPath = AstarPath.active;
			if (astarPath == null)
			{
				return null;
			}
			AstarData astarData = astarPath.astarData;
			if (astarData == null)
			{
				return null;
			}
			if (astarData.graphs == null)
			{
				return null;
			}
			int graphIndex = node.graphIndex;
			if (graphIndex < 0 || graphIndex >= astarData.graphs.Length)
			{
				return null;
			}
			return astarData.graphs[graphIndex];
		}

		public Node GetNode(int graphIndex, int nodeIndex)
		{
			return GetNode(graphIndex, nodeIndex, graphs);
		}

		public Node GetNode(int graphIndex, int nodeIndex, NavGraph[] graphs)
		{
			if (graphs == null)
			{
				return null;
			}
			if (graphIndex < 0 || graphIndex >= graphs.Length)
			{
				Debug.LogError("Graph index is out of range" + graphIndex + " [0-" + (graphs.Length - 1) + "]");
				return null;
			}
			NavGraph navGraph = graphs[graphIndex];
			if (navGraph.nodes == null)
			{
				return null;
			}
			if (nodeIndex < 0 || nodeIndex >= navGraph.nodes.Length)
			{
				Debug.LogError("Node index is out of range : " + nodeIndex + " [0-" + (navGraph.nodes.Length - 1) + "]");
				return null;
			}
			return navGraph.nodes[nodeIndex];
		}

		public NavGraph FindGraphOfType(Type type)
		{
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i].GetType() == type)
				{
					return graphs[i];
				}
			}
			return null;
		}

		public IEnumerable FindGraphsOfType(Type type)
		{
			if (graphs == null)
			{
				yield break;
			}
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i].GetType() == type)
				{
					yield return graphs[i];
				}
			}
		}

		public IEnumerable GetUpdateableGraphs()
		{
			if (graphs == null)
			{
				yield break;
			}
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] is IUpdatableGraph)
				{
					yield return graphs[i];
				}
			}
		}

		public IEnumerable GetRaycastableGraphs()
		{
			if (graphs == null)
			{
				yield break;
			}
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] is IRaycastableGraph)
				{
					yield return graphs[i];
				}
			}
		}

		public int GetGraphIndex(NavGraph graph)
		{
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graph == graphs[i])
				{
					return i;
				}
			}
			Debug.LogError("Graph doesn't exist");
			return -1;
		}

		public int GuidToIndex(Guid guid)
		{
			if (graphs == null)
			{
				return -1;
			}
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] == null)
				{
					Debug.LogWarning("Graph " + i + " is null - This should not happen");
				}
				else if (graphs[i].guid == guid)
				{
					return i;
				}
			}
			return -1;
		}

		public NavGraph GuidToGraph(Guid guid)
		{
			if (graphs == null)
			{
				return null;
			}
			for (int i = 0; i < graphs.Length; i++)
			{
				if (graphs[i] == null)
				{
					Debug.LogWarning("Graph " + i + " is null - This should not happen");
				}
				else if (graphs[i].guid == guid)
				{
					return graphs[i];
				}
			}
			return null;
		}
	}
}
