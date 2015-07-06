using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
				string newNode = Util.toCSV(addedNodes);
				if (!doneNodes.Contains(newNode))
					todoNodes.Add(newNode);
			}
		}
		result.transitions.AddRange(newTransitions);
		// the '+' check:
		foreach (Transition tr in mTransitions)
		{
			if (tr.label != Alphabet.Epsylon)
			{
				Transition temp = mTransitions.Find(x => x.label == Alphabet.Epsylon && x.to == tr.from && x.from == tr.to);
				if (temp != null)
				{
					result.transitions.Add(new Transition(tr.label, temp.from, temp.to));
				}
			}
		}

		//-------------------------------------------------------------------
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
		// add also all states that have epsylon transitions to an endNode:
		List<Transition> endNodetransitions = mTransitions.FindAll(x => mEndNodes.Contains(x.to) && x.label == Alphabet.Epsylon);
		foreach (Transition trans in endNodetransitions)
		{
			//result.endNodes.Add(trans.from);
			foreach (string csv in result.nodes)
			{
				SortedSet<string> set = Util.toSet(csv);
				if (set.Contains(trans.from))
				{
					result.endNodes.Add(csv);
				}
			}
		}
		// removing all useless transitions (nodes with no "to" arrows that are not start nodes)
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
		//removing every node that isn't part of the nodes list:
		result.endNodes.IntersectWith(result.nodes);
		//-------------------------------------------------------------------
		// failstate transitions:
		// failstate transitions:
		foreach (char transition in mAlphabet.characters)
		{
			Transition failure = new Transition(transition, Automat.cFailState, Automat.cFailState);
			newTransitions.Add(failure);
		}
		foreach (string node in result.nodes)
		{
			foreach (char transition in mAlphabet.characters)
			{
				Transition tr = result.transitions.Find(x => x.from == node && x.label == transition);
				if (tr == null)
				{
					result.transitions.Add(new Transition(transition, node, Automat.cFailState));
				}
			}
		}
		//-------------------------------------------------------------------------------------------------------
		//cleaning names:
		Dictionary<string, string> remapper = new Dictionary<string, string>();
		for (int i = 0; i < result.nodes.Count; ++i)
		{
			remapper.Add(result.nodes.ElementAt<string>(i), "" + i);
		}
		// start nodes
		SortedSet<string> renamedStartNodes = new SortedSet<string>();
		foreach (string str in result.startNodes)
		{
			if (remapper.ContainsKey(str))
				renamedStartNodes.Add(remapper[str]);
		}
		result.startNodes.Clear();
		result.startNodes.UnionWith(renamedStartNodes);
		// end nodes:
		SortedSet<string> renamedEndNodes = new SortedSet<string>();
		foreach (string str in result.endNodes)
		{
			if (remapper.ContainsKey(str))
				renamedEndNodes.Add(remapper[str]);
		}
		result.endNodes.Clear();
		result.endNodes.UnionWith(renamedEndNodes);
		// transitions:
		List<Transition> renamedTransitions = new List<Transition>();
		foreach (Transition tr in result.transitions)
		{
			if (remapper.ContainsKey(tr.from) && remapper.ContainsKey(tr.to))
				renamedTransitions.Add(new Transition(tr.label, remapper[tr.from], remapper[tr.to]));
		}
		result.transitions.Clear();
		result.transitions.AddRange(renamedTransitions);
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
