using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerR
{
	class Person
	{
		protected string firstName;
		protected string lastName;
		protected int id;

		public Person() { }
		public Person(string firstName, string lastName, int identification)
		{
			this.firstName = firstName;
			this.lastName = lastName;
			this.id = identification;
		}
		public void printPerson()
		{
			Console.WriteLine("Name: " + lastName + ", " + firstName + "\nID: " + id);
		}
	}

	class Student : Person
	{
		private int[] testScores;

		public Student(string firstName, string lastName, int id, int[] scores)
		{
			this.firstName = firstName;
			this.lastName = lastName;
			this.id = id;
			this.testScores = scores;
		}

		char calculate()
		{
			int i = 1;
			int sum = 0;
			foreach (int score in testScores)
			{
				sum = sum + score;
				i++;
			}
			int average = sum/i;

			if(average >=90 && average <=100)
			{
				return 'O';
			}
			else if(average >=80 && average <=90)
			{
				return 'E';
			}
			else if(average >=70 && average <=80)
			{
				return 'A';
			}
			else if(average >=55 && average <=70)
			{
				return 'P';
			}
			else if(average >=40 && average <=55)
			{
				return 'D';
			}
			else
			{
				return 'T';
			}

		}
	}
}
