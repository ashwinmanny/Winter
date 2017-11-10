using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter.DynamicProblems
{
	class DynamicSolution
	{
		public int fibonacciBottomUpDP(int p)
		{
			int[] memo = new int[p + 1];
			int i = 0;
			memo[0] = 0;
			memo[1] = 1;

			for (i = 2; i <= p; i++)
			{
				memo[i] = memo[i - 1] + memo[i - 2];
			}

			return memo[p];
		}

		public int fibonacciTopDownMemoized(int n, int[] memo)
		{
			if (n <= 2)
			{
				return 1;
			}
			else if (memo[n] != -1)
			{
				return memo[n];
			}
			else
			{
				memo[n] = fibonacciTopDownMemoized(n - 1, memo) + fibonacciTopDownMemoized(n - 2, memo);
			}
			return memo[n];
		}

		public bool IsSubsetSum(int[] a, int n, int sum)
		{
	
			bool[,] m = new bool[n+1,sum+1];

			// if subset is empty, we can't sum up to target
			for (int i = 0; i <= n; i++)
			{
				m[i,0] = true;
			}

			// if target is 0, then we can use empty set
			for (int i = 0; i <= sum; i++)
			{
				m[0, i] = true;
			}

			for (int i = 1; i <= n; i++)
			{
				for (int j = 1; j<= sum; j++)
				{
					// first copy the data data from the top
					m[i, j] = m[i - 1, j];

					//if m[i,j]==flase check if can be made
					if (m[i, j] == false && j >= a[i - 1])
					{
						m[i, j] = m[i, j] || m[i - 1, j - a[i-1]];
					}
				}
			}

			return m[a.Length,sum];
		}

		public int ClimbStairs(int n)
		{
			if (n < 0) return 0;
			else if (n == 0) return 1;
			else if (n == 1) return 1;
			else if (n == 2) return 2;

			int pren1 = 1;
			int pren2 = 1;
			int pren3 = 2;

			int cur = 0;

			for (int i = 3; i <= n; i++)
			{
				cur = pren1 + pren2 + pren3;
				pren1 = pren2;
				pren2 = pren3;
				pren3 = cur;
			}

			return cur;
		}

		public int KnapSack(int n, int c, int [] weight, int[] value)// n = no. of items, c = capacity 
		{
			int[,] K = new int[n+1, c+1];

			for(int i = 0; i <= n; i++)
			{
				for (int j = 0; j <= c; j++)
				{
					if ((i == 0) ||(j == 0))
					{
						K[i, j] = 0;
					}
					else if (j < weight[i]) // use i instead of i-1 if the weight array does not have empty 0 entry. Same applies for value array
					{
						K[i,j] = K[i - 1, j];
					}
					else
					{
						K[i, j] = Math.Max((value[i] + K[i - 1, j - weight[i]]), K[i - 1, j]);
					}
				}
			}
			return K[n,c];
		}

		public int Change(int p, int amount, int[] coins)
		{
			int[,] C = new int[p+1, amount+1];
			C[0, 0] = 1;

			for (int i = 1; i <= p; i++)
			{
				C[i, 0] = 1;
				for (int j = 1; j <= amount; j++)
				{
					if (j <= coins[i-1])
					{
						C[i,j] = C[i-1,j];
					}
					else
					{
						C[i, j] = C[i-1, j] + C[i, j - coins[i-1]];
					}
				}
			}

			return C[coins.Length,amount];
		}

		public int CoinChange(int[] coins, int amount)
		{
			int[,] K = new int[coins.Length+1,amount+1];

			for (int i = 0; i <= coins.Length; i++)
			{
				for (int j = 0; j <= amount; j++)
				{
					if (i == 0 || j == 0)
					{
						K[i, j] = 0;
					}
					else if (j < coins[i])
					{
						K[i, j] = K[i - 1, j];
					}
					else
					{
						K[i, j] = Math.Max(coins[i] + K[i - 1, j - coins[i]], K[i - 1, j]);
					}
				}
			}
			return 0;
		}

		public int FindIntegers(int num)
		{
           /* yet to undertsand and do*/
			return 0;
		}

		public int MinDistance(string word1, string word2)
		{
			var len1 = word1.Length;
			var len2 = word2.Length;
			var dp = new int[len1 + 1, len2 + 1];
			dp[0, 0] = 0;

			for (int i = 0; i < len1; i++)
			{
				dp[i + 1, 0] = i + 1;
			}
			for (int i = 0; i < len2; i++)
			{
				dp[0, i + 1] = i + 1;
			}

			for (int i = 0; i < len1; i++)
			{
				for (int j = 0; j < len2; j++)
				{
					if (word1[i] == word2[j])
					{
						dp[i + 1, j + 1] = dp[i, j];
					}
					else
					{
						dp[i + 1, j + 1] = Math.Min(Math.Min(dp[i, j], dp[i, j + 1]), dp[i + 1, j]) + 1;
					}
				}
			}

			return dp[len1, len2];
		}

		public bool WordBreak(string s, IList<string> wordDict)
		{
			if (s == null || wordDict == null)
			{
				return false;
			}

			bool[] dp = new bool[s.Length+1];

			dp[0] = true; //empty substring ""

			for (int i = 1; i < dp.Length; i++)
			{
				for (int j = 0; j < i; j++)
				{
					if (wordDict.Contains(s.Substring(j,i-j)) && dp[j]) //dp[k] = dp[0] + string[0 - k] in dict......dp[k-1] + string[(k-1) - k] in dict
					{
						dp[i] = true;
						break;
					}
				  
				}
			}

			return dp[s.Length];

		}

		public bool WordBreak2(string s, List<string> wordDict)
		{
			List<string> wordFound = new List<string>();

			List<string> wordFound2 = new List<string>();

			var dp2 = new List<List<string>>();
			for (int i = 0; i < s.Length + 1; i++)
			{
				dp2.Add(new List<string>());
			}

			bool[] dp = new bool[s.Length+1];

			dp[0] = true;

			for (int i = 1; i < dp.Length; i++)
			{
				for (int j = 0; j < i; j++)
				{
					if (wordDict.Contains(s.Substring(j, i - j)) && dp[j])
					{
						dp[i] = true;
						dp2[i].Add(s.Substring(j, i - j));
						wordFound.Add(s.Substring(j, i - j));
						break;
					}
				}
			}
		   
			Helper(wordFound, wordFound2, string.Empty);

			return dp[s.Length];
		}

		private void Helper(List<string> wordFound, List<string> res, string solution)
		{
			
		}

		public IList<IList<int>> AnySum(int[] nums, int target)
		{
			Array.Sort(nums);
			int k = 4;
			return kSum(nums, 0, k, target);
		}

		public IList<IList<int>> kSum(int[] nums, int start, int k, int target)
		{
			int len = nums.Length;
			IList<IList<int>> res = new List<IList<int>>();
			if (k == 2)
			{
				int left = start;
				int right = len - 1;
				while (left < right)
				{
					int sum = nums[left] + nums[right];
					if (sum == target)
					{
						res.Add((new List<int> { nums[left], nums[right] }));
						while (left < right && nums[left] == nums[left + 1])
						{
							left++;
						}
						while (left < right && nums[right] == nums[right - 1])
						{
							right--;
						}
						left++;
						right--;
					}
					else if (sum < target)
					{
						left++;
					}
					else right--;
				}
			}
			else
			{
				for (int i = start; i < len - k + 1; i++)
				{
					while (i > start && i < len - 1 && nums[i] == nums[i - 1]) 
					{ 
						i++; 
					}

					//recursion
					var temp = kSum(nums, i + 1, k - 1, target - nums[i]);
					
					
					foreach (var element in temp)
					{
						element.Add(nums[i]);
					}
					 
					foreach (var val in temp)
					{
						res.Add(val);
					}
				}
			}

			return res;
		}
	}
}
