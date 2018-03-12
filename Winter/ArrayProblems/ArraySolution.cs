using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter.ArrayProblems
{
	class ArraySolution
	{
		public static IList<string> RemoveInvalidParentheses(string s)
		{
			List<String> ans = new List<String>();
			remove(s, ans, 0, 0, new char[]{'(', ')'});
			return ans;
		}

		public static void remove(String s, List<String> ans, int last_i, int last_j, char[] par)
		{
			for (int stack = 0, i = last_i; i < s.Length; ++i)
			{
				if (s[i] == par[0])
				{ 
					stack++; 
				}
				if (s[i] == par[1])
				{ 
					stack--; 
				}
				if (stack >= 0)
				{
					continue;
				}
				else
				{
					for (int j = last_j; j <= i; ++j)
					{
						if (s[j] == par[1] && (j == last_j || s[j - 1] != par[1]))
						{
							remove(s.Substring(0, j) + s.Substring(j + 1), ans, i, j, par);
						}
					}
					return;
				}
			}

			char[] rev = s.ToCharArray();
			Array.Reverse(rev);

			String reversed = new String(rev);
			if (par[0] == '(') // finished left to right
				remove(reversed, ans, 0, 0, new char[] { ')', '(' });
			else // finished right to left
				ans.Add(reversed);
		}

		public int[] TwoSum(int[] numbers, int target)
		{
			int[] output = new int[2];

			//use two pointer from front and back
			for (int i = 0, j = numbers.Length - 1; i < j; )
			{

				if (numbers[i] + numbers[j] == target)
				{
					output[0] = i + 1;
					output[1] = j + 1;
					return output;
				}
				else if (numbers[i] + numbers[j] < target)
				{
					i++;
				}
				else
				{
					j--;
				}
			}

			return output;
		}

		//for sorted
		public IList<IList<int>> TwoSum2(int[] numbers, int target)
		{
			IList<IList<int>> res = new List<IList<int>>();

			//use two pointer from front and back
			for (int i = 0, j = numbers.Length - 1; i < j; )
			{

				if (numbers[i] + numbers[j] == target)
				{
					res.Add((new List<int> { numbers[i], numbers[j] }));
					return res;
				}
				else if (numbers[i] + numbers[j] < target)
				{
					i++;
				}
				else
				{
					j--;
				}
			}

			return res;
		}

		public int[] TwoSumUnsorted(int[] nums, int target)
		{
			var dict = new Dictionary<int, int>();

			//use dictionary to store difference
			for (int i = 0; i < nums.Length; i++)
			{
				var aim = target - nums[i];

				if (dict.ContainsKey(aim))
				{
					return new int[] { dict[aim], i };
				}
				else
				{
					if (!dict.ContainsKey(nums[i]))
					{
						dict.Add(nums[i], i);
					}
				}

			}

			return null;
		}

		public IList<IList<int>> ThreeSum(int[] nums)
		{
			var result = new List<List<int>>();

			Array.Sort(nums); // -4, -1, -1, 0, 1, 2;
			for (var i = 0; i < nums.Length; i++)
			{
				// skip duplicates
				if (i != 0 && nums[i - 1] == nums[i]) //for corner case of making sure that result has unique combinations of arrays
				{
					continue;
				}

				int next = i + 1;
				int last = nums.Length - 1;

				while (next < last)
				{
					// skip duplicates
					if (next != i + 1 && nums[next] == nums[next - 1]) // [0,0,0,0] for corner case of making sure that result has unique combinations of arrays
					{
						next++;
						continue;
					}

					int sum = nums[i] + nums[next] + nums[last];

					if (sum == 0)
					{
						result.Add(new List<int>() { nums[i], nums[next], nums[last] });
						next++;
					}
					else if(sum < 0)
					{
						next++;
					}
					else{
						last--;
					}


				}

			}

			return result.ToArray();
		}

		public int ThreeSumClosest(int[] nums, int target) 
		{
			int min = Int16.MaxValue;
			int result = 0;

			Array.Sort(nums);

			for (int i = 0; i < nums.Length; i++)
			{
			    int j = i+1; 			
			    int k = nums.Length - 1;

				while (j < k)
				{
					int sum = nums[i] + nums[j] + nums[k];
					int diff = Math.Abs(sum - target);

					if (diff == 0)
					{
						return sum;
					}
					if (diff < min)
					{
						min = diff;
						result = sum;
					}
					if (sum < target)
					{
						j++;
					}
					else
					{
						k--;
					}
				}				   
			}
			return result;
		}

		public int ThreeSumSmaller(int[] nums, int target)
		{
			
			Array.Sort(nums);
			int result = 0;

			for (int i = 0; i < nums.Length; i++)
			{
				int j = i + 1;
				int k = nums.Length-1;

				while (j < k)
				{
					int sum = nums[i] + nums[j] + nums[k];

					if (sum < target)
					{
						result = result + (k - j);
						j++;
					}
					else
					{
						k--;
					}
				}
			}
			return result;
			/*

			int count = 0;
			Array.Sort(nums);
			int len = nums.Length;

			for (int i = 0; i < len - 2; i++)
			{
				int left = i + 1, right = len - 1;
				while (left < right)
				{
					if (nums[i] + nums[left] + nums[right] < target)
					{
						count += right - left;
						left++;
					}
					else
					{
						right--;
					}
				}
			}

			return count;
			 * */
		}

		public IList<IList<int>> FourSum(int[] nums, int target)
		{
			var res = new List<List<int>>();
			nums = nums.OrderBy(x => x).ToArray();

			var len = nums.Length;
			for (var i = 0; i < len; i++)
			{
				// skip duplicates
				if (i != 0 && nums[i] == nums[i - 1]) continue;

				for (var j = i + 1; j < len; j++)
				{
					// skip duplicates
					if (j != i + 1 && nums[j] == nums[j - 1]) continue;

					int k = j + 1, l = len - 1;
					while (k < l)
					{
						var sum = nums[i] + nums[j] + nums[k] + nums[l];
						if (sum == target)
						{
							var onesulution = new List<int>() { nums[i], nums[j], nums[k], nums[l] };
							res.Add(onesulution);
							k++;
						}
						else if (sum < target)
						{
							k++;
						}
						else
						{
							l--;
						}
						// skip duplicates
						while (k < l && k != j + 1 && nums[k] == nums[k - 1])
						{
							k++;
						}
						// skip duplicates
						while (k < l && l != len - 1 && nums[l] == nums[l + 1])
						{
							l--;
						}
					}
				}
			}

			return res.ToArray();
		}

		public IList<IList<int>> AllSubsetsOfSet(int[] nums)
		{
			List<List<int>> fulllist = new List<List<int>>();

			double pow = Math.Pow(2, nums.Length);

			int i, j;

			/*Run from counter (i) 000..0 to binary representation of 2^n */
			for (i = 0; i < pow; i++)
			{
				List<int> list = new List<int>();
				for (j = 0; j < nums.Length; j++)
				{
					/* Check if jth bit in the counter is set
					   If set then print jth element from set */
					if ((i & (1 << j)) > 0)
					{
						list.Add(nums[j]);
					}
				}
				fulllist.Add(list);
			}

			return fulllist.ToArray();

		}

		public long TotalAllEvenNumbers(int[] intArray)
		{
			return (from i in intArray where i % 2 == 0 select (long)i).Sum();
		}

		public int MaxSubArray(int[] nums)
		{
			int total_max = nums[0];
			int current_max = nums[0];

			for (int i = 1; i <= nums.Length - 1; i++)
			{
				current_max = Math.Max(nums[i], current_max + nums[i]);

				if (current_max > total_max)
				{
					total_max = current_max;
				}
			}

			return total_max;
		}

		public List<string> ReturnLinq()
		{
			List<string> fruits = new List<string> { "apple", "orange", "kiwi", "banana" };

			IEnumerable<string> list1 = fruits.Where(fruit => fruit.Length < 5);

			return list1.ToList();
		}

		public int[] Intersection(int[] nums1, int[] nums2)
		{
			var result = nums1.Intersect(nums2);

			return result.ToArray();
		}

		public int[] Intersection2(int[] nums1, int[] nums2)
		{
			Dictionary<int, int> numsDict1= new Dictionary<int,int>();
			Dictionary<int, int> numsDict2 = new Dictionary<int, int>();

			foreach (int n1 in nums1)
			{
				if (numsDict1.ContainsKey(n1))
				{
					numsDict1[n1] =numsDict1[n1] +1;
				}
				else
				{
					numsDict1.Add(n1, 1);
				}
			}


			foreach (int n2 in nums2)
			{
				if (numsDict2.ContainsKey(n2))
				{
					numsDict2[n2] = numsDict2[n2] + 1;
				}
				else
				{
					numsDict2.Add(n2, 1);
				}
			}

			var result2 = numsDict1.Intersect(numsDict2);

			Dictionary<int, int> resultDict2 = result2.ToDictionary(x=>x.Key,y=>y.Value);

			List<int> result = new List<int>();
			foreach (KeyValuePair<int, int> item in resultDict2)
			{
				int i = 0;
				while(i<item.Value)
				{
					result.Add(item.Key);
					i++;
				}
			
			}

			return result.ToArray();
		}

		public bool CheckSubarraySum(int[] nums, int k)
		{
			Dictionary<int, int> dict = new Dictionary<int, int>();

			dict.Add(0, -1);

			int runningSum = 0;

			for (int i = 0; i < nums.Length; i++)
			{
				runningSum = runningSum + nums[i];

				  if (k != 0) // to avoid divide by 0 exception
				  {
					runningSum = runningSum % k;
				  }

				if (dict.ContainsKey(runningSum))
				{
					int prev = dict[runningSum];
					if (i - prev > 1) // since condition said that it should be sume of atleast 2 numbers
					{
						return true;
					}
				}
				else
				{
					dict.Add(runningSum, i);
				}			
			}

			return false;
		}

		public int MaxProduct(int[] nums)
		{

			int[] max_end_here = new int[nums.Length];
			int[] min_end_here = new int[nums.Length];

			max_end_here[0] = nums[0];
			min_end_here[0] = nums[0];

			int max = max_end_here[0];
			for (int i = 1; i <= nums.Length - 1; i++)
			{
				max_end_here[i] = Math.Max(nums[i], Math.Max(max_end_here[i - 1] * nums[i], min_end_here[i - 1] * nums[i]));
				max = Math.Max(max, max_end_here[i]);
				min_end_here[i] = Math.Min(nums[i], Math.Min(max_end_here[i - 1] * nums[i], min_end_here[i - 1] * nums[i]));
			}

			return max;
		}

		public int MaxProductThreeNumbers(int[] nums, int n)
		{
			// if size is less than 3, no triplet exists
			if (n < 3)
				return -1;
 
			// Sort the array in ascending order

		    Array.Sort(nums);
 
			// Return the maximum of product of last three elements 
			// and 
			// product of first two elements and last element (This one is to cover -ve numbers)
			return Math.Max(nums[0] * nums[1] * nums[n - 1], nums[n - 1] * nums[n - 2] * nums[n - 3]);
		}
		public IList<int[]> GetSkyline(int[,] buildings)
		{
			List<int[]> result = new List<int[]>();
			List<int[]> heights = new List<int[]>();

			int[] prev = null;

			for (int i = 0; i <= buildings.GetUpperBound(0); i++)
			{
				heights.Add(new int[]{buildings[i,0], buildings[i,2], 0, i}); //start of building
				heights.Add(new int[]{buildings[i,1], buildings[i,2], 1, i}); //end of building
			}

			heights.Sort((a, b) => ((a[0] != b[0]) ? a[0].CompareTo(b[0]) : b[1].CompareTo(a[1]))); // if x cordinate same then put start of higher building before end of shorter building

			// Initialize a heap with max value 0
			List<int> heap = new List<int>();
			heap.Add(0);
			int CurrentMaxHeap = heap.Max();
			int NewMaxHeap = heap.Max();

			// Foreach (x,y) 
			foreach (int[] height in heights)
			{
				// If cordinate start of the building
				if(height[2] == 0)
				{
				//    Add y value to heap
					  heap.Add(height[1]);
				//    Evaluate heap max
					  NewMaxHeap = heap.Max();
				//    if max heap changes
					  if(CurrentMaxHeap != NewMaxHeap)
					  {
						  if ((prev == null) || !((prev[3] + 1 == height[3]) && (prev[2] == 1) && (height[2] == 0) && (height[1] == prev[1]))) // condition to check for buildings with shared walls and with same height
						  {
							  //       Add (x,max heap) to output list
							  result.Add(new int[] { height[0], NewMaxHeap });
							  CurrentMaxHeap = NewMaxHeap;
						  }
						  else
						  {
							  result.RemoveAt(result.Count - 1);
							  CurrentMaxHeap = NewMaxHeap;
						  }
				      }
			     }
			    else
				 {
				
				//    Remove y value from heap
					  heap.Remove(height[1]);
				//    Evaluate heap max
					  NewMaxHeap = heap.Max();

				//    if max heap changes
					  if(CurrentMaxHeap != NewMaxHeap)
					  {
						  if ((prev == null) || !((prev[2] == 1) && (height[2] == 1) && (height[0] == prev[0]) && (height[1] != prev[1]))) // conditions for building with same start and end but differet heights
						  {
							  //Add (x,max heap) to output list
							  result.Add(new int[] { height[0], NewMaxHeap });
							  CurrentMaxHeap = NewMaxHeap;
						  }
						  else
						  {
							  result.RemoveAt(result.Count - 1);
							  result.Add(new int[] { height[0], NewMaxHeap });
							  CurrentMaxHeap = NewMaxHeap;
						  }
				      }
				 }

				prev = height;
			}
			return result;
		}

		public int LargestRectangleArea(int[] heights)
		{
			if (heights == null || heights.Length == 0)
			{
				return 0;
			}
			int tallestBuilding = heights[0];
			int buildingNumber = 0;
			List<int[]> buildings = new List<int[]>();

			for (int i = 0; i < heights.Length; i++ )
			{
				buildings.Add(new int[] { i, heights[i] });
			}

			foreach (int[] building in buildings)
			{
				if (building[1] > tallestBuilding)
				{
					tallestBuilding = building[1];
					buildingNumber = building[0];
				}
			}

			//if(buildings[buildingNumber]

			return 0;
		}

		public IList<Interval> Merge(IList<Interval> intervals)
		{
			List<Interval> sortedIntervals = intervals.OrderBy(x => x.start).ToList<Interval>();


			List<Interval> output = new List<Interval>();


			foreach (Interval item in sortedIntervals)
			{
				if (output.Count == 0)
				{
					output.Add(item);
				}
				else
				{
					if (item.start <= output[output.Count - 1].end)
					{
						if (!(output[output.Count - 1].end > item.end))
						{
							output[output.Count - 1].end = item.end;
						}
					}
					else
					{
						output.Add(item);
					}
				}
			}

			return output;
		}

		public int Search(int[] nums, int target)
		{
			// this is for binary search bringing complexity to 0(Log n). If teh input array has duplicate elements then O(n) linear search would be needed
		   int low = 0;
		   int high = nums.Length - 1;

		   while (low <= high)
		   {
			   int mid = (low + high) / 2;

			   if (nums[mid] == target)
			   {
				   return mid;
			   }
			   else
			   {
				   if (nums[mid] <= nums[high]) // means we are on sorted part of array
				   {
					   if (target > nums[mid] && target <= nums[high])
					   {
						   low = mid + 1;
					   }
					   else
					   {
						   high = mid - 1;
					   }
				   }
				   else
				   {
					   if (target >= nums[low] && target < nums[mid])
					   {
						   high = mid - 1;
					   }
					   else
					   {
						   low = mid + 1;
					   }
				   }
			   }
		   }
			return -1;
		}

		public bool SearchFromDuplicateValueRotatedArray(int[] nums, int target)
		{
			bool output = false;

			if ((nums == null) || (nums.Length == 0))
			{
				output = false;
			}

			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] == target)
				{
					output = true ;
				}
			}
			return output;
		}

		public int FindMin(int[] nums)// only works for non-duplicate
		{
			if (nums == null || nums.Length == 0)
			{
				return -1;
			}

			// if the array is not rotated
			if(nums[0] <= nums[nums.Length-1])
			{
				return nums[0]; 
			}
			int low = 0;
			int high = nums.Length - 1;

			while (low <= high)
			{
				int mid = (low + high) / 2;

				// To spot pivot point
				if(nums[mid] > nums[mid+1])
				{
					return nums[mid+1];
				}
				else if (nums[low] <= nums[mid]) // sorted left side of array
				{
					low = mid + 1;
				}
				else
				{
					high = mid - 1;
				}
			}
			return -1;
		}

		public int FindMinFromDuplicateValueRotatedArray(int[] nums)// works efficently for duplicate value arrays
		{
			int minValue = nums[0];
			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] < minValue)
				{
					minValue = nums[i];
				}
			}
			return minValue;
		}

		public int MaxArea(int[] height)
		{
			int start = 0;
			int end = height.Length - 1;
			int max = 0;

			while (start < end)
			{
				if (height[start] < height[end])
				{
					max = Math.Max(max, height[start] * (end - start));
					start++;
				}
				else
				{
					max = Math.Max(max, height[end] * (end - start));
					end--;
				}
			}
			return max;

		}

		public int Trap(int[] height)
		{
			int water = 0;
			if(!(height.Length == 0))
			{
				int[] maxSeenOnRight = new int[height.Length];
				int[] maxSeenOnLeft = new int[height.Length];

				maxSeenOnLeft[0] = height[0];
				for (int i = 1; i < height.Length; i++)
				{
					maxSeenOnLeft[i] = Math.Max(height[i], maxSeenOnLeft[i - 1]);
				}

				maxSeenOnRight[height.Length - 1] = height[height.Length - 1];
				for (int j = height.Length-2; j >= 0; j--)
				{
					maxSeenOnRight[j] = Math.Max(height[j], maxSeenOnRight[j + 1]);
				}

				for (int k = 0; k < height.Length; k++)
				{
					water = water + (Math.Min(maxSeenOnLeft[k], maxSeenOnRight[k]) - height[k]);
				}
			}

			return water;

		}

		public int FindIntegers(int num)
		{
			/********brute force method**********/
			List<double> binaryArray = new List<double>();

			for (int i = 0; i <= num; i++)
			{
				int quotient = i;
				double remainder = 0;
				double binary = 0;

				int k=0;
				int countOfOnes = 0;
				while (!(quotient == 0))
				{
					remainder = quotient % 2;

					if (countOfOnes != 2)
					{
						if (remainder == 1)
						{
							countOfOnes = countOfOnes + 1;
						}
						else
						{
							countOfOnes = 0;
						}
					}

					quotient = quotient / 2;
					binary = binary + remainder * Math.Pow(10,k);
					k++;
				}

				if (!(countOfOnes == 2))
				{
					binaryArray.Add(binary);
				}
			}
			return binaryArray.Count;
		}

		public int FindKthLargest(int[] nums, int k)
		{
			List<int> list = nums.ToList();

			list.Sort();// nlogn
			list.Reverse();

			int output = list[k - 1];

			return output;
		}

		public void MergeTwoSortedArray(int[] A, int m, int[] B, int n)
		{
			var aindex = m - 1;
			var bindex = n - 1;
			while (aindex >= 0 || bindex >= 0)
			{
				var avalue = aindex >= 0 ? A[aindex] : int.MinValue;
				var bvalue = bindex >= 0 ? B[bindex] : int.MinValue;

				if (avalue > bvalue)
				{
					A[aindex + bindex + 1] = avalue;
					aindex--;
				}
				else
				{
					A[aindex + bindex + 1] = bvalue;
					bindex--;
				}
			}
		}

		public int LongestConsecutive(int[] nums)// O(n)
		{
			int count = 0;
			if (nums.Length == 0)
			{
				return 0;
			}
			
			var set = new HashSet<int>(nums);

			for (int i = 0; i < nums.Length; i++)
			{
				if(!set.Contains(nums[i]-1))
				{
					int j = nums[i];
					while (set.Contains(j))
					{
						j++;
					}

					if(count < j-nums[i])
					{
						count = j - nums[i];
					}
				}
			}

			return count;

		}

		public bool WordPattern(string pattern, string str)
		{
			string[] words = str.Split(' ');

			if (pattern.Length != words.Length)
			{
				return false;
			}

			Dictionary<char, string> dictOcc = new Dictionary<char, string>();

			for (int i = 0; i < words.Length; i++)
			{
				if (!(dictOcc.ContainsKey(pattern[i])))
				{
					if (!(dictOcc.ContainsValue(words[i])))
					{
						dictOcc.Add(pattern[i], words[i]);
					}
					else
					{
						return false;
					}
				}
				else
				{
					if (dictOcc[pattern[i]] != words[i])
					{
						return false;
					}
				}
			}


			return true;
		}

		public bool IsValidSudoku(char[,] board)
		{
			// for rows

			Dictionary<char, bool> dict;

			for (int i = 0; i < 9; i++)
			{
				dict = new Dictionary<char, bool>();
				for (int j = 0; j < 9; j++)
				{
					if (board[i, j] == '.')
					{
						continue;
					}

					if (dict.ContainsKey(board[i, j]))
					{
						return false;
					}

					dict.Add(board[i, j], true);

				}
			}

			// for columns

			for (int i = 0; i < 9; i++)
			{
				dict = new Dictionary<char, bool>();
				for (int j = 0; j < 9; j++)
				{
					if (board[j, i] == '.')
					{
						continue;
					}

					if (dict.ContainsKey(board[j, i]))
					{
						return false;
					}

					dict.Add(board[j, i], true);

				}
			}

			// for squares

			for(int i =0; i <3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					dict = new Dictionary<char, bool>();

					for (var m = 0; m < 3; m++)
					{
						for (var n = 0; n < 3; n++)
						{
							if (board[i * 3 + m,j * 3 + n] == '.')
							{
								continue;
							}

							if (dict.ContainsKey(board[i * 3 + m, j * 3 + n]))
							{
								return false;
							}

							dict.Add(board[i * 3 + m, j * 3 + n], true);
						}
					}
				}

			}

			return true;
		}

		public void SolveSudoku(char[,] board)
		{
			if (board == null || board.Length == 0)
				return;
			Console.WriteLine(solve(board));
		}

		public bool solve(char[,] board)
		{
			for (int i = 0; i < board.Length; i++)
			{
				for (int j = 0; j < board.Length; j++)
				{
					if (board[i,j] == '.')
					{
						for (char c = '1'; c <= '9'; c++)
						{//trial. Try 1 through 9
							if (isValid(board, i, j, c))
							{
								board[i,j] = c; //Put c for this cell

								if (solve(board))
									return true; //If it's the solution return true
								else
									board[i,j] = '.'; //Otherwise go back
							}
						}

						return false;
					}
				}
			}
			return true;
		}

		public bool isValid(char[,] board, int row, int col, char c)
		{
			for (int i = 0; i < 9; i++)
			{
				if (board[i,col] != '.' && board[i,col] == c) return false; //check row
				if (board[row,i] != '.' && board[row,i] == c) return false; //check column
				if (board[3 * (row / 3) + i / 3,3 * (col / 3) + i % 3] != '.' &&
	board[3 * (row / 3) + i / 3,3 * (col / 3) + i % 3] == c) return false; //check 3*3 block
			}
			return true;
		}

		public String replaceWords(List<String> dict, String sentence) 
		{
			if (dict == null || dict.Count == 0)
			{
				return sentence;
			}
        
			// increase efficiency
			HashSet<String> set = new HashSet<String>();
			foreach (String s in dict) 
			{
				set.Add(s);
			}
        
			StringBuilder sb = new StringBuilder();
			String[] words = sentence.Split(' ');
        
			foreach (String word in words) 
			{
				String prefix = "";
				for (int i = 1; i <= word.Length; i++) {
					prefix = word.Substring(0, i);
					if (set.Contains(prefix))
					{
						break;
					}
				}
				sb.Append(" " + prefix);
			}
        
            return sb.Remove(0,1).ToString();
       }

		public IList<IList<string>> GroupAnagrams(string[] strs)
		{
			Dictionary<string, List<string>> output = new Dictionary<string, List<string>>();

			foreach (string s in strs)
			{
				var strsorted = Alphabetize(s);
				if (output.ContainsKey(strsorted))
				{
					output[strsorted].Add(s);
				}
				else
				{
					output.Add(strsorted, new List<string>() { s });
				}
			}

			return output.Values.ToList().ToArray();
		}

		public static string Alphabetize(string s)
		{
			// 1.
			// Convert to char array.
			char[] a = s.ToCharArray();

			// 2.
			// Sort letters.
			Array.Sort(a);

			// 3.
			// Return modified string.
			return new string(a);
		}

		public IList<int> FallingSquares(int[,] positions)
		{
			int[] qans = new int[positions.GetLength(0)];
			for (int i = 0; i < positions.GetLength(0); i++) 
			{
				int left = positions[i,0];
				int size = positions[i,1];
				int right = left + size;
				qans[i] = qans[i] + size;

				for (int j = i+1; j < positions.GetLength(0); j++) 
				{
					int left2 = positions[j,0];
					int size2 = positions[j,1];
					int right2 = left2 + size2;
					if (left2 < right && left < right2) 
					{ //intersect
						qans[j] = Math.Max(qans[j], qans[i]);
				    }
                }
            }

			List<int> ans = new List<int>();
			int cur = -1;
			foreach (int x in qans) 
			{
				cur = Math.Max(cur, x);
				ans.Add(cur);
			}
			return ans;
		}

		public bool IsOneBitCharacter(int[] bits)
		{

			bool output = false;

			if (bits.Length == 1)
			{
				output = true;
			}

			for (int i = 0; i < bits.Length; )
			{
				if (!(bits[i] == 0))
				{
					i = i + 2;
				}
				else
				{
					i++;
				}

				if (i == (bits.Length - 1))
				{
					output = true;
				}

			}


			return output;
		}

		public IList<int> SpiralOrder(int[,] matrix)
		{
			List<int> outputList = new List<int>();

			int row = matrix.GetLength(0);
			int column = matrix.GetLength(1);

			Tuple<int, int> left = new Tuple<int, int>(0, 0); 
			Tuple<int, int> right = new Tuple<int, int>(0, column-1);
			Tuple<int, int> rightBottom = new Tuple<int, int>(row - 1, column-1);
			Tuple<int, int> leftBottom = new Tuple<int, int>(row - 1, 0);


			for (int i = 0; i < row; i++)
			{
				if (outputList.Count != matrix.Length)
				{
					int leftTopCorner = left.Item2;

					while ((leftTopCorner <= right.Item2) && outputList.Count != matrix.Length)
					{
						outputList.Add(matrix[left.Item1, leftTopCorner]);
						leftTopCorner++;
					}

					int rightTopCorner = right.Item1 + 1;

					while ((rightTopCorner <= rightBottom.Item1) && outputList.Count != matrix.Length)
					{
						outputList.Add(matrix[rightTopCorner, rightBottom.Item2]);
						rightTopCorner++;
					}


					int rightBottomCorner = rightBottom.Item2 - 1;

					while ((rightBottomCorner >= leftBottom.Item2) && outputList.Count != matrix.Length)
					{
						outputList.Add(matrix[rightBottom.Item1, rightBottomCorner]);
						rightBottomCorner--;
					}

					int leftBottomCorner = leftBottom.Item1 - 1;

					while ((leftBottomCorner > left.Item1) && outputList.Count != matrix.Length)
					{
						outputList.Add(matrix[leftBottomCorner, leftBottom.Item2]);
						leftBottomCorner--;
					}


					left = new Tuple<int, int>(left.Item1 + 1, left.Item2 + 1);
					right = new Tuple<int, int>(right.Item1 + 1, right.Item2 - 1);
					rightBottom = new Tuple<int, int>(rightBottom.Item1 - 1, rightBottom.Item2 - 1);
					leftBottom = new Tuple<int, int>(leftBottom.Item1 - 1, leftBottom.Item2 + 1);
				}

			}

			return outputList.ToArray<int>();
		}

		public bool AreSentencesSimilar(string[] words1, string[] words2, string[,] pairs)
		{
			if (words1.Length != words2.Length)
			{
				return false;
			}

			Dictionary<string, HashSet<string>> dict = new Dictionary<string, HashSet<string>>();
			for (int i = 0; i < pairs.Length; i++)
			{
				foreach (string pair in pairs)
				{
					if (!(dict.ContainsKey(pair)))
					{
						dict.Add(pair, new HashSet<string>());
					}
				}

				dict[pairs[i, 0]].Add(pairs[i, 1]);
				dict[pairs[i, 1]].Add(pairs[i, 0]);
			}

			for (int i = 0; i < words1.Length; i++)
			{
				if (words1[i] == words2[i])
				{
					continue;
				}
				else
				{
					if (dict.ContainsKey(words1[i]))
					{
						if (dict[words1[i]].Contains(words2[i]))
						{
							continue;
						}
						else
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}
			}

			return true;

		}

		public IList<int> FindAnagrams(string s, string p)
		{
			Dictionary<string, int> output = new Dictionary<string, int>();
			int k = p.Length;

			for (int i = 0; i < s.Length; i++)
			{

			}

			return null;
		}

		public static List<String> findKMinusOneDistinctSubstring(String inputString, int num) {

				Dictionary<char, int> occurrenceMap = new Dictionary<char, int>();
				List<String> resultList = new List<String>();

				for (int i = 0; i + num <= inputString.Length; i++) {

					String str = inputString.Substring(i, num);

					bool isRepeat = false;

					foreach (char c in str.ToCharArray()) {
						if (occurrenceMap.ContainsKey(c))
						{
							occurrenceMap[c] = occurrenceMap[c] + 1;
						}
						else
						{
							occurrenceMap.Add(c, 1);
						}

						if ((occurrenceMap.Values.Count == num - 1) && occurrenceMap.Values.Sum() == num)
						{
							isRepeat = true;
						}
					}
					//if it makes it through and has precisely 1 repeat character
					if (isRepeat)
						resultList.Add(str);
					//empty the map
					occurrenceMap.Clear();
				}

				return resultList;
        }

		public static List<int> lengthEachScene(List<char> inputList)
		{

				List<int> result = new List<int>();
				Dictionary<char, Interval2> occuranceMap = new Dictionary<char, Interval2>();

				List<Interval2> l = new List<Interval2>();
				for(int i = 0; i < inputList.Count; i++){
					char cur = inputList[i];
					if(occuranceMap.ContainsKey(cur)){
						occuranceMap[cur].end = i;
					}
					else{
						occuranceMap.Add(cur, new Interval2(cur, i));
					}
				}

				List<Interval2> listP = new List<Interval2>(occuranceMap.Values);

				Console.WriteLine(listP);
				Interval2 prev = listP[0];

				for(int i = 1; i < listP.Count; i++){

					Interval2 cur = listP[i];
					if( prev.end < cur.start ){

						result.Add(prev.end - prev.start +1);
						prev.start = cur.start;
						prev.end = cur.end;
					}
					else{
						if(prev.end > cur.end){
							continue;
						}
						else{
							prev.end = cur.end;

						}


					}
					//result.add(prev.end - prev.start +1);

				}

				result.Add(prev.end - prev.start + 1);

				return result;
              }

		public int CutOffTree(IList<IList<int>> forest)
		{
			List<int[]> trees = new List<int[]>();
			for (int r = 0; r < forest.Count; ++r) {
				for (int c = 0; c < forest[0].Count; c++) {
					int v = forest[r][c];
					if (v > 1) trees.Add(new int[]{v, r, c});
				}
			}

			trees.Sort((a,b) => a[0].CompareTo(b[0]));

			int ans = 0, sr = 0, sc = 0;
			foreach (int[] tree in trees) {
				int d = bfs(forest, sr, sc, tree[1], tree[2]);
				if (d < 0) return -1;
				ans += d;
				sr = tree[1]; sc = tree[2];
			}
			return ans;
		}

		static int[] dr = new int[] { -1, 1, 0, 0 };
		static int[] dc = new int[] { 0, 0, -1, 1 };

		public static int bfs(IList<IList<int>> forest, int sr, int sc, int tr, int tc) 
		{
	        int R = forest.Count;
		    int C = forest[0].Count;
			Queue<int[]> queue = new Queue<int[]>();
			queue.Enqueue(new int[]{sr, sc, 0});
			bool[,] seen = new bool[R,C];
			seen[sr,sc] = true;
			while (!(queue.Count == 0)) 
			{
				int[] cur = queue.Dequeue();
				if (cur[0] == tr && cur[1] == tc)
				{
					return cur[2];
				}

				for (int di = 0; di < 4; di++) 
				{
					int r = cur[0] + dr[di];
					int c = cur[1] + dc[di];
					if (0 <= r && r < R && 0 <= c && c < C && !(seen[r,c]) && forest[r][c] > 0) 
					{
						seen[r,c] = true;
						queue.Enqueue(new int[]{r, c, cur[2]+1});
					}
				}
			}
			return -1;
		}


		public static bool IsIsomorphic(string s, string t)
		{
			bool output = true;

			Dictionary<char, char> dict = new Dictionary<char, char>();

			if (s.Length != t.Length)
			{
				return false;
			}

			for (int i = 0; i < s.Length; i++)
			{
				if(!(dict.ContainsKey(s[i])))
				{
					dict.Add(s[i], t[i]);
				}
				else{

					if (dict[s[i]] != t[i])
					{
						return false;
					}
				}
			}
			return output;
		}

		public static int shortestDistance(string[] words, string word1, string word2)
		{
			int m = -1, n = -1;
			int min = int.MaxValue;

			for(int i = 0; i <words.Length ; i++)
			{
				string s = words[i];

				if (word1.Equals(s))
				{
					m = i;
					if (n != -1)
					{
						min = Math.Min(min, m - n);
					}
				}
				else if (word2.Equals(s))
				{
					n = i;
					if (m != -1)
					{
						min = Math.Min(min, n - m);
					}
				}
			}

			return min;
		}

		//same words
		public static int shortestDistanceIII(string[] words, string word1, string word2)
		{
			if (words == null || words.Length < 1 || word1 == null || word2 == null)
			{
				return 0;
			}

			int m = -1, n = -1;
			int min = int.MaxValue;

			int turn = 0;

			if (word1.Equals(word2))
			{
				turn = 1;
			}

			for (int i = 0; i < words.Length; i++)
			{
				string s = words[i];

				if (word1.Equals(s) && (turn ==1 || turn == 0))
				{
					m = i;

					if (turn == 1)
					{
						turn = 2;
					}

					if (n != -1)
					{
						min = Math.Min(min, m - n);
					}
				}
				else if (word2.Equals(s) && (turn == 2 || turn == 0))
				{
					n = i;

					if (turn == 2)
					{
						turn = 1;
					}

					if (m != -1)
					{
						min = Math.Min(min, n - m);
					}
				}
			}

			return min;
		}

		public static int depthSum(List<NestedInteger> nestedList)
		{
			return helper(nestedList, 1);
		}

		public static int helper(List<NestedInteger> nestedList, int depth)
		{
			if (nestedList == null || nestedList.Count == 0)
			{
				return 0;
			}

			int sum = 0;

			foreach (NestedInteger ni in nestedList)
			{
				if (ni.isInteger())
				{
					sum = sum + ni.getInteger() * depth;
				}
				else
				{
					sum = sum + helper(ni.getList(), depth + 1);
				}
			}

			return sum;
		}

		public static int[] SearchRange(int[] nums, int target)
		{

			int[] targetRange = { -1, -1 };

			// find the index of the leftmost appearance of `target`.
			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] == target)
				{
					targetRange[0] = i;
					break;
				}
			}

			// if the last loop did not find any index, then there is no valid range
			// and we return [-1, -1].
			if (targetRange[0] == -1)
			{
				return targetRange;
			}

			// find the index of the rightmost appearance of `target` (by reverse
			// iteration). it is guaranteed to appear.
			for (int j = nums.Length - 1; j >= 0; j--)
			{
				if (nums[j] == target)
				{
					targetRange[1] = j;
					break;
				}
			}

			return targetRange;
		}

		public static IList<string> FindRepeatedDnaSequences(string s)
		{
			var res = new HashSet<string>();
			const int Length = 10;
			var hashtable = new Dictionary<char, int> { { 'A', 1 }, { 'C', 2 }, { 'G', 3 }, { 'T', 4 } };
			var hashtableFor10LengthString = new Dictionary<long, int>();

			for (var i = 0; i < s.Length - 9; i++)
			{
				long rollinghash = 0;
				for (var j = 0; j < Length; j++)
				{
					// get rolling hash, base 10
					rollinghash = hashtable[s[i + j]] + rollinghash * 10;
				}

				if (hashtableFor10LengthString.ContainsKey(rollinghash))
				{
					res.Add(s.Substring(i, 10));
				}
				else
				{
					hashtableFor10LengthString.Add(rollinghash, i);
				}
			}

			return res.ToList();
		}

    }

    public class Interval
	{
       public int start;
       public int end;
       public Interval() { start = 0; end = 0; }
       public Interval(int s, int e) { start = s; end = e; }
    }


	class Interval2
	{
		public int start {get; set;}
		public int end  {get; set;}
		public char value  {get; set;}

		public Interval2(char value, int start)
		{
			this.value = value;
			this.start = start;
			this.end = start;
		}

		public String toString()
		{

			return value + "[" + start + ":" + end + "]";
		}
	}
}
