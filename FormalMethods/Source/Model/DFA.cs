using System;
using System.Collections.Generic;

namespace Models
{

class DFA : Automat
{
	public DFA(Alphabet alphabet)
	{
		mAlphabet = alphabet;
	}

	public bool isDFA()
	{
		int alphabetCount = mAlphabet.characters.Count;
		// check if there's only 1 start point
		if (mStartNodes.Count == 1)
		{
			// check if there are any epsylon transitions
			foreach(Transition trans in mTransitions)
			{
				if (trans.label == Alphabet.Epsylon)
					return false;
			}
			// check if every node has the right number of transitions
			foreach(string node in nodes)
			{
				List<Transition> fromTransitions = mTransitions.FindAll(x => x.from == node);
				if (fromTransitions.Count != alphabetCount)
					return false;
			}
			// if it got this far this object is a DFA
			return true;
		}
		return false;
	}

	/// <summary>
	/// Why? because we can.
	/// </summary>
	public NDFA toNDFA()
	{
		NDFA result = new NDFA(mAlphabet);
		result.endNodes.UnionWith(mEndNodes);
		result.startNodes.UnionWith(mStartNodes);
		result.transitions.AddRange(mTransitions);
		return result;
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

	public DFA minimalize()
	{
		NDFA reverse1 = reverse();
		DFA dfa2 = reverse1.toDFA();
		NDFA reverse2 = dfa2.reverse();
		return reverse2.toDFA();
	}

	public static NDFA reverse(DFA oldDFA)
	{
		NDFA result = new NDFA(oldDFA.alphabet);
		result.startNodes.UnionWith(oldDFA.endNodes);
		result.endNodes.UnionWith(oldDFA.startNodes);
		foreach (Transition trans in oldDFA.transitions)
		{
			Transition newTrans = new Transition(trans.label, trans.to, trans.from);
			result.transitions.Add(newTrans);
		}
		return result;
	}
}
}
