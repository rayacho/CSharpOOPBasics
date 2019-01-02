using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy
{
	public class AddRemoveCollection : IAddRemoveCollection
	{
		private List<string> _data;
		private List<int> _indexes;
		private List<string> _removedElements;

		public AddRemoveCollection()
		{
			_data = new List<string>();
			_indexes = new List<int>();
			_removedElements = new List<string>();
		}

		public void Add(string element)
		{
			_indexes.Add(0);
			_data.Insert(0, element);
		}

		public void Remove()
		{
			string lastElement = _data[_data.Count - 1];
			_removedElements.Add(lastElement);
			_data.RemoveAt(_data.Count - 1);
		}

		public void GetRemovedElements()
		{
			Console.WriteLine($"{string.Join(" ", _removedElements)}");
		}

		public override string ToString()
		{
			return $"{string.Join(" ", _indexes)}";
		}
	}
}
