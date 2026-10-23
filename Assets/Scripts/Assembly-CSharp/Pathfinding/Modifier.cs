using System;

namespace Pathfinding
{
	[Serializable]
	public abstract class Modifier : IPathModifier
	{
		public int priority;

		[NonSerialized]
		public Seeker seeker;

		public abstract ModifierData input { get; }

		public abstract ModifierData output { get; }

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

		public void Awake(Seeker s)
		{
			seeker = s;
			if (s != null)
			{
				s.RegisterModifier(this);
			}
		}

		public void OnDestroy(Seeker s)
		{
			if (s != null)
			{
				s.DeregisterModifier(this);
			}
		}

		public virtual void ApplyOriginal(Path p)
		{
		}

		public abstract void Apply(Path p, ModifierData source);

		public virtual void PreProcess(Path p)
		{
		}
	}
}
