using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winter.SortingProblems
{
	class SortingSolution
	{
		public void Merge(int[] nums1, int m, int[] nums2, int n)
		{
			int indexm = m - 1;
			int indexn = n - 1;

			while (indexm >= 0 && indexn >= 0)
				{
					if (nums1[indexm] > nums2[indexn])
					{
						Array.Resize(ref nums1, nums1.Length + 1);
						nums1[indexm + indexn + 1] = nums1[indexm];
						indexm--;
					}
					else
					{
						Array.Resize(ref nums1, nums1.Length + 1);
						nums1[indexm + indexn + 1] = nums2[indexn];
						indexn--;

					}
				}

		}

		public int RemoveDuplicates(int[] nums)
		{
			if (nums == null || nums.Length == 0) return 0;

			int i = 0; 
			{
			   for (int j = 1; j < nums.Length; j++)
			   {
				   if (nums[j] != nums[i])
				   {
					   nums[i + 1] = nums[j];
					   i++;
				   }
			   }

			}

			return i + 1;
		}

		public double FindMedianSortedArrays(int[] nums1, int[] nums2)
		{
			List<int> sortedlist = new List<int>();

			sortedlist = nums1.ToList();
			sortedlist = sortedlist.Concat(nums2.ToList()).ToList();

			sortedlist.Sort();

			int medianIndex1 = 0;
			int medianIndex2 = 0;
			double medianValue = 0;

			if (sortedlist.Count % 2 == 0)
			{
				medianIndex1 = (int)(Math.Floor(((double)(sortedlist.Count - 1) / 2)));
				medianIndex2 = (sortedlist.Count) / 2;
				medianValue = (double)(sortedlist[medianIndex1] + sortedlist[medianIndex2]) / 2;

			}
			else
			{
				medianIndex1 = (sortedlist.Count  -1 )/2;
				medianValue = sortedlist[medianIndex1];
			}

			return medianValue;

		}

		// Maximum product of three numbers
		public int MaximumProduct(int[] nums)
		{
			Array.Sort(nums);

			int output = 0;

			int output1 = nums[nums.Length-1] * nums[nums.Length-2] * nums[nums.Length-3];

			int output2 = nums[0] * nums[1] * nums[nums.Length-1];

			if (output1 > output2)
			{
				output = output1;
			}
			else
			{
				output = output2;
			}

			return output;
		}
	}
}
