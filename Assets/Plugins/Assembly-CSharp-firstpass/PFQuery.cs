using System.Collections.Generic;

public class PFQuery
{
	public string ClassName;

	public List<PFPointer> WherePointers = new List<PFPointer>();

	public Dictionary<string, string> WhereData = new Dictionary<string, string>();

	public string Order;

	public int Limit = 10;
}
