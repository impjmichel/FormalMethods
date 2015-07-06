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
		if (list.Count > 0)
		{
			foreach (string str in list.Values)
			{
				result += str + ".";
			}
			result.Remove(result.Length - 1); // removing the last comma
			return result;
		}
		return null;
		
	}
	/// <summary>
	/// method to create a single Comma Seperated Value string from a Sorted Set
	/// </summary>
	public static string toCSV(SortedSet<string> set)
	{
		string result = "";
		for (int i = 0; i < set.Count; ++i)
		{
			result += set.ElementAt<string>(i);
			if (i < set.Count - 1)
			{
				result += ".";
			}
		}
		return result;
	}

	/// <summary>
	/// method to create a Sorted List from a Comma Seperated Value string
	/// </summary>
	public static SortedList<string, string> toSortedList(string csv)
	{
		string[] result = csv.Split(new char[] { ',', ' ', '\t', '\r', '\n', '.' }, StringSplitOptions.RemoveEmptyEntries);
		SortedList<string, string> list = new SortedList<string, string>();
		foreach (string str in result)
		{
			if (!list.ContainsKey(str))
			{
				list.Add(str, str);
			}
		}
		return list;
	}
	/// <summary>
	/// method to create a Sorted Set from a Comma Seperated Value string
	/// </summary>
	public static SortedSet<string> toSet(string csv)
	{
		string[] result = csv.Split(new char[] { ',', ' ', '\t', '\r', '\n', '.' }, StringSplitOptions.RemoveEmptyEntries);
		SortedSet<string> set = new SortedSet<string>();
		set.UnionWith(result);
		return set;
	}

	/// <summary>
	/// checks if it's true, if false throws Exception.
	/// </summary>
	public static void Assert(bool assertion)
	{
		Assert(assertion, "");
	}
	/// <summary>
	/// checks if it's true, if false throws Exception with a message.
	/// </summary>
	public static void Assert(bool assertion, string message)
	{
		if (!assertion)
			throw new Exception(message);
	}
}


/* TODOs / ERRORs
 * 
 *	1)	RegExp.cs:
 *			regexToTransitions 
 *			case '('  gaat mis, hier gebeuren rare dingen!
 *			
 *          //------------------------------------------------------------------------------------------------------
 *          //@JM ik heb wat commentaar in de RegExp gezet vanaf lijn 61
 *          //------------------------------------------------------------------------------------------------------
 * 
 *	2)	NDFA.cs:
 *			toDFA
 *				-> Automat.cs
 *						getAllEpsylonTransitions
 *						gaat out of bounds oid, raar shit
 *	
 *	3) Form1.cs:
 *	alleen als je echt, echt, echt niets anders meer te doen hebt
 *		uitbreiden...
 *			misschien iets doen aan naamgeving van die textboxes/buttons... 
 * 
 *	---STILL MISSING---
 *		-	NDFA / DFA  constructors for
 *			-	starts with XYZ
 *			-	contains XYZ
 *			-	ends with XYZ
 *		-	unit tests etc
 *		
 *	---WEIRD SHIT---
 *		-	graphViz will alleen letters, geen tekens :<
 * 
 */


}
