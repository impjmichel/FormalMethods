using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

class RegGram : RegBase
{
	private Node startNode = new Node();
	private List<Node> endNodes = new List<Node>();
	private List<Node> nodes = new List<Node>();

    private Alphabet alphabet;

    public RegGram(Alphabet alpha)
    {
        alphabet = alpha;
    }

	public string CreateGraphizString(string input)
	{
		string result = "";
		string endNode = "end";
		string[] lines = input.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

		// begin
		result += cBeginRegGrammar + cStartingPoint + lines[0].Trim()[0] + stop;

		// every line
		foreach (string line in lines)
		{
			string[] parts = line.Split(new Char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			string newLine = "";
			foreach (string str in parts)
			{
				newLine += str;
			}
			// start node
			string startNodeName = newLine.Substring(0, 1);
			// to sign
			int toIndex = newLine.IndexOf('>');
			// while | nodes
			string[] rest = newLine.Substring(toIndex + 1).Split('|');

			foreach(string nextNode in rest)
			{
				if(nextNode.Length == 1)
				{
					// eindtoestand
					if (nextNode[0] == 'a' || nextNode[0] == 'b')
					{
						result += startNodeName + cTo + endNode;
					}
				}
				else
				{
					result += startNodeName + cTo + nextNode[1];
				}
				if (nextNode[0] == 'a')
				{
					result += cA;
				}
				else if (nextNode[0] == 'b')
				{
					result += cB;
				}
				result += stop;
			}
		}
		//end
		result += endNode + cEndingCircle+ cEndRegGrammar;
		return result;
	}


	private string toDFA(string graphVizInput)
	{
		fillNodeLists(graphVizInput);

		List<Node> todoNodes = new List<Node>();
		List<Node> newNodes = new List<Node>();
		List<Node> newEndNodes = new List<Node>();
		Node newStartNode = new Node(startNode.name);
		newStartNode = fillNewNode(newStartNode, startNode);
		todoNodes.Add(newStartNode);

		while(todoNodes.Count > 0)
		{
			Node node = todoNodes[0];
			foreach (var pair in node.DFAoperators)
			{
				Node newNode = new Node();
				newNode.name = "";
				foreach (string next in pair.Value.ToList<string>())
				{
					if (pair.Value.ToList<string>().IndexOf(next) != 0)
					{
						newNode.name += ",";
					}
					newNode.name += next;
					Node tempNode = nodes.Find(x => x.name == next);
					if (tempNode != null)
					{
						fillNewNode(newNode, tempNode);
					}
				}
				todoNodes.Add(newNode);
			}
			newNodes.Add(node);
			todoNodes.Remove(node);
		}
		return toDFAString(newStartNode, newNodes, newEndNodes);
	}

	private void fillNodeLists(string graphVizInput)
	{
		int start = graphVizInput.IndexOf("x->");
		string importantPart = graphVizInput.Substring(start);
		string[] operators = importantPart.Split(new Char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
		startNode.name = operators[0].Substring(3);
		nodes.Add(startNode);
		for (int i = 1; i < operators.Length; ++i)
		{
			if (operators[i].Contains(cTo))
			{
				// operator
				Node newNode = new Node();
				int arrowIndex = operators[i].IndexOf(cTo);
				string name = operators[i].Substring(0, arrowIndex);
				newNode.name = name;

				if (!nodes.Contains(newNode))
				{
					nodes.Add(newNode);
				}
				Node tempNode = nodes.Find(item => item.name == name);
				if (tempNode != null)
				{
					string withoutFirstPart = operators[i].Replace(name + cTo, String.Empty);
					if (withoutFirstPart.Contains('['))
					{
						string op = withoutFirstPart.Split('[')[0];
						op += "," + withoutFirstPart.Substring(withoutFirstPart.Length - 2, 1);
						tempNode.operators.Add(op);
					}
					else
					{
						tempNode.operators.Add(withoutFirstPart + ",y");
					}
				}
			}
			else if (operators[i].Contains(cEndingCircle))
			{
				// end thingy
				Node endingNode = new Node();
				int index = operators[i].IndexOf(cEndingCircle);
				endingNode.name = operators[i].Substring(0, index);
				nodes.Add(endingNode);
				endNodes.Add(endingNode);
			}
		}
	}

	/// <summary>
	/// only call when going to DFA and startNode is filled.
	/// </summary>
	private Node fillNewNode(Node newNode, Node oldNode)
	{
		foreach (string op in oldNode.operators)
		{
			string nextNode = op.Split(',')[0];
			char transition = op.Split(',')[1][0];
			if (newNode.DFAoperators.ContainsKey(transition))
			{
				SortedSet<string> oldOp = newNode.DFAoperators[transition];
				oldOp.Add(nextNode);
			}
			else
			{
				newNode.DFAoperators.Add(transition, new SortedSet<string>() { nextNode });
			}
		}
		return newNode;
	}

	private string toDFAString(Node start, List<Node> nodes, List<Node> end)
	{
		string result = cBeginRegGrammar + cStartingPoint + start.name + stop;
		foreach (Node node in nodes)
		{
			result += node.name + cTo + node.DFAoperators['a'].ToList<string>()[0] + stop;
			result += node.name + cTo + node.DFAoperators['b'].ToList<string>()[0] + stop;
		}
		for (int i = 0; i < end.Count; ++i)
		{
			result += end[i].name + cEndingCircle;
			if (i < end.Count - 1)
			{
				result += stop;
			}
		}
		result += cEndRegGrammar;
		return result;
	}
}
}
