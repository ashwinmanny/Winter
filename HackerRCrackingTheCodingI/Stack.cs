using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRCrackingTheCodingI
{
	class Stack
	{
	}

	class MyStack
	{
		public int top;
		public int stackMaxSize { get; set; }
		public int[] stackArray;

		public MyStack()
		{
			this.stackMaxSize = 100000;
			this.stackArray = new int[stackMaxSize];
			this.top = -1;
		}

		public MyStack(int x)
		{
			this.stackMaxSize = x;
			this.stackArray = new int[stackMaxSize];
			this.top = -1;
		}

		public bool IsEmpty()
		{
			if (top == -1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool IsFull()
		{
			if (this.top == (this.stackMaxSize - 1))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Push(int x)
		{
			if (IsFull())
			{
				Console.WriteLine("Stack is full");
			}
			else
			{
				top++;
				stackArray[top] = x;
				//Console.WriteLine("Item {0} pushed successfully!", x);

			}
		}

		public void Pop()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Stack is empty");
			}
			else
			{
				int topItem = stackArray[top];
				stackArray[top] = 0;
				top--;
				//Console.WriteLine("Item {0} popped successfully!", topItem);
			}
		}

		public int Peek()
		{
			if (IsEmpty())
			{
				Console.WriteLine("Stack is empty");
				return -1;
			}
			else
			{
				return this.stackArray[top];
			}
		}

		public void Display()
		{
			if (!IsEmpty())
			{
				foreach (int item in this.stackArray)
				{
					if (item != 0)
					{
						Console.WriteLine(item);
					}
				}
			}
		}

	}

}
