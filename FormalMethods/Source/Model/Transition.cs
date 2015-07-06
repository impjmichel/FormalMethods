using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
public class Transition : IComparable<Transition>
{
	private string mFrom;
	private string mTo;
	private char mLabel;

	public string from
	{
		get { return mFrom; }
		set { mFrom = value; }
	}
	public string to
	{
		get { return mTo; }
		set { mTo = value; }
	}
	public char label
	{
		get { return mLabel; }
	}

	/// <summary>
	/// constructor with label
	/// </summary>
	public Transition(char label)
	{
		mLabel = label;
	}
	/// <summary>
	/// constructor with label and from parent
	/// </summary>
	public Transition(char label, string from)
	{
		mLabel = label;
		mFrom = from;
	}
	/// <summary>
	/// constructor with label, from parent and to child
	/// </summary>
	public Transition(char label, string from, string to)
	{
		mLabel = label;
		mFrom = from;
		mTo = to;
	}

	public int CompareTo(Transition other)
	{
		if (other.label == mLabel)
		{
			if (other.from == mFrom)
			{
				return mTo.CompareTo(other.to);
			}
			else
			{
				return mFrom.CompareTo(other.from);
			}
		}
		else
		{
			return mLabel.CompareTo(other.label);
		}
		
	}
}
}
