using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerR
{
	abstract class Book
	{
		protected String title;
		protected String author;

		public Book(String t, String a)
		{
			title = t;
			author = a;
		}
		public abstract void display();

	}

	class MyBook : Book
	{
		public  int price {get;set;}

		public MyBook(string title, string author, int price) : base(title,author)
		{
			this.title = title;
			this.author = author;
			this.price = price;
		}

	    override public void display()
		{
			System.Console.WriteLine("Title: "+this.title);
			System.Console.WriteLine("Author: " + this.author);
			System.Console.WriteLine("Price: " + this.price);
		}
	}
}
