using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy
{
	public class MyList : IMylist
	{
		private List<string> data;
		private List<int> indexes;
		private List<string> removedElements;

		public MyList()
		{
			data = new List<string>();
			indexes = new List<int>();
			removedElements = new List<string>();
		}

		public int NumberOfElements
		{
			get => data.Count;
		}

		public void Add(string element)
		{
			indexes.Add(0);
			data.Insert(0, element);
		}

		public void Remove()
		{
			string firstElement = data[0];
			removedElements.Add(firstElement);
			data.RemoveAt(0);
		}

		public void GetRemovedElements()
		{
			Console.WriteLine($"{string.Join(" ", removedElements)}");
		}

		public override string ToString()
		{
			return $"{string.Join(" ", indexes)}";
		}
	}
}
