using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter
{
	class StringSolution
	{
		public string ReverseString(string s)
		{
			char[] c = s.ToCharArray();

			Array.Reverse(c);

			string s2 = new string(c);

			return s2;
		}

		public string ReverseVowels(string s)
		{
			var strBuilder = new StringBuilder();

			for (int i = 0, j = s.Length - 1; i < s.Length; i++)
			{
				if ("aeiouAEIOU".IndexOf(s[i]) < 0)
				{
					strBuilder.Append(s[i]);
				}
				else
				{
					while (j >= 0 && "aeiouAEIOU".IndexOf(s[j]) < 0)
					{
						j--;
					}
					strBuilder.Append(s[j]);
					j--;
				}
			}
			return strBuilder.ToString();
		}

		public string ReverseWords(string s)
		{
			StringBuilder output = new StringBuilder();

			if (!String.IsNullOrWhiteSpace(s))
			{
				String[] list = s.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
				foreach (string l in list.Reverse())
				{
					output.Append(l);

					if (!(list.Reverse().Last() == l))
					{
						output.Append(' ');
					}
				}
			}
			else
			{
				output.Append("");
			}

			return output.ToString();
		}

		public bool isNumeric(string s)
		{
			int len = s.Length;
			int i = 0, e = len - 1;
			while (i <= e && Char.IsWhiteSpace(s[i]))
			{
				i++;
			}
			if (i > len - 1) return false;
			while (e >= i && Char.IsWhiteSpace(s[i]))
			{
				e--;
			}
			// skip leading +/-
			if (s[i] == '+' || s[i] == '-') i++;
			bool num = false; // is a digit
			bool dot = false; // is a '.'
			bool exp = false; // is a 'e'
			while (i <= e)
			{
				char c = s[i];
				if (Char.IsDigit(c))
				{
					num = true;
				}
				else if (c == '.')
				{
					if (exp || dot) return false;
					dot = true;
				}
				else if (c == 'e')
				{
					if (exp || num == false) return false;
					exp = true;
					num = false;
				}
				else if (c == '+' || c == '-')
				{
					if (s[i - 1] != 'e') return false;
				}
				else
				{
					return false;
				}
				i++;
			}
			return num;

		}

		public string ReturnLongestSubstringPalindrome(string s)
		{
			//Brute force

			Dictionary<string, int> dict = new Dictionary<string, int>();
			for (int i = 0; i < s.Length-1; i++)
			{
				string temp = s[i].ToString();
				for (int j = i+1; j < s.Length - 1; j++)
				{
					temp = temp + s[j];

					if (IsPalindrome(temp) && !dict.ContainsKey(temp))
					{
						dict.Add(temp, temp.Length);
					}

				}

			}

			var max = dict.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

			var min = dict.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;

			string output = max;

			return output;
		}

		public bool IsPalindrome(string s)
		{
			for (int i = 0, j = s.Length-1; i < j; i++, j--)
			{
				if (s[i] != s[j]){
					
					return false;
				}

			}
			return true;
		}

		public int LongestPalindrome(string s)
		{
			char[] chars  = s.ToCharArray();
			int[] lowerCount = new int[26];
			int[] upperCount = new int[26];
			int odds = 0;
			int n = s.Length ;

			// store frequency of occurrence of all letters (case-sensitive)
			for (int i = 0; i < n; i++)
			{
				if(chars[i] < 'a') 
				{
					upperCount[chars[i] - 'A']++;
				}
				else
				{
					int r = chars[i] - 'a';
					lowerCount[chars[i] - 'a']++;
				}

			}
			// Count how many letters are occcuring odd number of time
			for (int i = 0; i < 26; i++)
			{
				if (lowerCount[i] % 2 == 1)
				{
					odds++;
				}
				if (upperCount[i] % 2 == 1)
				{
					odds++;
				}

			}

			if(odds == 0)
			{
				return n;
			}
			else
			{
				return n-odds+1;
			}
		}

		public string ShortestPalindrome(string s)
		{
			string revString = new string(s.Reverse().ToArray());

			string proString = s + '#' + revString;

			int[] p = new int[proString.Length];

			//build KMP table
			//i -> suffix boundary
			//j -> prefix boundary
			for (int i = 1; i < proString.Length; i++)
			{
				//update prefix boundary
				int j = p[i - 1];

				//move to the last prefix boundary match
				while ((j > 0) && (proString[i] == proString[j]))
				{
					j = p[j-1];
				}

				//if prefix boundary matches suffix boundary, increase prefix length
				if(proString[i] == proString[j])
				{
					p[i] = j+1;
				}
			}

			return revString.Substring(0, s.Length - p[proString.Length - 1]) + s;
		}

		public int StrStrBruteForce(string haystack, string needle)
		{

			if (String.IsNullOrEmpty(needle))
			{
				return 0;
			}

			if (needle.Length > haystack.Length)
			{
				return -1;
			}


			for (int i = 0; i < haystack.Count(); i++)
			{
				int k = i;
				int j = 0;
				while (k < haystack.Length && needle[j] == haystack[k])
				{
					if (j == needle.Length - 1)
					{
						return k - j;
					}

					k++;
					j++;

				}

			}

			return -1;

		}

		public int StrStr(string haystack, string needle)
		{
			if (string.IsNullOrEmpty(needle)) return 0;
			var needleLength = needle.Length;
			for (int i = 0; i <= haystack.Length - needleLength; i++)
			{
				if (haystack.Substring(i, needleLength).Equals(needle))
					return i;
			}

			return -1;
		}

		// Valid Paranthesis
		public bool IsValid(string s)
		{
			var stack = new Stack();

			foreach (var ch in s)
			{
				switch (ch)
				{
					case '(':
					case '[':
					case '{':
						stack.Push(ch);
						break;
					case ')':
						if (!(stack.Count > 0)) return false;
						var top1 = stack.Pop();
						if (System.Convert.ToChar(top1) != '(') return false;
						break;
					case ']':
						if (!(stack.Count > 0)) return false;
						var top2 = stack.Pop();
						if (System.Convert.ToChar(top2) != '[') return false;
						break;
					case '}':
						if (!(stack.Count > 0)) return false;
						var top3 = stack.Pop();
						if (System.Convert.ToChar(top3) != '{') return false;
						break;
					default:
						return false;
				}
			}

			return !(stack.Count > 0); 

		}

		public int LengthLongestPath(string input)
		{
			//hashMap stores (level, the length of the path up to level level) 
			Dictionary<int, int> hashMap = new Dictionary<int, int>();
			hashMap.Add(0, 0);

			string[] a = input.Split('\n');

			int result = 0;
			foreach (string s in a)
			{
				int level = s.LastIndexOf('\t') + 1;
				int len = s.Length - level;

				if (s.Contains("."))
				{
					result = Math.Max(result, hashMap[level] + len);
				}
				else
				{
					if (hashMap.ContainsKey(level))
					{
						//we update the hashMap using hashMap.get(level) + len + 1 
						//because the current level is level+1, previous level is level, 
						//we +1 because the additional path separator char 
						hashMap[level + 1] = hashMap[level] + len + 1;
					}
				}

			}

			return result;
		}

		public string LicenseKeyFormatting(string S, int K)
			{
				int occurance = S.LastIndexOf("-") + 1;
				int len = S.Length - occurance;

				int shortLen = len % K;
				string newString = null;
				string result = null;

				for (int i = 0; i < S.Length; i++)
				{
					if (S[i] != '-')
					{
						newString = newString + S[i];
					}
				}

				char[] c1 = newString.ToCharArray();

				Array.Reverse(c1);

				string newString2 = new string(c1);

				for (int j = newString2.Length -1; j >= 0; j--)
				{

					if (((j + 1) % K == 0) && j != (newString2.Length -1))
					{
						result = result + "-";
					}

					result = result + newString2[j];
				}

				return result;

			}

		public string LicenseKeyFormatting2(string S, int K)
		{
			int occurance = S.LastIndexOf("-") + 1;
			int len = S.Length - occurance;

			int shortLen = len % K;
			string result = null;

			char[] c1 = S.ToCharArray();

			Array.Reverse(c1);

			string newString2 = new string(c1);

			int grouper = 1;

			for (int j = newString2.Length - 1; j >= 0; j--)
			{
				if (newString2[j] == '-')
				{
					continue;
				}
				else
				{
					result = result + newString2[j];
					if (j == 0)
					{
						continue;
					}
					if (grouper % K == 0)
					{
						result = result + "-";

					}
					grouper++;
				}
			}

			return result.ToUpper();

		}

		public void StringContentSeperator(String s)
		{
			StringBuilder st = new StringBuilder(s);

			List<string> array = new List<string>();
			
		}

		public static string firstRepeatingLetter(string s)
		{
			char[] sortedCharArray = s.ToCharArray();

			Array.Sort(sortedCharArray);

			string sortedString = new string(sortedCharArray);

			var set = new Dictionary<char, int>();

			for (int i = 0; i <= sortedString.Length - 1; i++)
			{
				char c = sortedString[i];

				if (set.ContainsKey(c))
				{
					return c.ToString();
				}
				else
				{
					set.Add(c, 1);
				}
			}

			return null;

		}

		public string findResultingDirectoryForCD(string currentDirectory,
		    string sequenceOfOperations) {

		    string[] splitDirectories = sequenceOfOperations.Split('|');

			for (int i = 0; i < splitDirectories.Length; i++) {
				if (splitDirectories[i].Equals("..")) {
					currentDirectory = currentDirectory.Substring(0,
							currentDirectory.LastIndexOf("/"));
				} else {
					currentDirectory = currentDirectory + "/" + splitDirectories[i];
				}
			}

			return currentDirectory;
	    }

	}
}
