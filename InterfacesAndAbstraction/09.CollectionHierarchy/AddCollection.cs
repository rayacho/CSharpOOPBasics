using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy
{
	class AddCollection : IAddCollection
	{
		private List<string> data;
		private readonly List<int> indexes;

		public AddCollection()
		{
			data = new List<string>();
			indexes = new List<int>();
		}

		public void Add(string element)
		{
			int index = data.Count;
			indexes.Add(index);
			data.Add(element);
		}

		public override string ToString()
		{
			return $"{string.Join(" ", indexes)}";
		}
	}
}
