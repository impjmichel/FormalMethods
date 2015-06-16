using System;
using System.Collections.Generic;

namespace Models
{

class DFA
{
	private string input;
	private List<Node> mNodes = new List<Node>();

	public List<Node> nodes
	{
		get { return mNodes; }
		set { mNodes = value; }
	}

	public void setInput(string newInput)
	{
		input = newInput;
	}

	public string getInput()
	{
		return input;
	}

	public void addNode(Node node)
	{
		mNodes.Add(node);
	}
}
}
