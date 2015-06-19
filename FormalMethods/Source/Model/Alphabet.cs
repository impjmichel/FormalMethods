using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
public class Alphabet
{
	private SortedSet<char> mCharacters;
	public const char Epsylon = 'y';

	public SortedSet<char> characters
	{
		get { return mCharacters; }
	}

	/// <summary>
	/// constructor with a comma seperated value input
	/// </summary>
	public Alphabet(string csvInput)
	{
		mCharacters = new SortedSet<char>();
		string[] values = csvInput.Split(new char[] {',', ' ', '\t', '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
		foreach(string str in values)
		{
			if (str[0] != Epsylon)
				mCharacters.Add(str[0]);
		}
	}
}
}
