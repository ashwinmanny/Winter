using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRCrackingTheCodingI
{
	class Program
	{
		static void Main(string[] args)
		{
			/**Arrays: Left rotation**
			string[] tokens_n = Console.ReadLine().Split(' ');
			int n = Convert.ToInt32(tokens_n[0]);
			int k = Convert.ToInt32(tokens_n[1]);
			string[] a_temp = Console.ReadLine().Split(' ');
			int[] a = Array.ConvertAll(a_temp, Int32.Parse);

			int[] o = RotateLeftArray(a, k);
			Console.WriteLine(string.Join(" ", o));
			Console.ReadKey();
			*/

			/** Anagram **

			string a1 = Console.ReadLine();
			string b1 = Console.ReadLine();

			AnagramDifference(a1, b1);

			Console.ReadKey();
			 * */

			/** Ransom note *
			string[] tokens_m = Console.ReadLine().Split(' ');
			int m = Convert.ToInt32(tokens_m[0]);
			int n = Convert.ToInt32(tokens_m[1]);
			string[] magazine = Console.ReadLine().Split(' ');
			string[] ransom = Console.ReadLine().Split(' ');

			Console.WriteLine(RansomNote(magazine, ransom));
			Console.ReadKey();
			*/

			/**Stacks: Balanced Brackets*
			int t = Convert.ToInt32(Console.ReadLine());
			for (int a0 = 0; a0 < t; a0++)
			{
				string expression = Console.ReadLine();
				string output = ValidParantheses(expression);

				Console.WriteLine(output);
			}

			Console.ReadKey();
			 **/

			/**** Queues: A Tale of Two Stacks **
			// Simple Stack
			// MyStack myStack = new MyStack(5);

			// myStack.Push(10);
			// myStack.Push(14);
			// myStack.Push(35);
			// myStack.Pop();
			// myStack.Pop();

			// myStack.Display();

			//For queue implemenation using 2 stacks (Inefficient but correct) 
	 
			string[] tokens_m = Console.ReadLine().Split(' ');

			MyQueue myQueue = new MyQueue();


			for (int i = 0; i <= Convert.ToInt32(tokens_m[0]); i++)
			{
				string[] tokens_n = Console.ReadLine().Split(' ');

				if ((Convert.ToInt32(tokens_n[0]) == 1) || (Convert.ToInt32(tokens_n[0]) == 2) || (Convert.ToInt32(tokens_n[0]) == 3))
				{
					if (Convert.ToInt32(tokens_n[0]) == 1)

					{
						myQueue.Enqueue(Convert.ToInt32(tokens_n[1]));
					}
					else if (Convert.ToInt32(tokens_n[0]) == 2)
					{
						myQueue.Dequeue();
					}
					else
					{
						myQueue.Peek();
					}
				}
				else
				{
				    Console.WriteLine("Invalid input");

					if(!(i == 0))
					{
						i--;
					}
				}	
			}
			*/

			/**Linked Lists: Detect a Cycle*

			LinkedNode input = new LinkedNode();

			Boolean output = hasCycle(input);

			Console.ReadKey();
			*/

			/**Trees: Is This a Binary Search Tree?

			Node input = new Node(4);
			Node two = new Node(2);
			Node six = new Node(6);
			Node one = new Node(1);
			Node three = new Node(3);
			Node five = new Node(5);
			Node seven = new Node(7);

			input.left = two;
			input.right = six;

			two.left = one;
			two.right = three;


			six.left = five;
			six.right = seven;


			Boolean output =  checkBST(input);

			Console.WriteLine(output);

			Console.ReadKey();
			*/
			

			/** Heaps: Find the Running Median (Inefficient but correct) *
			
			int n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];
			for (int a_i = 0; a_i < n; a_i++)
			{
				a[a_i] = Convert.ToInt32(Console.ReadLine());
			}

			RunningMedian(a, n);
			*/

			/** Tries: Contacts (Inefficient but correct) **
			Trie t = new Trie();
			int n = Convert.ToInt32(Console.ReadLine());
			List<int> outputList = new List<int>();

			for (int a0 = 0; a0 < n; a0++)
			{
				string[] tokens_op = Console.ReadLine().Split(' ');
				string op = tokens_op[0];
				string contact = tokens_op[1];

				
				if(op == "add")
				{
					t.add(contact);
				}
				if (op == "find")
				{
					int k = t.GetWords(contact);
					outputList.Add(k);
				}
			}

			foreach (int m in outputList)
			{
				Console.WriteLine(m);
			}
			**/


			/** Sorting: Bubble Sort *
			int n = Convert.ToInt32(Console.ReadLine());
			string[] a_temp = Console.ReadLine().Split(' ');
			int[] a = Array.ConvertAll(a_temp, Int32.Parse);

			BubbleSort(a, n);
			*/

			/** Sorting: Comparer
            int n = Convert.ToInt32(Console.ReadLine());

			Player[] player = new Player[n];
			Checker checker = new Checker();
        
			for(int i = 0; i < n; i++){
				string name = Console.ReadLine();
				int score = Convert.ToInt32(Console.ReadLine());
				player[i] = new Player(name, score);
			}
     
			Array.Sort(player, checker);
			for(int i = 0; i < player.Length; i++){
				Console.WriteLine("{0} {1}", player[i].name, player[i].score);
			}
			 */

			/** Merge Sort: Counting Inversion 

			//int t = Convert.ToInt32(Console.ReadLine());
			int t = 1;

			for (int a0 = 0; a0 < t; a0++)
			{
				//int n = Convert.ToInt32(Console.ReadLine());
				int n = 95059;
				//string[] arr_temp = Console.ReadLine().Split(' ');
				string[] lines = System.IO.File.ReadAllLines(@"C:\Users\amanny\Documents\Visual Studio 2012\Projects\Winter\TestInput1.txt");
				string[] arr_temp = lines[0].Split(' ');

				int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
				MergeSortA(arr);
				Console.WriteLine(counter);
				counter = 0;
			}
			Console.ReadKey();
			*/

			/** Binary Search: Ice Cream Parlor 
			int t = Convert.ToInt32(Console.ReadLine());
			for (int a0 = 0; a0 < t; a0++)
			{
				int m = Convert.ToInt32(Console.ReadLine());
				int n = Convert.ToInt32(Console.ReadLine());
				string[] a_temp = Console.ReadLine().Split(' ');
				int[] a = Array.ConvertAll(a_temp, Int32.Parse);

				PrintIceCreamIdCode(a, m);
			    
			}
			*/

			/** DFS: Connected Cell in a Grid 
			int n = Convert.ToInt32(Console.ReadLine());
			int m = Convert.ToInt32(Console.ReadLine());
			int[][] grid = new int[n][];
			for (int grid_i = 0; grid_i < n; grid_i++)
			{
				string[] grid_temp = Console.ReadLine().Split(' ');
				grid[grid_i] = Array.ConvertAll(grid_temp, Int32.Parse);

			}

			GetConnectedCellInAGrid(grid);
			*/

			/** BFS: Shortest Reach in a Graph*

			//string[] lines = System.IO.File.ReadAllLines(@"C:\Users\amanny\Documents\Visual Studio 2012\Projects\Winter\TestInput1.txt");

			int q = Convert.ToInt32(Console.ReadLine());
			//int q = 1;

			for (int i = 0; i < q; i++)
			{
				List<GenericNodeBFS> list = new List<GenericNodeBFS>();

				string[] temp = Console.ReadLine().Split(' ');
				int n = Convert.ToInt32(temp[0]);
				int m = Convert.ToInt32(temp[1]);

				//int n = 70;
				//int m = 1988;

				for (int k = 1; k <= n; k++)
				{
					list.Add(new GenericNodeBFS(k));
				}

				for (int j = 0; j < m; j++)
				{
					string[] nodes_temp = Console.ReadLine().Split(' ');
					//string[] nodes_temp = lines[j].Split(' ');

					int[] nodes = Array.ConvertAll(nodes_temp, Int32.Parse);

					list.Find(x=>x.data == nodes[0]).hasNeigbour(list.Find(x=>x.data == nodes[1]));

				}

				int sourceNode = Convert.ToInt32(Console.ReadLine());
				//int sourceNode = 16;

				BFSShortestReachInAGraph(list, sourceNode);

			}
			*/


			/** Time Complexity: Primality
		    
			int p = Convert.ToInt32(Console.ReadLine());
			for (int a0 = 0; a0 < p; a0++)
			{
				int n = Convert.ToInt32(Console.ReadLine());
				PrimeNumberValidation(n);
			}
		    
			*/

		   /** Recursion: Davis' Staircase
		   int s = Convert.ToInt32(Console.ReadLine());
		   for (int a0 = 0; a0 < s; a0++)
		   {
			  int n = Convert.ToInt32(Console.ReadLine());

			  int a = Staircase(n);
		   }
		   */

		   /** DP: Coin Change - (Now working) **
		   string[] tokens_n = Console.ReadLine().Split(' ');
		   int n = Convert.ToInt32(tokens_n[0]);
		   int m = Convert.ToInt32(tokens_n[1]);
		   string[] coins_temp = Console.ReadLine().Split(' ');
		   int[] coins = Array.ConvertAll(coins_temp, Int32.Parse);

		   long k = MakeChange(n, coins);
		   Console.WriteLine(k);
		    */


		   Console.ReadKey();

		}


		// DP: Coin Change
		private static long MakeChange(int n, int[] coins)
		{
			//return MakeChangeWays(n,coins,0);
			return MakeChangeWaysMemoization(n, coins, 0, new Dictionary<string,long>());

		}

		private static long MakeChangeWays(int money, int[] coins, int index)
		{
			if (money == 0)
			{
				return 1;
			}

			if (index >= coins.Length)
			{
				//Console.WriteLine("End of game");
				return 0;
			}

			int amountWithCoins = 0;
			long ways = 0;

			while (amountWithCoins <= money)
			{
				int remaining = money - amountWithCoins;

				//Console.WriteLine("MakeChangeWays(" + remaining + ",coins," + (index + 1) + ")");
				ways = ways + MakeChangeWays(remaining, coins, index+1);
				amountWithCoins = amountWithCoins + coins[index];
				//Console.WriteLine("amountWithCoins = {0}, coins = {1}", amountWithCoins, coins[index]);
			}

			//Console.WriteLine("Ways {0}", ways);
			return ways;
		}

		private static long MakeChangeWaysMemoization(int money, int[] coins, int index, Dictionary<string, long> memo)
		{
			if (money == 0)
			{
				return 1;
			}

			if (index >= coins.Length)
			{
				return 0;
			}

			string key = money.ToString() + '-' + index.ToString();

			if (memo.ContainsKey(key))
			{
				return memo[key];
			}

			int amountWithCoins = 0;
			long ways = 0;

			while (amountWithCoins <= money)
			{
				int remaining = money - amountWithCoins;
				ways = ways + MakeChangeWaysMemoization(remaining, coins, index + 1, memo);
				amountWithCoins = amountWithCoins + coins[index];
			}

			memo.Add(key, ways);

			return ways;
		}

		// Recursion: Davis' Staircase
		private static int Staircase(int n)
		{
			/* recursive way
			if (n == 0)
			{
				return 1;
			}
			if (n == 1)
			{
				return 1;
			}
			if (n == 2)
			{
				return 2;
			}

			return Staircase(n - 1) + Staircase(n - 2) + Staircase(n - 3);
			*/

			// dynamic way - better than recursive
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

		// Time Complexity: Primality
		private static void PrimeNumberValidation(int n)
		{
			bool isPrime = false;

			for (int i = 2; i <= Math.Floor(Math.Sqrt(n)); i++)
			{
				if (n % i == 0)
				{
					isPrime = true;
					break;
				}
			}
			if ((isPrime == true) || (n == 1))
			{
				Console.WriteLine("Not prime");
			}
			else if ((isPrime == false) || (n == 2))
			{
				Console.WriteLine("Prime");
			}
		}

		// BFS: Shortest Reach in a Graph
		private static void BFSShortestReachInAGraph(List<GenericNodeBFS> list, int sourceNode)
		{
			int[] shortestDistance = new int[list.Count];
			for (int i = 0; i < shortestDistance.Length; i++ )
			{
				shortestDistance[i] = -1; //distance
			}

			foreach (GenericNodeBFS item in list)
			{
				if (item.data == sourceNode)
				{
					findDistances(item, shortestDistance);
					break;
				}
			}

			for (int i = 0; i < shortestDistance.Length; i++)
			{
				if (i != (sourceNode - 1))
				{
					Console.Write("{0} ", shortestDistance[i]);
				}

			}
			Console.WriteLine();

		}

		private static void findDistances(GenericNodeBFS start, int[] shortestDistance)
		{
			Queue<GenericNodeBFS> queue = new Queue<GenericNodeBFS>();

			queue.Enqueue(start);

			while (queue.Count != 0)
			{
				GenericNodeBFS current = queue.Dequeue();

				foreach (GenericNodeBFS item in current.adjacent)
				{
					if (item.visted == false)
					{
						shortestDistance[item.data - 1] = shortestDistance[current.data - 1] == -1 ? shortestDistance[current.data - 1] + 7: shortestDistance[current.data - 1] + 6;
						item.visted = true;
						queue.Enqueue(item);
					}
				}
			}
		}

		// DFS: Connected Cell in a Grid
		static public int count;
		static public int max;

		private static void GetConnectedCellInAGrid(int[][] grid)
		{

			bool[][] visited = new bool[grid.Length][];

			for (int i = 0; i < visited.Length; i++)
			{
				visited[i] = new bool[grid[i].Length];
			}

			for (int i = 0; i < grid.Length; i++)
			{
				for (int j = 0; j < grid[i].Length; j++)
				{
					if(grid[i][j] == 1)
					{
						if (visited[i][j] == false)
						{
							DFSForConnectedCellInGrid(grid, visited, i, j);
							count=0;
						}
					}

				}
			}
			Console.WriteLine(max);
		}

		private static void DFSForConnectedCellInGrid(int[][] grid, bool[][] visited, int i, int j)
		{
			visited[i][j] = true;

			int row = grid.Length;
			int col = grid[0].Length;
			visited[i][j] = true;
			count++;

			if (count > max)
			{
				max = count;
			}

			if (i < row - 1 && !visited[i + 1][j] && grid[i + 1][j] == 1)
			{
				DFSForConnectedCellInGrid(grid, visited, i + 1, j);
			}
			if (i < row - 1 && j < col - 1 && !visited[i + 1][j + 1] && grid[i + 1][j + 1] == 1)
			{
				DFSForConnectedCellInGrid(grid, visited, i + 1, j + 1);
			}
			if (i < row - 1 && j > 0 && !visited[i + 1][j - 1] && grid[i + 1][j - 1] == 1)
			{
				DFSForConnectedCellInGrid(grid, visited, i + 1, j - 1);
			}
			if (j < col - 1 && !visited[i][j + 1] && grid[i][j + 1] == 1)
			{
				DFSForConnectedCellInGrid(grid, visited, i, j + 1);
			}
			if (j > 0 && !visited[i][j - 1] && grid[i][j - 1] == 1)
			{
				DFSForConnectedCellInGrid(grid, visited, i, j - 1);
			}
			if (i > 0 && !visited[i - 1][j] && grid[i - 1][j] == 1)
			{
				DFSForConnectedCellInGrid(grid, visited, i - 1, j);
			}
			if (i > 0 && j > 0 && !visited[i - 1][j - 1] && grid[i - 1][j - 1] == 1)
			{
				DFSForConnectedCellInGrid(grid, visited, i - 1, j - 1);
			}
			if (i > 0 && j < col - 1 && !visited[i - 1][j + 1] && grid[i - 1][j + 1] == 1)
			{
				DFSForConnectedCellInGrid(grid, visited, i - 1, j + 1);
			}

		}

		// Binary Search: Ice Cream Parlor
		private static void PrintIceCreamIdCode(int[] a, int m)
		{
			IceCream[] icecream = new IceCream[a.Length];

			int i = 0;
			foreach (int item in a)
			{
				IceCream c = new IceCream(i, item);
				icecream[i] = c;
				i++;
			}

			IceCreamChecker iChecker = new IceCreamChecker();
			Array.Sort(icecream, iChecker);
			int index = -1;

			for (int j = 0; j < icecream.Length; j++)
			{
				IceCream smallNumber = icecream[j];
				int remaining = m - smallNumber.price;

				List<IceCream> listIceCream = icecream.ToList<IceCream>();

				listIceCream.RemoveAt(0);

				IceCream[] icecream2 = listIceCream.ToArray();

				index = IceCream.BinarySearch(icecream2, remaining);
				if (!(index < 0))
				{
					if (smallNumber.id < icecream2[index].id)
					{
						Console.WriteLine("{0} {1}", smallNumber.id + 1, icecream2[index].id + 1);
					}
					else
					{
						Console.WriteLine("{0} {1}", icecream2[index].id + 1, smallNumber.id + 1);
					}
					break;
				}
			}			

			if (index < 0)
			{
				Console.WriteLine("Not found");
			}
			
		}

		// Merge Sort: Counting Inversions

		private static void MergeSortA(int[] arr)
		{
			if (arr.Length < 2)
			{
				return;
			}

			int middle = (arr.Length) / 2;

			int[] leftArray = new int[middle];
			int[] rightArray = new int[arr.Length - middle];

			for (int i = 0; i < middle; i++)
			{
				leftArray[i] = arr[i];
			}

			for (int i = middle; i < arr.Length; i++)
			{
				rightArray[i - middle] = arr[i];
			}

			MergeSortA(leftArray);
			MergeSortA(rightArray);
			MergeHalves(leftArray, rightArray, arr);
		}

		static public long counter = 0;
		private static void MergeHalves(int[] leftArray, int[] rightArray, int[] temp)
		{
			int i = 0;
			int j = 0;
			int k = 0;
			int mid = temp.Length/2;

			while ((i < leftArray.Length) && (j < rightArray.Length))
			{
				if(leftArray[i] > rightArray[j])
				{
					temp[k] = rightArray[j];
					j++;
					counter = counter + (mid - i);
				}
				else
				{
					temp[k] = leftArray[i];
					i++;
				}
				k++;
			}

			while (i < leftArray.Length)
			{
					temp[k] = leftArray[i];
					i++;
					k++;
			}

			while (j < rightArray.Length)
			{
					temp[k] = rightArray[j];
					j++;
					k++;
			}

		}

		// Sorting: Bubble Sort
		private static void BubbleSort(int[] a, int n)
		{
			int numOfSwaps = 0;
			for (int i = 0; i < n; i++)
			{
				int initialNumOfSwapsforEachPass = numOfSwaps;
				for(int j = 0; j < n-1; j++)
				{ 
					if(a[j] > a[j+1])
					{
						int temp = a[j];
						a[j] = a[j+1];
						a[j+1] = temp;
						numOfSwaps++;
					}
				}

				if (initialNumOfSwapsforEachPass == numOfSwaps)
				{
					break;
				}
			}

			Console.WriteLine("Array is sorted in {0} swaps ", numOfSwaps);
			//foreach(int item in a)
			//{
			//	Console.Write("{0} ", item);
			//}
			//Console.WriteLine("");
			Console.WriteLine("First Element: {0} ", a[0]);
			Console.WriteLine("Last Element: {0} ", a[n-1]);
		}

		// Heaps: Find the Running Median (Inefficient)
		private static void RunningMedian(int[] a, int n)
		{
			for (int j = 0; j < n; j++)
			{
				List<Decimal> b = new List<Decimal>();

				for (int i = 0; i <= j; i++)
				{
					b.Add(Convert.ToDecimal(a[i]));
				}

				b.Sort();

				Decimal output;

				if (b.Count % 2 == 0)
				{
					output = (b[j / 2] + b[j / 2 + 1]) / 2;
					Console.WriteLine(string.Format("{0:F1}", output));
				}
				else
				{
					if (j == 0)
					{
						output = b[0];
					}
					else
					{
						output = b[j / 2];
					}

					Console.WriteLine(string.Format("{0:F1}", output));
				}
			}
		}
		

		// Stacks: Balanced Brackets
		private static string ValidParantheses(string expression)
		{
			Stack<char> stack = new Stack<char>();

			foreach (char c in expression)
			{
				switch (c)
				{
					case '{':
					case '(':
					case '[':
						stack.Push(c);
						break;
					case '}':
						if (stack.Any())
						{
							if (stack.Peek().ToString() == "{")
							{
								stack.Pop();
							}
							else
							{
								return "NO";
							}
						}
						else
						{
							return "NO";
						}
						break;
					case ')':
						if (stack.Any())
						{
							if (stack.Peek().ToString() == "(")
							{
								stack.Pop();
							}
							else
							{
								return "NO";
							}
						}
						else
						{
							return "NO";
						}
						break;
					case ']':
						if (stack.Any())
						{
							if (stack.Peek().ToString() == "[")
							{
								stack.Pop();
							}
							else
							{
								return "NO";
							}
						}
						else
						{
							return "NO";
						}
						break;

					default: return "NO";
				}

				if (stack.Count > 0)
				{
					return "NO";
				}
			}

			if (stack.Any())
			{
				return "NO";
			}
			else
			{
				return "YES";
			}
		}

		// Ransom Note
		static string RansomNote(string[] mags, string[] rans)
		{
			Array.Sort(mags);
			Array.Sort(rans);

			List<string> magList = mags.ToList();

			foreach (string ransom_w in rans)
			{
				if (!magList.Remove(ransom_w)) return "No";
			}

			return "Yes";
		}

		// Anagram difference
		private static void AnagramDifference(string a1, string b1)
		{
			int output = 0;
			int[] seen = new int[26];

			foreach (char c in a1)
			{
				seen[c - 'a']++;
			}

			foreach (char c in b1)
			{
				seen[c - 'a']--;
			}

			foreach (int i in seen)
			{
				output = output + Math.Abs(i);
			}

			Console.WriteLine("The anagram difference is {0}", output.ToString());
		}

		// Arrays: Left rotation
		static int[] RotateLeftArray(int[] input, int k)
		{
			int[] output = new int[input.Length];
			for (int i = 0; i < input.Length; i++)
			{
				if (i < k)
				{
					output[output.Length - k + i] = input[i];
				}
				else
				{
					output[i - k] = input[i];
				}
			}

			return output;
		}

		// Detect a cycle in a linked list
		static Boolean hasCycle(LinkedNode head)
		{
			LinkedNode fast = head;
			LinkedNode slow = head;
			if (head == null || head.next == null)
			{
				return false;
			}
			else
			{
				slow = head.next;
				fast = head.next.next;

				while (fast != null && fast.next != null)
				{
					fast = fast.next.next;
					slow = slow.next;
					if (fast == slow)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Trees: Is This a Binary Search Tree?
		static Boolean checkBST(Node root)
		{
			long min = long.MinValue;
			long max = long.MaxValue;

			return IsValidBST(root, min, max);
		
        }

		private static Boolean IsValidBST(Node root, long min, long max)
		{
			if (root == null)
			{
				return true;
			}

			if (root.data <= min || root.data >= max)
			{
				return false;
			}

			return IsValidBST(root.left, min, root.data) && IsValidBST(root.right, root.data, max);
		}

	}

	class Player
	{
		public String name;
		public int score;

		public Player(String name, int score)
		{
			this.name = name;
			this.score = score;
		}
	}

	// Sorting: Comparer
	class Checker : IComparer<Player>
	{
		public int Compare(Player x, Player y)
		{
			if (x.score == y.score)
			{
				return x.name.CompareTo(y.name);
			}
			else
			{
				return (x.score < y.score ? 1 : -1);
			}
		}
	}

	public class IceCream
	{
		public int id { get; set; }

		public int price { get; set; }

		public IceCream(int i, int p)
		{
			this.id = i;
			this.price = p;
		}

		internal static int BinarySearch(IceCream[] icecream, int remaining)
		{
			return BinarySearchRecursive(icecream, remaining, 0, icecream.Length-1);
		}

		private static int BinarySearchRecursive(IceCream[] icecream, int remaining, int left, int right)
		{
			if (left > right)
			{
				return -1;
			}

			int mid = left + ((right - left) / 2);

			if (remaining == icecream[mid].price)
			{
				return mid;
			}
			else if (remaining < icecream[mid].price)
			{
				return BinarySearchRecursive(icecream, remaining, left, mid - 1);
			}
			else
			{
				return BinarySearchRecursive(icecream, remaining, mid + 1, right);
			}
		}
	}

	class IceCreamChecker : IComparer<IceCream>
	{
		public int Compare(IceCream x, IceCream y)
		{
			if (x.price > y.price)
			{
				return 1;
			}
			else if (x.price < y.price)
			{
				return -1;
			}
			else
			{
				return 0;
			}
		}
	}

}

