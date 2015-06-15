using System;
using System.Collections.Generic;

namespace Models
{

class DFA
{
	private string input;
	private List<Node<String>> mNodes = new List<Node<String>>();

	public List<Node<String>> nodes
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

	public void addNode(Node<String> node)
	{
		mNodes.Add(node);
	}
}
}
