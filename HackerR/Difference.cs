using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerR
{
	class Difference
	{
		private int[] elements;
		public int maximumDifference;

		public Difference(int[] elements)
		{
			this.elements = elements;
		}

		public void computeDifference()
		{
			int sum = 0;
			int temp_sum = sum;
			foreach (int number in elements)
			{


				for (int i = 0; i < elements.Length; i++)
				{
					temp_sum = Math.Abs(number - elements[i]);

					if (elements.First() == number)
					{
						sum = temp_sum;
					}

					if (temp_sum > sum)
					{
						sum = temp_sum;
					}

				}	
			}
			this.maximumDifference = sum;
		}

	}
}
