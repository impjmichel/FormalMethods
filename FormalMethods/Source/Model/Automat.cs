using System;
using System.Collections.Generic;

namespace Models
{
class Automat : RegBase
{
	protected string mInput;
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


	public bool AcceptInput(string input)
	{
		SortedSet<string> currentState = new SortedSet<string>(mStartNodes);
		foreach (char ch in input)
		{
			currentState = GetNextStates(ch, currentState);
		}
		return currentState.Overlaps(mEndNodes);
	}

	private SortedSet<string> GetNextStates(char input, SortedSet<string> currentState)
	{
		SortedSet<string> result = new SortedSet<string>();
		foreach (string node in currentState)
		{
			SortedSet<string> set = getAllAccessableNodes(node, input);
			result.UnionWith(set);
		}
		return result;
	}


	/// <summary>
	/// method to get all nodes that are accessable by 'node' with the 'transition',
	/// to disable epsylon transition set 'withEpsylon' to false
	/// </summary>
	protected SortedSet<string> getAllAccessableNodes(string node, char transition, bool withEpsylon = true)
	{
		SortedSet<string> result = new SortedSet<string>();
		List<Transition> charTransitions = mTransitions.FindAll(x => x.from == node && x.label == transition);
		HashSet<Transition> resultTransitions = new HashSet<Transition>(charTransitions);
		// epsylon transitions
		if (withEpsylon)
		{
			HashSet<Transition> startTransitions = getAllEpsylonTransitions(node);
			HashSet<Transition> midTransitions = new HashSet<Transition>();
			foreach (Transition trans in startTransitions)
			{
				midTransitions.UnionWith(getAllCharTransitions(trans.to, transition));
			}
			HashSet<Transition> endTransitions = new HashSet<Transition>();
			foreach (Transition trans in midTransitions)
			{
				endTransitions.UnionWith(getAllEpsylonTransitions(trans.to));
			}
			endTransitions.UnionWith(midTransitions); // note: not the startTransitions, because it can't stop without using the char transition.
			resultTransitions.UnionWith(endTransitions);
		}
		// from transition to node names:
		foreach (Transition trans in resultTransitions)
		{
			result.Add(trans.to);
		}
		return result;
	}

	private HashSet<Transition> getAllCharTransitions(string startNode, char transition)
	{
		HashSet<Transition> result = new HashSet<Transition>();
		result.UnionWith(mTransitions.FindAll(x => (x.from == startNode) && (x.label == transition)));
		return result;
	}

	private HashSet<Transition> getAllEpsylonTransitions(string startNode)
	{
		HashSet<Transition> allTransitions = new HashSet<Transition>();
		allTransitions.UnionWith(mTransitions.FindAll(x => (x.from == startNode) && (x.label == Alphabet.Epsylon)));
		if (allTransitions.Count > 0)
		{
			foreach (Transition trans in allTransitions)
			{
				allTransitions.UnionWith(getAllEpsylonTransitions(trans.from));
			}
		}
		return allTransitions;
	}
}
}
