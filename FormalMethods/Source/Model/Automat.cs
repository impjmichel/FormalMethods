using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
class Automat : RegBase
{
	protected string input;
	protected List<Transition> mTransitions = new List<Transition>();
	protected HashSet<string> mNodes = new HashSet<string>();
	protected HashSet<string> mStartNodes = new HashSet<string>();
	protected HashSet<string> mEndNodes = new HashSet<string>();
	protected Alphabet mAlphabet;

	public Alphabet alphabet
	{
		get { return mAlphabet; }
	}
	public List<Transition> transitions
	{
		get { return mTransitions; }
	}
	public HashSet<string> nodes
	{
		get { return fillNodes(); }
	}
	public HashSet<string> startNodes
	{
		get { return mStartNodes; }
	}
	public HashSet<string> endNodes
	{
		get { return mEndNodes; }
	}

	private HashSet<string> fillNodes()
	{
		mNodes.Clear();
		foreach (Transition trans in mTransitions)
		{
			mNodes.Add(trans.from);
			mNodes.Add(trans.to);
		}
		return mNodes;
	}

	public string toGraphVizString()
	{
		string result = cBeginRegGrammar;
		foreach (string str in mStartNodes)
		{
			result += cStartingPoint + str + stop;
		}
		foreach (Transition trans in mTransitions)
		{
			result += trans.from + cTo + trans.to + cLabelStart + trans.label + cLabelEnd + stop;
		}
		foreach (string str in mEndNodes)
		{
			result += str + cEndingCircle + stop;
		}
		result += cEndRegGrammar;
		return result;
	}
}
}
