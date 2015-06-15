using System;
using System.Collections.Generic;

namespace Models
{
/// <summary>
/// static class to call utility methods
/// </summary>
static class Util
{
	public static NDFA reverse(DFA dfa)
	{
		NDFA result = new NDFA();
		foreach (Node<String> node in dfa.nodes)
		{
			Node<List<String>> newNode = new Node<List<String>>(node.name);
			newNode.startNode = node.endNode;
			newNode.endNode = node.startNode;
			newNode.nextNodes = toListDictionary(node.previousNodes);
			newNode.previousNodes = toListDictionary(node.nextNodes);
			result.addNode(newNode);
		}
		return result;
	}

	public static NDFA reverse(NDFA ndfa)
	{
		NDFA result = new NDFA();
		foreach (Node<List<String>> node in ndfa.nodes)
		{
			Node<List<String>> newNode = new Node<List<String>>(node.name);
			newNode.startNode = node.endNode;
			newNode.endNode = node.startNode;
			newNode.nextNodes = node.previousNodes;
			newNode.previousNodes = node.nextNodes;
			result.addNode(newNode);
		}
		return result;
	}

	public static DFA toDFA(NDFA ndfa)
	{
		DFA result = new DFA();
		return result;
	}

	public static NDFA toNDFA(DFA dfa)
	{
		NDFA result = new NDFA();
		result.nodes = toListNodeList(dfa.nodes);
		return result;
	}

	/// <summary>
	/// Minimalizing with the reverse method
	/// </summary>
	public static DFA minimalizeDFA(DFA dfa)
	{
		return toDFA(reverse(toDFA(reverse(dfa))));
	}


	private static Dictionary<char,List<String>> toListDictionary(Dictionary<char,String> dictionary)
	{
		Dictionary<char, List<String>> result = new Dictionary<char, List<String>>();
		foreach(var pair in dictionary)
		{
			List<String> list = new List<string>(){pair.Value};
			result.Add(pair.Key, list);
		}
		return result;
	}

	private static List<Node<List<String>>> toListNodeList(List<Node<String>> list)
	{
		List<Node<List<String>>> result = new List<Node<List<String>>>();
		foreach (Node<String> tempNode in list)
		{
			Node<List<String>> node = new Node<List<String>>(tempNode.name);
			node.endNode = tempNode.endNode;
			node.startNode = tempNode.startNode;
			node.nextNodes = toListDictionary(tempNode.nextNodes);
			node.previousNodes = toListDictionary(tempNode.previousNodes);
		}
		return result;
	}
}
}
