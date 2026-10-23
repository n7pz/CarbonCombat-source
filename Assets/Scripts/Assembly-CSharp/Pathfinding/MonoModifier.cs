using System;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	public abstract class MonoModifier : MonoBehaviour, IPathModifier
	{
		[NonSerialized]
		public Seeker seeker;

		public int priority;

		public int Priority
		{
			get
			{
				return priority;
			}
			set
			{
				priority = value;
			}
		}

		public abstract ModifierData input { get; }

		public abstract ModifierData output { get; }

		public void Awake()
		{
			seeker = GetComponent<Seeker>();
			if (seeker != null)
			{
				seeker.RegisterModifier(this);
			}
		}

		public void OnDestroy()
		{
			if (seeker != null)
			{
				seeker.DeregisterModifier(this);
			}
		}

		public virtual void ApplyOriginal(Path p)
		{
		}

		public abstract void Apply(Path p, ModifierData source);

		public virtual void PreProcess(Path p)
		{
		}

		public virtual Vector3[] GetNextTarget(Path p, Vector3 currentPosition)
		{
			return p.vectorPath;
		}

		public virtual Vector3[] Apply(Node[] path, Vector3 start, Vector3 end, int startIndex, int endIndex, NavGraph graph)
		{
			Vector3[] array = new Vector3[endIndex - startIndex];
			for (int i = startIndex; i < endIndex; i++)
			{
				array[i - startIndex] = path[i].position;
			}
			return array;
		}

		public virtual Vector3[] Apply(Vector3[] path, Vector3 start, Vector3 end)
		{
			return path;
		}
	}
}
