using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
public static class Util
{
	/// <summary>
	/// method to create a single Comma Seperated Value string from a list
	/// </summary>
	public static string toCSV(SortedList<string, string> list)
	{
		string result = "";
		foreach (string str in list.Values)
		{
			result += str + ",";
		}
		result.Remove(result.Length - 1); // removing the last comma
		return result;
	}
	/// <summary>
	/// method to create a single Comma Seperated Value string from a Sorted Set
	/// </summary>
	public static string toCSV(SortedSet<string> set)
	{
		string result = "";
		foreach (string str in set)
		{
			result += str + ",";
		}
		result.Remove(result.Length - 1); // removing the last comma
		return result;
	}

	/// <summary>
	/// method to create a Sorted List from a Comma Seperated Value string
	/// </summary>
	public static SortedList<string, string> toSortedList(string csv)
	{
		string[] result = csv.Split(new char[] { ',', ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
		SortedList<string, string> list = new SortedList<string, string>();
		foreach (string str in result)
		{
			list.Add(str, str);
		}
		return list;
	}
	/// <summary>
	/// method to create a Sorted Set from a Comma Seperated Value string
	/// </summary>
	public static SortedSet<string> toSet(string csv)
	{
		string[] result = csv.Split(new char[] { ',', ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
		SortedSet<string> set = new SortedSet<string>();
		set.UnionWith(result);
		return set;
	}

}
}
