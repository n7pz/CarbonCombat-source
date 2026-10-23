namespace Pathfinding
{
	public class NNConstraint
	{
		public bool constrainArea;

		public int area = -1;

		public bool constrainWalkability = true;

		public bool walkable = true;

		public static NNConstraint Default
		{
			get
			{
				return new NNConstraint();
			}
		}

		public static NNConstraint None
		{
			get
			{
				NNConstraint nNConstraint = new NNConstraint();
				nNConstraint.constrainWalkability = false;
				nNConstraint.constrainArea = false;
				return nNConstraint;
			}
		}

		public virtual bool Suitable(Node node)
		{
			if (constrainWalkability && node.walkable != walkable)
			{
				return false;
			}
			if (constrainArea && area >= 0 && node.area != area)
			{
				return false;
			}
			return true;
		}
	}
}
