using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy
{
	public class AddRemoveCollection : IAddRemoveCollection
	{
		private List<string> data;
		private List<int> indexes;
		private List<string> removedElements;

		public AddRemoveCollection()
		{
			data = new List<string>();
			indexes = new List<int>();
			removedElements = new List<string>();
		}

		public void Add(string element)
		{
			indexes.Add(0);
			data.Insert(0, element);
		}

		public void Remove()
		{
			string lastElement = data[data.Count - 1];
			removedElements.Add(lastElement);
			data.RemoveAt(data.Count - 1);
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
