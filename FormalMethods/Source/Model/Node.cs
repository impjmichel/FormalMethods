using System.Collections.Generic;


namespace Models
{
/// <summary>
/// Node : where T should be a String, or a List of Strings, or soft drinks.
/// </summary>
class Node<T>
{
	private string mName;

	private Dictionary<char, T> mNextNodes = new Dictionary<char, T>();
	private Dictionary<char, T> mPreviousNodes = new Dictionary<char, T>();

	
	public bool endNode;
	public bool startNode;
	public string name
	{
		get { return mName; }
	}
	public Dictionary<char, T> nextNodes
	{
		get { return mNextNodes; }
		set { mNextNodes = value; }
	}
	public Dictionary<char, T> previousNodes
	{
		get { return mPreviousNodes; }
		set { mPreviousNodes = value; }
	}

	public Node(string name)
	{
		mName = name;
	}
}
}
