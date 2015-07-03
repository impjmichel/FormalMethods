﻿using System;
using System.Collections.Generic;

namespace Models
{
class RegExp : RegBase
{
	private int mCurrentNodeNumber = 0;
	private int mOrEnd = 0;
	private bool orStarted = false;
	private bool orEnd = false;
	private bool bracketOpen = false;

	private string mRegEx;
	private Alphabet mAlphabet;

#region public
	public RegExp(string regEx, Alphabet alpha)
	{
		mAlphabet = alpha;
		mRegEx = regEx;
	}

	public NDFA toNDFA()
	{
		if (String.IsNullOrWhiteSpace(mRegEx))
			return null;
		NDFA ndfa = new NDFA(mAlphabet);
		ndfa.transitions.AddRange(regexToTransitions());
		ndfa.startNodes.Add("0"); // we start always at 0
		ndfa.endNodes.Add("" + mCurrentNodeNumber); // shouldn't be reset yet...
		return ndfa;
	}
#endregion

#region private
	private List<Transition> regexToTransitions()
	{
		mCurrentNodeNumber = 0;
		return regexToTransitions(mRegEx);
	}

	private List<Transition> regexToTransitions(string regEx, int previousNodeNumber = 0)
	{
		Console.WriteLine("REGEX:  " + mRegEx);
		List<Transition> result = new List<Transition>();

		for (int i = 0; i < mRegEx.Length; ++i)
		{
			Transition tempTransition;
			char ch = mRegEx[i];
			switch (ch) // special RegEx characters: ( ) + * |
			{
				case '(':
					if (orStarted)
					{
						bracketOpen = true;
					}
					// open bracket
					tempTransition = new Transition(Alphabet.Epsylon, "" + mCurrentNodeNumber);
					previousNodeNumber = mCurrentNodeNumber;
					mCurrentNodeNumber++;
					tempTransition.to = "" + mCurrentNodeNumber;
					result.Add(tempTransition);
					string sub = regEx.Substring(i+1);
					int endOfBracket;
					result.AddRange(HandleOpenBracket(sub, previousNodeNumber, out endOfBracket));
					i += endOfBracket;
					break;
				case ')':
					bracketOpen = false;
					tempTransition = new Transition(Alphabet.Epsylon, "" + mCurrentNodeNumber);
					mCurrentNodeNumber++;
					tempTransition.to = "" + mCurrentNodeNumber;
					result.Add(tempTransition);
					if (orEnd)
					{
						tempTransition = new Transition(Alphabet.Epsylon, "" + mOrEnd, "" + mCurrentNodeNumber);
						result.Add(tempTransition);
						orEnd = false;
						orStarted = false;
					}
					break;
				case '+':
					tempTransition = new Transition(Alphabet.Epsylon, "" + mCurrentNodeNumber, "" + previousNodeNumber);
					result.Add(new Transition(Alphabet.Epsylon, "" + mCurrentNodeNumber, "" + previousNodeNumber));
					if (orEnd && !bracketOpen)
					{
						tempTransition = new Transition(Alphabet.Epsylon, "" + mCurrentNodeNumber);
						mCurrentNodeNumber++;
						tempTransition.to = "" + mCurrentNodeNumber;
						result.Add(tempTransition);
						tempTransition = new Transition(Alphabet.Epsylon, "" + mOrEnd, "" + mCurrentNodeNumber);
						result.Add(tempTransition);
						orEnd = false;
						orStarted = false;
					}
					break;
				case '*':
					tempTransition = new Transition(Alphabet.Epsylon, "" + mCurrentNodeNumber, "" + previousNodeNumber);
					result.Add(tempTransition);
					tempTransition = new Transition(Alphabet.Epsylon, "" + previousNodeNumber, "" + mCurrentNodeNumber);
					result.Add(tempTransition);
					if (orEnd && !bracketOpen)
					{
						tempTransition = new Transition(Alphabet.Epsylon, "" + mCurrentNodeNumber);
						mCurrentNodeNumber++;
						tempTransition.to = "" + mCurrentNodeNumber;
						result.Add(tempTransition);
						tempTransition = new Transition(Alphabet.Epsylon, "" + mOrEnd, "" + mCurrentNodeNumber);
						result.Add(tempTransition);
						orEnd = false;
						orStarted = false;
					}
					break;
				case '|':
					orStarted = true;
					mOrEnd = mCurrentNodeNumber + 1;
					tempTransition = new Transition(Alphabet.Epsylon, "" + mCurrentNodeNumber, "" + mOrEnd);
					result.Add(tempTransition);
					mCurrentNodeNumber = mOrEnd + 1;
					break;
				case '?':
					tempTransition = new Transition(Alphabet.Epsylon, "" + previousNodeNumber, "" + mCurrentNodeNumber);
					result.Add(tempTransition);
					if (orEnd && !bracketOpen)
					{
						tempTransition = new Transition(Alphabet.Epsylon, "" + mCurrentNodeNumber);
						mCurrentNodeNumber++;
						tempTransition.to = "" + mCurrentNodeNumber;
						result.Add(tempTransition);
						tempTransition = new Transition(Alphabet.Epsylon, "" + mOrEnd, "" + mCurrentNodeNumber);
						result.Add(tempTransition);
						orEnd = false;
						orStarted = false;
					}
					break;
				default:
					if (mAlphabet.characters.Contains(ch))
					{
						previousNodeNumber = mCurrentNodeNumber;
						mCurrentNodeNumber++;
						tempTransition = new Transition(ch, "" + previousNodeNumber, "" + mCurrentNodeNumber);
						result.Add(new Transition(ch, "" + previousNodeNumber, "" + mCurrentNodeNumber));
					}
					break;
			}
			if (orStarted && !orEnd)
			{
				tempTransition = new Transition(Alphabet.Epsylon, "" + previousNodeNumber, "" + mCurrentNodeNumber);
				result.Add(tempTransition);
				orEnd = true;
			}
		}
		return result;
	}

	private List<Transition> HandleOpenBracket(string regEx, int previousNodeNumber, out int length)
	{
		length = 0;
		for (int i = regEx.Length -1; i > 0; --i )
		{
			if (regEx[i] == ')')
			{
				length = i + 1;
			}
		}
		return regexToTransitions(regEx.Substring(0, length), previousNodeNumber);
	}
#endregion
}
}
