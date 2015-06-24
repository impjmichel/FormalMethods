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

	public NDFA toNDFA()
	{
		if (mInput == null)
			return null;
		NDFA ndfa = new NDFA(mAlphabet);

		string[] lines = mInput.Split(new Char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

		// every line
		foreach (string line in lines)
		{
			string[] parts = line.Split(new Char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			string newLine = "";
			foreach (string str in parts)
			{
				newLine += str;
			}
			
			// split in from and to parts
			parts = newLine.Split(new Char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
			Util.Assert(parts.Length == 2, "somehow the input had more than 1 arrow");
			string from = parts[0];

			if (ndfa.startNodes.Count == 0)
				ndfa.startNodes.Add(from);

			string toString = parts[1];
			string[] toParts = toString.Split(new Char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string to in toParts)
			{
				if (mAlphabet.characters.Contains(to[0]))
				{
					char transitionLabel = to[0];
					string toState = cEndStateLabel;
					if (to.Length > 1)
						toState = to.Substring(1);
					else
					{
						ndfa.endNodes.Add(cEndStateLabel);
					}
					Transition transition = new Transition(transitionLabel, from, toState);
					ndfa.transitions.Add(transition);
				}
			}
		}
		return ndfa;
	}
}
}
