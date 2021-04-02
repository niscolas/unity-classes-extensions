using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityExtensions
{
	public static class ListExtensions
	{
		private static readonly Random RandomGen = new Random();

		public static void Replace<T>(this List<T> list, T current, T replacement)
		{
			int index = list.IndexOf(current);
			if (index >= 0)
			{
				list[index] = replacement;
			}
		}

		public static void RemoveRange<T>(this IList<T> list, IEnumerable<T> elementsToRemove)
		{
			foreach (T element in elementsToRemove.Where(list.Contains))
			{
				list.Remove(element);
			}
		}
	}
}