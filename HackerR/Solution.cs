using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerR
{
	class Solution
	{
		/*
		public static void Main(String[] args)
		{
			int input = Convert.ToInt32(Console.ReadLine());

			Stack<int> stack = new Stack<int>();

			String binaryNumber = null;

			while (input > 0)
			{
				int remainder = input % 2;
				input = input / 2;

				stack.Push(remainder);
			}

			while (stack.Count != 0)
			{
				binaryNumber = binaryNumber + stack.Pop();
			}

			String[] split = binaryNumber.Split('0');
			Array.Sort(split);
			int maxLength = split[split.Length - 1].Length;


			double decimalNumber = 0;

			for (int j = 0; j < maxLength; j++)
			{
				decimalNumber = decimalNumber + Math.Pow(2,j);
			}

			Console.WriteLine(decimalNumber);

			Console.ReadLine();       
		}

		public static void Main(String[] args)
		{

			int[][] arr = new int[6][];
			
			for (int arr_i = 0; arr_i < 6; arr_i++)
			{
				string[] arr_temp = Console.ReadLine().Split(' ');
				arr[arr_i] = Array.ConvertAll(arr_temp, Int32.Parse);
			}

			int temp_sum = 0;
			int sum = 0;
			for (int i = 0; i+2 < 6; i++)
			{
				for (int j = 0; j+2 < 6; j++)
				{
					    temp_sum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2] +
							  arr[i + 1][j] + arr[i + 1][j + 1] + arr[i + 1][j + 2] +
							  arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];

					    
						if (temp_sum > sum)
						{
							sum = temp_sum;
						}
				}
			}

			System.Console.WriteLine(sum);

		}
		
		static void Main(string[] args)
		{
			Convert.ToInt32(Console.ReadLine());

			int[] a = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

			Difference d = new Difference(a);

			d.computeDifference();

			Console.Write(d.maximumDifference);

			Console.ReadKey();
		}
		 

		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			int p = 0;
			List<int> numberList = new List<int>();

			while (p<n)
			{
				string line  = Console.ReadLine();
				numberList.Add(int.Parse(line));
				p++;
			}

			/*
			string line;
			while ((line = Console.ReadLine()) != null && line != "")
			{
				numberList.Add(int.Parse(line));
			}
			 

			foreach(int number in numberList)
			{
				bool isPrime = false;

				for(int i = 2; i <= Math.Floor(Math.Sqrt(number)); i++)
				{
					if (number % i == 0)
					{
						isPrime = true;
						break;
					}
				}
				if ((isPrime == true)||(number == 1))
				{
					Console.WriteLine("Not prime");
				}
				else if ((isPrime == false) || (number == 2))
				{
					Console.WriteLine("Prime");
				}
			}

			Console.ReadKey();

		}
		
          * */
		/* static void Main(String[] args) {
			int n = Convert.ToInt32(Console.ReadLine());
			string[] a_temp = Console.ReadLine().Split(' ');
			int[] a = Array.ConvertAll(a_temp,Int32.Parse);

			int totalNumberOfSwaps = 0;
			for (int i = 0; i < n; i++)
			{
				// Track number of elements swapped during a single array traversal
				int numberOfSwaps = 0;

				for (int j = 0; j < n - 1; j++)
				{
					int temp = a[j];
					// Swap adjacent elements if they are in decreasing order
					if (a[j] > a[j + 1])
					{
						temp = a[j+1];
						a[j + 1] = a[j];
						a[j] = temp;
						numberOfSwaps++;
					}
				}

				// If no elements were swapped during a traversal, array is sorted
				if (numberOfSwaps == 0)
				{
					break;
				}
				totalNumberOfSwaps = totalNumberOfSwaps + numberOfSwaps;
			}

			Console.WriteLine("Array is sorted in " + totalNumberOfSwaps + " swaps");
			Console.WriteLine("First Element " + a[0]);
			Console.WriteLine("Last Element " + a[n-1]);

			Console.ReadKey();
		}*/

		//Write your code here    

		Stack<char> s = new Stack<char>();
		Queue<char> q = new Queue<char>();


		public void pushCharacter(char c)
		{
			s.Push(c);
		}

		public char popCharacter()
		{
			return s.Pop();
		}

		public void enqueueCharacter(char c)
		{
			q.Enqueue(c);
		}

		public char dequeueCharacter()
		{
			return q.Dequeue();
		}
	}
}
