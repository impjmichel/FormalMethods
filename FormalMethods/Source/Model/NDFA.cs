using System;
using System.Collections.Generic;

namespace Models
{

class NDFA : Automat
{
	public NDFA(Alphabet alphabet)
	{
		mAlphabet = alphabet;
	}

	public DFA toDFA()
	{
		DFA result = new DFA(mAlphabet);
		result.startNodes.Add(Util.toCSV(mStartNodes));
		HashSet<Transition> newTransitions = new HashSet<Transition>();
		// failstate transitions:
		foreach (char transition in mAlphabet.characters)
		{
			Transition failure = new Transition(transition, Automat.cFailState, Automat.cFailState);
			newTransitions.Add(failure);
		}

		// fill transitions:
		List<string> todoNodes = new List<string>(); // list of comma seperated values of the node names.
		todoNodes.Add(Util.toCSV(mStartNodes));
		List<string> doneNodes = new List<string>();
		while (todoNodes.Count > 0)
		{
			string currentNodes = todoNodes[0]; // csv at first place
			todoNodes.Remove(currentNodes);
			SortedList<string, string> tempNodes = Util.toSortedList(currentNodes);
			HashSet<Transition> addedTransitions = new HashSet<Transition>();
			SortedList<string, string> addedNodes = new SortedList<string, string>();
			foreach (string currentNode in tempNodes.Values)
			{
				addedTransitions.UnionWith(getTransitions(currentNode));
			}
			foreach (Transition trans in addedTransitions)
			{
				if (!addedNodes.ContainsValue(trans.to) && trans.to != Automat.cFailState)
				{
					addedNodes.Add(trans.to, trans.to);
				}
			}
			newTransitions.UnionWith(addedTransitions);
			doneNodes.Add(currentNodes);
			todoNodes.Add(Util.toCSV(addedNodes));
		}
		result.transitions.AddRange(newTransitions);

		// end states:
		foreach (string end in mEndNodes)
		{
			foreach (string csv in result.nodes)
			{
				SortedSet<string> set = Util.toSet(csv);
				if (set.Contains(end))
				{
					result.endNodes.Add(csv);
				}
			}
		}
		if (result.isDFA())
			return result;
		else
			return null; 
		}

	public NDFA reverse()
	{
		NDFA result = new NDFA(mAlphabet);
		result.startNodes.UnionWith(mEndNodes);
		result.endNodes.UnionWith(mStartNodes);
		foreach (Transition trans in mTransitions)
		{
			Transition newTrans = new Transition(trans.label, trans.to, trans.from);
			result.transitions.Add(newTrans);
		}
		return result;
	}

	public static NDFA reverse(NDFA oldNDFA)
	{
		NDFA result = new NDFA(oldNDFA.alphabet);
		result.startNodes.UnionWith(oldNDFA.endNodes);
		result.endNodes.UnionWith(oldNDFA.startNodes);
		foreach (Transition trans in oldNDFA.transitions)
		{
			Transition newTrans = new Transition(trans.label, trans.to, trans.from);
			result.transitions.Add(newTrans);
		}
		return result;
	}


	private HashSet<Transition> getTransitions(string currentNode)
	{
		HashSet<Transition> newTransitions = new HashSet<Transition>();
		foreach (char transition in mAlphabet.characters)
		{
			SortedList<string, string> accessableNodes = getAllAccessableNodes(currentNode, transition);
			if (accessableNodes.Count == 0)
			{
				Transition toFailState = new Transition(transition, currentNode, Automat.cFailState);
				newTransitions.Add(toFailState);
			}
			else
			{
				Transition toNewState = new Transition(transition, currentNode, Util.toCSV(accessableNodes));
				newTransitions.Add(toNewState);
			}
		}
		return newTransitions;
	}


	/// <summary>
	/// method to get all nodes that are accessable by 'node' with the 'transition',
	/// to disable epsylon transition set 'withEpsylon' to false
	/// </summary>
	private SortedList<string, string> getAllAccessableNodes(string node, char transition, bool withEpsylon = true)
	{
		SortedList<string, string> result = new SortedList<string, string>();
		HashSet<Transition> resultTransitions = new HashSet<Transition>();
		List<Transition> allNodeTransitions = mTransitions.FindAll(x => x.from == node);

		List<Transition> charTransitions = allNodeTransitions.FindAll(x => x.label == transition);
		resultTransitions.UnionWith(charTransitions);

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
			result.Add(trans.to, trans.to);
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
