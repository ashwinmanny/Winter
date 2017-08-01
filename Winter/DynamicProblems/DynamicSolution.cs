using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter.DynamicProblems
{
	class DynamicSolution
	{
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
	}
}
