using System;

namespace Models
{
class RegExp : RegBase
{
	private int mCurrentNodeNumber = 0;
	private int mOrEnd = 0;
	private bool orStarted = false;
	private bool orEnd = false;
	private bool bracketOpen = false;

	private string exp;

	public RegExp()
	{
	}
	public RegExp(string input)
	{
		exp = input;
	}

	public string getExp()
	{
		return exp;
	}

	public void setExp(string input)
	{
		exp = input;
	}

	public void toNDFA()
	{
		int length = exp.Length;


		for(int i = 0; i < length; i++)
		{
			Console.WriteLine(exp[i]);
		}
	}

	public string CreateGraphizString(string input, int previousNodeNumber = 0)
	{
		string result = "";
		bool ending = false;
		if (mCurrentNodeNumber == 0)
		{
			result += cInitRegGrammar + cStartingPoint + mCurrentNodeNumber + stop;
			ending = true; 
		}
		for (int i = 0; i < input.Length; ++i)
		{
			char ch = input[i];
			switch (ch)		//special RegEx characters:  ( ) + * |
			{
				case '(':
					if (orStarted)
					{
						bracketOpen = true;
					}
					// open bracket
					result += mCurrentNodeNumber + cTo;
					previousNodeNumber = mCurrentNodeNumber;
					mCurrentNodeNumber++;
					result += mCurrentNodeNumber + cEp + stop;
					string sub = input.Substring(i+1);
					int endOfBracket;
					result += HandleOpenBracket(sub, previousNodeNumber, out endOfBracket);
					i += endOfBracket;
					break;
				case ')':
					bracketOpen = false;
					result += mCurrentNodeNumber + cTo;
					mCurrentNodeNumber++;
					result += mCurrentNodeNumber + cEp + stop;
					if (orEnd)
					{
						result += mOrEnd + cTo + mCurrentNodeNumber + cEp + stop;
						orEnd = false;
						orStarted = false;
					}
					break;
				case '+':
					result += mCurrentNodeNumber + cTo + previousNodeNumber + cEp + stop;
					if (orEnd && !bracketOpen)
					{
						result += mCurrentNodeNumber + cTo;
						mCurrentNodeNumber++;
						result += mCurrentNodeNumber + cEp + stop;
						result += mOrEnd + cTo + mCurrentNodeNumber + cEp + stop;
						orEnd = false;
						orStarted = false;
					}
					break;
				case '*':
					result += mCurrentNodeNumber + cTo + previousNodeNumber + cEp + stop;
					result += previousNodeNumber + cTo + mCurrentNodeNumber + cEp + stop;
					if (orEnd && !bracketOpen)
					{
						result += mCurrentNodeNumber + cTo;
						mCurrentNodeNumber++;
						result += mCurrentNodeNumber + cEp + stop;
						result += mOrEnd + cTo + mCurrentNodeNumber + cEp + stop;
						orEnd = false;
						orStarted = false;
					}
					break;
				case '|':
					orStarted = true;
					mOrEnd = mCurrentNodeNumber + 1;
					result += mCurrentNodeNumber + cTo + mOrEnd + cEp + stop;
					mCurrentNodeNumber = mOrEnd + 1;
					break;
				default:
					previousNodeNumber = mCurrentNodeNumber;
					mCurrentNodeNumber++;
					result += previousNodeNumber + cTo + mCurrentNodeNumber;
					if (ch == 'a')
					{
						result += cA;
					}
					else if (ch == 'b')
					{
						result += cB;
					}
					result += stop;
					break;
			}
			if (orStarted && !orEnd)
			{
				result += previousNodeNumber + cTo + mCurrentNodeNumber + cEp + stop;
				orEnd = true;
			}
		}

		if (ending)
		{
			result += mCurrentNodeNumber + cEndingCircle;
			result += cEndRegGrammar;
			mCurrentNodeNumber = 0;
			mOrEnd = 0;
		}
		return result;
	}

	private string HandleOpenBracket(string input, int previousNodeNumber, out int length)
	{
		string result = "";
		length = 0;
		for (int i = input.Length -1; i > 0; --i )
		{
			if (input[i] == ')')
			{
				length = i + 1;
			}
		}
		result += CreateGraphizString(input.Substring(0, length), previousNodeNumber);
		return result;
	}
}
}
