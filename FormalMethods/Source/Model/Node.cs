using System.Collections.Generic;
using System;

namespace Models
{
class Node : IComparable<Node>
{
	private List<string> mOperators = new List<string>();

	private Dictionary<char, SortedSet<string>> mDFAoperators = new Dictionary<char, SortedSet<string>>();

	public string name;

	public Node()
	{ }
	public Node(string name)
	{
		this.name = name;
	}

	public List<string> operators
	{
		get { return mOperators; }
	}

	public Dictionary<char, SortedSet<string>> DFAoperators
	{
		get { return mDFAoperators; }
	}

	public int CompareTo(Node other)
	{
		return name.CompareTo(other.name);
	}
}
}
