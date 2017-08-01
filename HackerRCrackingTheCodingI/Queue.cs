using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRCrackingTheCodingI
{
	class Queue
	{
	}

	class MyQueue
	{
		MyStack stack1;
		MyStack stack2;

		public MyQueue()
		{
			this.stack1 = new MyStack();
			this.stack2 = new MyStack();
		}

		public MyQueue(int x)
		{
			this.stack1 = new MyStack(x);
			this.stack2 = new MyStack(x);
		}

		public void Enqueue(int p)
		{
			stack1.Push(p);
		}

		public void Dequeue()
		{
			if (stack2.IsEmpty())
			{
				while (!(stack1.IsEmpty()))
				{
					stack2.Push(stack1.Peek());
					stack1.Pop();
				}

				stack2.Pop();
			}
			else
			{
				stack2.Pop();
			}

		}

		public void Display()
		{
			stack1.Display();
			stack2.Display();
		}

		public void Peek()
		{
			if (stack2.IsEmpty())
			{
				while (!(stack1.IsEmpty()))
				{
					stack2.Push(stack1.Peek());
					stack1.Pop();
				}

				Console.WriteLine(stack2.Peek());
			}
			else
			{
				int head = 0;
				int i = 0;
				while (stack2.stackArray[i] != 0)
				{
					head = stack2.stackArray[i];
					i++;

				}
				Console.WriteLine(head);
			}
		}
	}
}
