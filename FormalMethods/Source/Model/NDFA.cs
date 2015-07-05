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
			if (addedNodes.Count > 0)
			{
				todoNodes.Add(Util.toCSV(addedNodes));
			}
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

		HashSet<string> all_TO_nodes = new HashSet<string>();
		HashSet<string> all_FROM_nodes = new HashSet<string>();
		foreach (Transition tr in result.transitions)
		{
			all_TO_nodes.Add(tr.to);
			all_FROM_nodes.Add(tr.from);
		}
		foreach (string from in all_FROM_nodes)
		{
			if (!result.startNodes.Contains(from))
			{
				bool check = false;
				foreach (Transition tr in result.transitions)
				{
					if (tr.to == from)
						check = true;
				}
				if (!check)
				{
					result.transitions.RemoveAll(x => x.from == from);
				}
			}
			
		}
		//if (result.isDFA())
			return result;
		//else
		//	return null;
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
			SortedSet<string> accessableNodes = getAllAccessableNodes(currentNode, transition);
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
}
}
