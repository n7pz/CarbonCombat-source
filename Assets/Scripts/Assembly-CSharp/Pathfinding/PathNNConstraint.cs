namespace Pathfinding
{
	public class PathNNConstraint : NNConstraint
	{
		public new static PathNNConstraint Default
		{
			get
			{
				PathNNConstraint pathNNConstraint = new PathNNConstraint();
				pathNNConstraint.constrainArea = true;
				return pathNNConstraint;
			}
		}

		public virtual void SetStart(Node node)
		{
			if (node != null)
			{
				area = node.area;
			}
			else
			{
				constrainArea = false;
			}
		}
	}
}
