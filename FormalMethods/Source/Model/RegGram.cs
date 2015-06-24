using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{

class RegGram : RegBase
{
	private Alphabet mAlphabet;
	private string mInput;

	public RegGram(Alphabet alphabet)
	{
		mAlphabet = alphabet;
	}
	public RegGram(Alphabet alphabet, string input)
	{
		mAlphabet = alphabet;
		mInput = input;
	}

	/// <summary>
	/// direct GraphViz use, without going to NDFA (it does create NDFA picture)
	/// </summary>
	public string CreateGraphizString()
	{
		if (mInput == null)
			return null;
		string result = "";
		string endNode = "end";
		string[] lines = mInput.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

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

	public NDFA toNDFA()
	{
		//TODO
		throw new NotImplementedException();
	}
}
}
