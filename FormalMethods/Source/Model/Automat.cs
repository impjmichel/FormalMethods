using System;
using System.Collections.Generic;

namespace Models
{
class Automat : RegBase
{
	protected string input;
	protected List<Transition> mTransitions = new List<Transition>();
	protected SortedSet<string> mStartNodes = new SortedSet<string>();
	protected SortedSet<string> mEndNodes = new SortedSet<string>();
	protected Alphabet mAlphabet;

	public const string cFailState = "Ø";

	public Alphabet alphabet
	{
		get { return mAlphabet; }
	}
	public List<Transition> transitions
	{
		get { return mTransitions; }
	}
	public SortedSet<string> nodes
	{
		get { return fillNodes(); }
	}
	public SortedSet<string> startNodes
	{
		get { return mStartNodes; }
	}
	public SortedSet<string> endNodes
	{
		get { return mEndNodes; }
	}

	private SortedSet<string> fillNodes()
	{
		SortedSet<string> set = new SortedSet<string>();
		foreach (Transition trans in mTransitions)
		{
			set.Add(trans.from);
			set.Add(trans.to);
		}
		return set;
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
