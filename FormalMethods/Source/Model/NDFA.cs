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
		// TODO!
		// something with foreach char in Alphabet and these string nodes...
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
}
}
