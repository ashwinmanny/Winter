using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter.ArrayProblems
{
	class ArraySolution
	{
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

		public int[] TwoSumUnsorted(int[] nums, int target)
		{
			var dict = new Dictionary<int, int>();

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
    }

    public class Interval
	{
       public int start;
       public int end;
       public Interval() { start = 0; end = 0; }
       public Interval(int s, int e) { start = s; end = e; }
    }
}
