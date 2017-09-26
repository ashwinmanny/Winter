using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpDataStructures
{
	class Program
	{
		static void Main(string[] args)
		{   
 			//*******************************************************IList**********************************************/
			//single dimension array

			Console.WriteLine("*******single dimension array*********\n"); 

			int[] singleArray = new int[3];

			singleArray = new int[] { 0, 3, 5 };

			singleArray[1] = 4;

			Console.WriteLine("Single Array item at position 2: {0}", singleArray[1]);

			//multiple dimension array or matrix

			Console.WriteLine("******multiple dimension array or matrix*********\n"); 

			int[,] multiArray = new int[2,3];

			multiArray = new int[2,3] { { 0, 3, 5 }, { 0, 8, 5 } };

			multiArray[1, 1] = 9;

			Console.WriteLine("Muniti dimensional Array item at position 2 and array 2: {0}", multiArray[1,1]);

			//jagged array or array of arrays

			Console.WriteLine("*******jagged array or array of arrays*********\n"); 

			int[][] jaggedArray = new int[3][];

			jaggedArray[0] = new int[4] { 1, 2, 3, 4 };
			jaggedArray[1] = new int[2] { 11, 12 };
			jaggedArray[2] = new int[3] { 21, 22, 23 };

			jaggedArray[1][1] = 15;

			Console.WriteLine("Jagged Array item at position 2 in array 2: {0}", jaggedArray[1][1]);

			//ArrayList Collection (for non-fixed size)

			Console.WriteLine("********ArrayList Collection (for non-fixed size) and its stores Object references by upcasting any type*********\n"); 

			ArrayList arrayList = new ArrayList();

			arrayList.Add("one");
			arrayList.Add(1);
			arrayList.Add("three");

			Console.WriteLine("Arraylist item at position 2: {0}", arrayList[2]);


			//List Collection (for non-fixed size) - O(n)

			Console.WriteLine("********List Collection (for non-fixed size)- O(n) and its stored specific generic data type references and can be easily used With LINQ *********\n"); 

			List<int> list = new List<int>();

			list.Add(8);
			list.Add(1);
			list.Add(34);

			Console.WriteLine("list item at position 2: {0}", list[2]);

			//*******************************************************IDictionary**********************************************/

			// Hashtable --- old and should not be used

			Console.WriteLine("********Hashtable --- old and should not be used*********\n"); 

			Hashtable hashtable = new Hashtable();

			hashtable[1] = "Pme";
			hashtable[1] = "cvbcbvb";
			hashtable[1] = "ertert";

			hashtable.Add(2, "sdfsdf");

			Console.WriteLine("HashTable value for key 1: {0}", hashtable[1]);
			Console.WriteLine("HashTable value for key 2: {0}", hashtable[2]);

			// Dictionary - use this instead- O(1) 

			Console.WriteLine("********Dictionary - use this instead- O(1) *********\n"); 

			Dictionary<int, string> dic = new Dictionary<int, string>();

			dic[1] = "Pme";
			dic[1] = "cvbcbvb";
			dic[1] = "ertert";

			dic.Add(2, "sdfsdf");

			Console.WriteLine("Dictionary value for key 1: {0}", dic[1]);

			if (dic.ContainsKey(2))
			{
				string value = dic[2];
				Console.WriteLine("Dictionary value for key 2: {0}", dic[2]);
			}

			string output;
			if (dic.TryGetValue(1, out output))
			{
				Console.WriteLine("Dictionary key for sdfsdf 2: {0}", output);
			}

			foreach (var pair in dic)
			{
				Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
			}

			// SortedList - list is sorted so good for binary search- O(log n) 

			Console.WriteLine("*********SortedList - list is sorted so good for binary search- O(log n) *********\n"); 

			SortedList<int, string> sortedList = new SortedList<int, string>();

			sortedList.Add(2, "SortedList2");
			sortedList.Add(1, "SortedList1");
			sortedList.Add(3, "SortedList3");

			foreach (var pair in sortedList)
			{
				Console.WriteLine(pair);
			}

			// SortedDictionary - dictionary is sorted by key- O(log n) 

			Console.WriteLine("*********SortedDictionary - dictionary is sorted by key- O(log n) *********\n"); 

			SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();

			sortedDictionary.Add(3, "SortedDictionary3");
			sortedDictionary.Add(1, "SortedDictionary1");
			sortedDictionary.Add(2, "SortedDictionary2");

			foreach (var pair in sortedDictionary)
			{
				Console.WriteLine(pair);
			}

			//*******************************************************Queue**********************************************/

			// Queue - first-in, first-out order- O(1) 

			Console.WriteLine("*********Queue - first-in, first-out order- O(1) *********\n"); 

			Queue<int> queue = new Queue<int>();

			queue.Enqueue(5);
			queue.Enqueue(10);
			queue.Enqueue(15);
			queue.Enqueue(20);
			queue.Dequeue();
			Console.WriteLine("First value in the queue {0}", queue.Peek()); 

			foreach (var value in queue)
			{
				Console.WriteLine(value);
			}

			queue.Clear();


			//*******************************************************Stack**********************************************/

			// Stack - Last-in, first-out order - good for parsers- O(1) 

			Console.WriteLine("*********Stack - Last-in, first-out order - good for parsers- O(1) *********\n");

			Stack<int> stack = new Stack<int>();

			stack.Push(5);
			stack.Push(10);
			stack.Push(15);
			stack.Push(20);
			stack.Pop();
			Console.WriteLine("First value in the stack {0}", stack.Peek());

			foreach (var value in stack)
			{
				Console.WriteLine(value);
			}

			stack.Clear();


			//******************************************************* Linked List (It is doubly linked list in c# library) **********************************************/

			// LinkedList - O(n) 

			Console.WriteLine("*********LinkedList- O(n) *********\n");

			LinkedList<int> linked = new LinkedList<int>();

			linked.AddLast(20);
			linked.AddLast(5);
			linked.AddLast(15);
			linked.AddFirst(10);

			LinkedListNode<int> node = linked.Find(15);
			linked.AddAfter(node, 18);

			LinkedListNode<int> node2 = linked.Find(20);
			linked.AddBefore(node2, 88);

			foreach (var value in linked)
			{
				Console.WriteLine(value);
			}

			linked.Clear();

			//******************************************************* ISet **********************************************/

			// SortedSet - O(log n) ----- Set usually has no duplicates

			Console.WriteLine("*********SortedSet- O(log n) *********\n");

			SortedSet<string> set = new SortedSet<string>();

			set.Add("pankaj");
			set.Add("panvati");
			set.Add("perls");
			set.Add("net");
			set.Add("net");
			set.Add("dot");
			set.Add("sam");

			set.Remove("sam");


			set.RemoveWhere(element => element.StartsWith("pa"));

			foreach (var value in set)
			{
				Console.WriteLine(value);
			}

			SortedSet<int> setOfList = new SortedSet<int>(list);

			foreach (var value in setOfList)
			{
				Console.WriteLine(value);
			}

			set.Clear();

			// Hashedet - optimized set- O(1) 

			Console.WriteLine("*********HashedSet - optimized set- O(1) *********\n");

			string[] array1 = {"cat","dog","cat","leopard", "tiger", "cat"};

			var hashSet = new HashSet<string>(array1);

			string[] array2 = hashSet.ToArray();

			Console.WriteLine(string.Join(",", array2));

			//******************************************************* System **********************************************/

			//Tuple 

			Console.WriteLine("*********Tuple*********\n");

			List<Tuple<int, string>> listTuple = new List<Tuple<int, string>>();
			listTuple.Add(new Tuple<int, string>(1, "cat"));
			listTuple.Add(new Tuple<int, string>(100, "apple"));
			listTuple.Add(new Tuple<int, string>(2, "zebra"));

			listTuple.Sort((a, b) => a.Item2.CompareTo(b.Item2));

			foreach (var element in listTuple)
			{
				Console.WriteLine(element);
			}

			Console.ReadKey();

		}
	}
}
