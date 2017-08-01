using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRCrackingTheCodingI
{
	class TrieNode
	{
		public char Character;
		public Dictionary<char, TrieNode> Children;
		public Boolean IsEndOfWord;

		public TrieNode(char ch)
		{
			this.Character = ch;
			this.Children = new Dictionary<char, TrieNode>();
			this.IsEndOfWord = false;
		}
	}

	class Trie
	{
		public TrieNode root { get; set; }

		public Trie()
		{
			root = new TrieNode(' ');
		}

		public void add(String word)
		{
			TrieNode current = root;
			for (int i = 0; i < word.Length; i++)
			{
				char ch = word[i];

				TrieNode node;

				if (current.Children.ContainsKey(ch))
				{
					node = current.Children[ch];
				}
				else
				{
					node = new TrieNode(ch);
					current.Children.Add(ch, node);
				}

				current = node;
			}
			current.IsEndOfWord = true;
		}

		public bool find(string word)
		{
			TrieNode current = root;
			for (int i = 0; i < word.Length; i++)
			{
				char ch = word[i];

				TrieNode node;

				if (current.Children.ContainsKey(ch))
				{
					node = current.Children[ch];
				}
				else
				{
					return false;
				}

				current = node;
			}

			if (current.IsEndOfWord == true)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public int GetWords(string prefix)
		{
			if (prefix == null)
			{
				return 0;
			}
			// Empty list if no prefix match
			var words = new List<string>();
			var buffer = new StringBuilder();
			buffer.Append(prefix);
			GetWords(GetTrieNode(prefix), words, buffer);
			return words.Count;

		}

		/// <summary>
		/// Get the equivalent TrieNode in the Trie for given prefix. 
		/// If prefix not present, then return null.
		/// </summary>
		private TrieNode GetTrieNode(string prefix)
		{
			var trieNode = root;
			foreach (var prefixChar in prefix)
			{
				if (trieNode.Children.ContainsKey(prefixChar))
				{
					trieNode = trieNode.Children[prefixChar];
				}
				else
				{
					trieNode = null;
					break;
				}
			}
			return trieNode;
		}

		/// <summary>
		/// Recursive method to get all the words starting from given TrieNode.
		/// </summary>
		private void GetWords(TrieNode trieNode, ICollection<string> words,
			StringBuilder buffer)
		{
			if (trieNode == null)
			{
				return;
			}
			if (trieNode.IsEndOfWord)
			{
				words.Add(buffer.ToString());
			}
			foreach (var child in trieNode.Children.Values)
			{
				buffer.Append(child.Character);
				GetWords(child, words, buffer);
				// Remove recent character
				buffer.Length--;
			}
		}


	}
}
