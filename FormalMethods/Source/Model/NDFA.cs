using System;
using System.Collections.Generic;

namespace Models
{

class NDFA
{
	private string input;
	private List<Node<List<String>>> mNodes = new List<Node<List<String>>>();

	public List<Node<List<String>>> nodes
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

	public void addNode(Node<List<String>> node)
	{
		mNodes.Add(node);
	}
}
}
