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
            Console.WriteLine(ch);
			switch (ch) // special RegEx characters: ( ) + * |
			{
				case '(':
					if (orStarted)
					{
						bracketOpen = true;
					}
                    break;
				case ')':
					bracketOpen = false;
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
					mOrEnd = mCurrentNodeNumber;

					mCurrentNodeNumber++;
					tempTransition = new Transition(Alphabet.Epsylon, "" + previousNodeNumber, "" + mOrEnd);
					List<Transition> preTransitions = result.FindAll(x => x.from == tempTransition.from && x.to == tempTransition.to);
					if (preTransitions.Count > 0)
					{
						foreach (Transition tr in preTransitions)
						{
							result.Remove(tr);
							result.Add(new Transition(tr.label, "" + mOrEnd, "" + mCurrentNodeNumber));
						}
					}
					preTransitions = result.FindAll(x => x.from == tempTransition.to && x.to == tempTransition.from);
					if (preTransitions.Count > 0)
					{
						foreach (Transition tr in preTransitions)
						{
							result.Remove(tr);
							result.Add(new Transition(tr.label, "" + mCurrentNodeNumber, "" + mOrEnd));
						}
					}
					mOrEnd = mCurrentNodeNumber;
					result.Add(tempTransition);
					mCurrentNodeNumber++;
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
		int tempLength = 0;
		for (int i = regEx.Length -1; i > 0; --i )
		{
			if (regEx[i] == ')')
			{
				tempLength = i + 1;
			}
		}
		if (tempLength > regEx.Length)
		{
			length = regEx.Length;
			return regexToTransitions(regEx.Substring(0, regEx.Length), previousNodeNumber);
		}
		else
		{
			length = tempLength;
			return regexToTransitions(regEx.Substring(0, tempLength), previousNodeNumber);
		}
	}

#endregion
}
}
