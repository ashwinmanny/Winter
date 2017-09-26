using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winter.ArrayProblems;
using Winter.DFSProblems;
using Winter.DynamicProblems;
using Winter.LinkedListsProblems;
using Winter.MathProblems;
using Winter.Recursion;
using Winter.Searching;
using Winter.SortingProblems;
using Winter.StackProblems;

namespace Winter
{
	class Driver
	{
		public static void Main()
		{
			/********************************************************** BFS ***/
			/*
			BFS b = new BFS();
			Node root = b.BuildGraph();
			Console.WriteLine("Traverse\n------");

			b.Traverse(root);

			Console.WriteLine("\nSearch\n------");
			Node p = b.Search(root, 56);
			Console.WriteLine(p == null ? "Person not found" : p.data.ToString());
			p = b.Search(root, 80);
			Console.WriteLine(p == null ? "Person not found" : p.data.ToString());
		    Console.WriteLine(b.ToString());
			 * 
			*/

			/********************************************************** DFS **
			
			DFS b = new DFS();
			Node root = b.BuildGraph();
			Console.WriteLine("Traverse normal tree\n------");

			b.Traverse(root);

			DFS c = new DFS();
			BinaryTreeNode root2 = c.BuildBinaryTreeGraph();
			Console.WriteLine("Traverse binary tree\n------");

			c.BinaryTreeTraverse(root2);
			*/


			/****************Minimum Depth of Binary Tree******************

			DFS c = new DFS();
			BinaryTreeNode root2 = c.BuildBinaryTreeGraph();
			Console.WriteLine("Minimum Depth of Binary Tree\n------");

			Solution sol = new Solution();
			Console.WriteLine(sol.MinDepth(root2));
			
			 */

			/********************************************************** Word Ladder **

			WordLadder w = new WordLadder();

			ISet<string> dict = new HashSet<string> {"hot","dot","dog","lot","log"};

			int len = w.ladderLength("hit", "cog", dict);

			Console.WriteLine(len.ToString());
			 *
			 * * */
			
			/********************Reverse string****************

			StringSolution s = new StringSolution();
			Console.WriteLine(s.ReverseString(""));

			*/

			/********************Reverse vowels in a string*****************
			
			StringSolution s = new StringSolution();
			Console.WriteLine(s.ReverseVowels("Quinstreet"));

			*/

			/********************Reverse words in a string****************
			
			StringSolution s = new StringSolution();
			Console.WriteLine(s.ReverseWords("K "));

			*/

			/**************************************************** Is Numeric ***
			
			StringSolution s = new StringSolution();
			bool b = s.isNumeric("1  ");
			 
			Console.WriteLine(b);
			 
            */

			/**************************************************** Max Sub Array (Kadane's Algorithm) **
			
			ArraySolution s = new ArraySolution();
			int[] input = { -2, 1 };
			int max = s.MaxSubArray(input);
			 
			Console.WriteLine(max);
			*/

			/**************************************************** Sum subset problem (No recursion - dynamic - non-negative integer input) **
			
			DynamicSolution s = new DynamicSolution();
			int[] input = {2, 3, 4, 5, 12, 34};
			bool max = s.IsSubsetSum(input, input.Length, 9);
			Console.WriteLine(max);
			 
			Console.ReadLine();
			*/

			/**************************************************** Is Palindrome **
			
			StringSolution s = new StringSolution();
			string input = "lirril";
			bool isPalindrome = s.IsPalindrome(input);

			Console.WriteLine(isPalindrome);
			  
			 */

			/**************************************************** LongestSubstringPalindrome (Not complete) **
			
			StringSolution s = new StringSolution();
			string input = "abaccddccefe";
			string isPalindrome = s.ReturnLongestSubstringPalindrome(input);

			Console.WriteLine(isPalindrome);
			  
			 */

			/**************************************************** LongestSubstringPalindrome (Not complete) **
			
			SortingSolution s = new SortingSolution();
			int[] input1 = { 1, 2, 4, 5, 6, 0 };
			int[] input2 = { 3 };

			s.Merge(input1, input1.Length, input2, input2.Length);
			 * 
			 * */

			/**************************************************** Remove Duplicates from Sorted Array   **
			
			SortingSolution s = new SortingSolution();
			int[] input1 = { 1, 1, 2, 2, 3};
			int i = s.RemoveDuplicates(input1);

			Console.WriteLine(i);
			 * 
			 * */

			/**************************************************** Two Sum II - Input array is sorted **
			
			SortingSolution s = new SortingSolution();
			int[] input1 = { 2, 7, 11, 15 };
			int target = 9;
			int[] i = s.TwoSum(input1,target);

			Console.WriteLine("aaa {0} {1}"+i[0]+i[1]);

			 * */

			/**************************************************** Median of Two Sorted Arrays *****
			
			SortingSolution s = new SortingSolution();
			int[] input1 = { };
			int[] input2 = { 3, 4 };

			Console.WriteLine("Median " + s.FindMedianSortedArrays(input1, input2));
 
			 * */


			/**************************************************** Maximum Product of Three Numbers *****
			
			SortingSolution s = new SortingSolution();
			int[] input1 = {-4, -3, -1, -2, 60};

			Console.WriteLine("Maximum Product of Three Numbers in list " + s.MaximumProduct(input1));

			Console.ReadLine();
			*/

			/**************************************************** Longest Palindrome ******
			
			StringSolution s = new StringSolution();
			Console.WriteLine("Length " + s.LongestPalindrome("kabccccdd"));

			//Console.WriteLine("Length " + s.LongestPalindrome("aaaAaaaa"));

			* */

			/**************************************************** Shortest Palindrome (incomplete)******
			
			StringSolution s = new StringSolution();
			Console.WriteLine("Shortest Palindrome " + s.ShortestPalindrome("aabba"));
			 
			**/

			/**************************************************Intersection of Two Arrays (incomplete) ***********
			
			ArraySolution s = new ArraySolution();
			int[] input1 = { 1, 2, 3,4 };
			int[] input2 = { 3, 4, 5 };
			int[] result = s.Intersection2(input1, input2);

			foreach (int a in result)
			{
				Console.WriteLine(a);
			}
			 
			 * */

			/**************************************************Implement strStr()***********
			
			StringSolution s = new StringSolution();
			int r = s.StrStr("mississippi","issip");			 
			Console.WriteLine(r);
			 */


			/**************************************************** Two Sum Input array is unsorted **
			
			ArraySolution s = new ArraySolution();
			int[] input1 = {3,2,4};
			int target = 6;
			int[] i = s.TwoSumUnsorted(input1,target);
			 
			Console.WriteLine("aaa {0} {1}"+i[0]+i[1]);
			**/

			/**************************************************** Pow(x,n) **
			
			MathSolution s = new MathSolution();

			Console.WriteLine("Power " + s.MyPow(2,-8));

			 * */

			/**************************************************** Valid Parentheses *********
			StringSolution s = new StringSolution();

			Console.WriteLine("Parentheses " + s.IsValid("[()]"));
			  
			 */

			/**************************************************** String to Integer (atoi) ********

			MathSolution m = new MathSolution();

			Console.WriteLine("String to integer " + m.MyAtoi("-0.3"));
			 * 
			 **/

			/****************************************************  N-Queen Problem (Not over)*******
			RecursiveSolution r = new RecursiveSolution();

			IList<string[]> s1 = r.SolveNQueens(4);


		   */
			 

			/****************************************************  Integer to English Words *****
			RecursiveSolution r = new RecursiveSolution();


			Console.WriteLine("Integer to English words: " + r.NumberToWords(20));

			Console.ReadLine();
			*/

			/****************************************************  Climbing stairs ********
			RecursiveSolution r = new RecursiveSolution();
			int s = r.GetWays(7);

			Console.WriteLine("Staircase ways " + s);

			DynamicSolution d = new DynamicSolution();
			int d2 = d.ClimbStairs(7); 
			
			Console.WriteLine("Staircase ways " + s);
			* 
			**/

			/****************************************************  Evaluate math expression *****
			MathSolution d = new MathSolution();
			decimal d2 = d.EvaluateMathExpression("9+6-15");

			Console.WriteLine("Answer " + d2);

			Console.ReadLine();
			*/

			/****************************************************  Max Points on a Line *****
			MathSolution d = new MathSolution();

			Point p0 = new Point(2,1);
			Point p1 = new Point(2,4);
			Point p2 = new Point(3,2);
			Point p3 = new Point(3,3);
			Point p4 = new Point(4,3);
			Point p5 = new Point(4,5);
			Point p6 = new Point(5,1);


			Point[] input = new Point[] { p0, p1, p2, p3, p4, p5, p6 };

			Console.WriteLine("List of points in a line is " + d.MaxPoints(input));

			Console.ReadLine();
			 
			 */

			/****************************************************  Longest Absolute File Path *****
			StringSolution s = new StringSolution();

			int k = s.LengthLongestPath("dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext");

			Console.WriteLine("Answer " + k);

			Console.ReadLine();
			****/

			/****************************************************  Knapsack*****
			DynamicSolution d = new DynamicSolution();
			int[] val = {0, 1, 4, 5, 7};
			int[] weight = {0, 1, 3, 4, 5};

			int k = d.KnapSack(4, 7, weight, val);

			Console.WriteLine("Maximum value for knapsact of weight 7 " + k);
			Console.ReadLine();
			*/

			/****************************************************  License Key Formatting (not efficient)*****
			StringSolution s = new StringSolution();

			string k = s.LicenseKeyFormatting("2-4A0r7-4k", 3);

			Console.WriteLine("Answer " + k);
			 
			*/

			/*
			Node1 root = null;
			int T = Int32.Parse(Console.ReadLine());
			while (T-- > 0)
			{
				int data = Int32.Parse(Console.ReadLine());
				root = insert(root, data);
			}
			int height = getHeight(root);
			Console.WriteLine(height-1);

			Console.ReadLine();
			*/

			/****************************************************Coin change problem*****
			DynamicSolution d = new DynamicSolution();
			int[] coins = {1, 2, 5};
			int[] value = {1, 2, 5};

			int amount = 5;

			int k = d.Change(3, amount, value);

			Console.WriteLine("Number of ways  " + k);
			Console.ReadLine();
		    **/

			/****************************************************Coin change problem - not complete****
			DynamicSolution d = new DynamicSolution();
			int[] coins = {1, 2, 5};
			int[] value = {1, 2, 5};

			int amount = 11;

			int k = d.CoinChange(coins, amount);

			Console.WriteLine("Number of coins to make the mentioned amount  " + k);
			Console.ReadLine();
			*/


			/****************************************************Continuous Subarray Sum****

			ArraySolution s = new ArraySolution();
			int[] input = { 23, 2, 5, 6, 7 };

			int k = 6;
			Boolean output = s.CheckSubarraySum(input, k);

			Console.WriteLine("Output:  " + output);
			Console.ReadLine();
			**/


			/****************************************************Continuous Subarray product****

			ArraySolution s = new ArraySolution();
			int[] input = { 2, 3, -2, 4 };

			int output = s.MaxProduct(input);

			Console.WriteLine("Output:  " + output);
			Console.ReadLine();
			*/

			/************************Skyline problem********************************
			ArraySolution d = new ArraySolution();

			// input 1  : [[2,9,10],[3,7,15],[5,12,12],[15,20,10],[19,24,8]]
		    // 5 is number of buildings
			// 3 is dimension for each building

			// input 1  : [[2,9,10],[3,7,15],[5,12,12],[15,20,10],[19,24,8]]
			// 2 is number of buildings
			// 3 is dimension for each building

			int[,] buildings = new int[5,3] {{2,9,10},{3,7,15},{5,12,12},{15,20,10},{19,24,8}};
		    //int[,] buildings = new int[2, 3] { { 0, 2, 3 }, { 2, 5, 3 } };
			//int[,] buildings = new int[2,3] {{2,9,10},{9,12,15}};
			//int[,] buildings = new int[3, 3] { { 1, 2, 1 }, { 1, 2, 2 }, { 1, 2, 3 } };

			List<int[]> output = new List<int[]>();
			output = d.GetSkyline(buildings).ToList();


			Console.WriteLine("Skyline:  " + output.ToString());
			Console.ReadLine();

			**/

			/*******Merge K sorted list problem *********

			LinkedListNode node1 = new LinkedListNode(4);
			LinkedListNode node2 = new LinkedListNode(7);
			LinkedListNode node3 = new LinkedListNode(8);
			LinkedListNode node4 = new LinkedListNode(2);
			LinkedListNode node5 = new LinkedListNode(1);

			node5.next = node4;
			node4.next = node1;
			node1.next = node2;
			node2.next = node3;

			LinkedListNode node6 = new LinkedListNode(5);
			LinkedListNode node7 = new LinkedListNode(9);
			LinkedListNode node8 = new LinkedListNode(6);
			LinkedListNode node9 = new LinkedListNode(3);
			LinkedListNode node10 = new LinkedListNode(10);

			node9.next = node6;
			node6.next = node8;
			node8.next = node7;
			node7.next = node10;

			//LinkedListNode[] lists = { node5, node9 };

			LinkedListNode node11 = new LinkedListNode(2);
			LinkedListNode node12 = new LinkedListNode(1);

			LinkedListNode[] lists = { node11, node12};



			LinkedListNode outputList = LinkedListSolution.MergeKLists(lists);

			Console.WriteLine("Merge k sorted problem ", outputList);
			Console.ReadLine();
			 
			 * */

			/*********************Change Directory 'cd' ****************

			StringSolution s = new StringSolution();

			string output = s.findResultingDirectoryForCD("a/b", "cccc|..|d|e|..|f");

			Console.WriteLine(output);

			Console.ReadKey();

			*/

			/**********Merge Sorted List**********************

			ArraySolution a = new ArraySolution();

			int[] A = {3, 7, 8, 9, -1, -1, -1};

			int[] B = {4, 12, 18};

			a.MergeTwoSortedArray(A, 4, B, 3);

			Console.WriteLine("Merge 2 sorted array problem ", A.ToString());

			Console.ReadKey();

			*/

			/************* Max product of 3 numbers***************

			ArraySolution a = new ArraySolution();
			int[] arr = { -10, -3, 5, 6, -20 };
			int n = arr.Length;
 
			int max = a.MaxProductThreeNumbers(arr, n);

			Console.WriteLine("Max product of three numbers "+ max);

			Console.ReadKey();
			*/

			/*******Merge Intervals************************************

			ArraySolution arrayProblem = new ArraySolution();
			//Interval input1 = new Interval(1, 3);
			//Interval input2 = new Interval(2, 6);
			//Interval input3 = new Interval(8, 10);
			//Interval input4 = new Interval(15, 18);

			Interval input5 = new Interval(1, 4);
			Interval input6 = new Interval(2, 3);

			List<Interval> input = new List<Interval>();

			//input.Add(input1);
			//input.Add(input2);
			//input.Add(input3);
			//input.Add(input4);

			input.Add(input5);
			input.Add(input6);

			Console.WriteLine("Interval merge ", arrayProblem.Merge(input));
			Console.ReadLine();

			**/

			/*******Search in Rotated Sorted Array************************************

			ArraySolution arrayProblem = new ArraySolution();

			int[] input = new int[] {5, 6, 1, 2, 3, 4};

			int searchElement = 1;


		    Console.WriteLine("The element {0} in rotated array is found in {1} ", searchElement, arrayProblem.Search(input, searchElement));
			Console.ReadLine();
			*/


			/*******Search minimum element in Rotated Sorted Array************************************

			ArraySolution arrayProblem = new ArraySolution();

			int[] input1 = new int[] {1, 2, 3};
			int[] input2 = new int[] { 3, 1, 3 };


			Console.WriteLine("The minimum element in rotated array is found in {0} ", arrayProblem.FindMin(input1));
			Console.WriteLine("The minimum element in rotated array is found in {0} ", arrayProblem.FindMinFromDuplicateValueRotatedArray(input2));
			Console.ReadLine();

			*/

			/*******Largest Rectangle in Histogram************************************

			StackSolution stackProblem = new StackSolution();

			//int[] histograms = new int[] {10, 40, 30, 70, 10, 30, 60 };
			//int[] histograms = new int[] { 1 };

			Console.WriteLine("The maximum area {0} ", stackProblem.LargestRectangleArea(histograms));
			Console.ReadLine();
			*/

			/*******Container With Most Water************************************

			ArraySolution containerProblem = new ArraySolution();

			int[] heights = new int[] {1, 5, 4, 3 };

			Console.WriteLine("Container With Most Water {0} ", containerProblem.MaxArea(heights));
			Console.ReadLine();
			*/

			/*******Trapping Water************************************

			ArraySolution rainWaterProblem = new ArraySolution();

			int[] heights = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

			Console.WriteLine("Amount of water captured {0} ", rainWaterProblem.Trap(heights));
			Console.ReadLine();
			*/

			/*******Non-negative Integers without Consecutive Ones*********
			////////brute force method
			ArraySolution findIntegerProblem = new ArraySolution();

			////////Efficient dynamic programming method----still to do
			DynamicSolution findIntegerProblemDynamic = new DynamicSolution();

			int input = 5;

			Console.WriteLine("Here are the non-negative integers {0} ", findIntegerProblemDynamic.FindIntegers(input));
			Console.ReadLine();
			*/

			/*******Friend circle problem - dfs*********
		 
			Solution findFriendCircles = new Solution();

			int[,] input = new int[3,3] { {1,1,0}, {1,1,0}, {0,0,1} };

			Console.WriteLine("Total number of friend circle {0} ", findFriendCircles.FindCircleNum(input));
			Console.ReadLine();

			*/

			/*******K-th Smallest in Lexicographical Order****not complete*****
		 
			RecursiveSolution findKthLexi = new RecursiveSolution();

			Console.WriteLine("K-th Smallest in Lexicographical Ordere {0} ", findKthLexi.FindKthNumber(681692778, 351251360));
			Console.ReadLine();
			*/

			/*******Kth Largest Element in an Array****

			ArraySolution findKthLargest = new ArraySolution();

			int k = 2;
			int[] nums = new int[]{3,2,1,5,6,4};

			Console.WriteLine("Kth Largest Element in an Array {0} ", findKthLargest.FindKthLargest(nums, k));
			Console.ReadLine();
			*/

			/*******Kth Largest Element in an Array****

			BinaryTreeNode n = new BinaryTreeNode(8);
			BinaryTreeNode o = new BinaryTreeNode(3);
			BinaryTreeNode p = new BinaryTreeNode(10);
			BinaryTreeNode q = new BinaryTreeNode(1);
			BinaryTreeNode r = new BinaryTreeNode(6);
			BinaryTreeNode s = new BinaryTreeNode(14);
			BinaryTreeNode t = new BinaryTreeNode(15);
			BinaryTreeNode u = new BinaryTreeNode(24);
			BinaryTreeNode v = new BinaryTreeNode(27);

			n.left = o;
			n.right = p;
			o.left = q;
			o.right = r;
			p.left = s;
			s.right = t;
			r.right = u;
			r.right = v;

			BinaryTreeSearch findKthSmallest = new BinaryTreeSearch();

			int k = 5 ;

			Console.WriteLine("Kth Smallest Element in a BST {0} ", findKthSmallest.KthSmallest(n, k));
			Console.ReadLine();
			*/

			/*******Binary Tree Preorder/PostOrder/Inorder Traversal****

			BinaryTreeNode n = new BinaryTreeNode(8);
			BinaryTreeNode o = new BinaryTreeNode(3);
			BinaryTreeNode p = new BinaryTreeNode(10);
			BinaryTreeNode q = new BinaryTreeNode(1);
			BinaryTreeNode r = new BinaryTreeNode(6);
			BinaryTreeNode s = new BinaryTreeNode(14);
			BinaryTreeNode t = new BinaryTreeNode(15);
			BinaryTreeNode u = new BinaryTreeNode(24);
			BinaryTreeNode v = new BinaryTreeNode(27);

			n.left = o;
			n.right = p;
			o.left = q;
			o.right = r;
			p.left = s;
			s.right = t;
			r.left = u;
			r.right = v;

			BinaryTreeSearch inOrderTraversal = new BinaryTreeSearch();
			BinaryTreeSearch preOrderTraversal = new BinaryTreeSearch();
			BinaryTreeSearch postOrderTraversal = new BinaryTreeSearch();

			Console.WriteLine("Inorder traveral of a BT {0} ", inOrderTraversal.InorderTraversal(n));
			Console.WriteLine("Preorder traveral of a BT {0} ", preOrderTraversal.PreorderTraversal(n));
			Console.WriteLine("Postorder traveral of a BT {0} ", postOrderTraversal.PostorderTraversal(n));
			Console.ReadLine();
						 
			*/
			/*******Engagio**********
			StringSolution d = new StringSolution();

			// input 1  : [[2,9,10],[3,7,15],[5,12,12],[15,20,10],[19,24,8]]

			String s = "Hi {{recipeint.firstna,me}}, at Engagio our CEO, Joe Miller, was co-founder.......{{account.name}}, Are you available for intro{{sender.fullname}}";
			d.StringContentSeperator(s);

			Console.WriteLine("Done");
			Console.ReadLine();
			*/


			/*********** LRU Cache problem (Inefficient - Leetcode has efficient method) ***********
			 

			LRUCache obj = new LRUCache(2);

			//["LRUCache","get","put","get","put","put","get","get"]
            //[[2],[2],[2,6],[1],[1,5],[1,2],[1],[2]]
			

			int param_1 = obj.Get(2);
			Console.WriteLine(" Value for input key is  " + param_1);

			obj.Put(2,6);

			int param_2 = obj.Get(1);
			Console.WriteLine(" Value for input key is  " + param_2);

			obj.Put(1, 5);
			obj.Put(1, 2);

			int param_3 = obj.Get(1);
			Console.WriteLine(" Value for input key is  " + param_3);

			int param_4 = obj.Get(2);
			Console.WriteLine(" Value for input key is  " + param_4);

			Console.ReadLine();
			*/
		}

		static Node1 insert(Node1 root, int data)
		{
			if (root == null)
			{
				return new Node1(data);
			}
			else
			{
				Node1 cur;
				if (data <= root.data)
				{
					cur = insert(root.left, data);
					root.left = cur;
				}
				else
				{
					cur = insert(root.right, data);
					root.right = cur;
				}
				return root;
			}
		}

		static int getHeight(Node1 root)
		{
			if (root == null)
			{
				return 0;
			}
			else
			{
				int lDepth = getHeight(root.left);
				int rDepth = getHeight(root.right);

				if (lDepth > rDepth)
					return (lDepth + 1);
				else
					return (rDepth + 1);
			}
		}
	}
}
