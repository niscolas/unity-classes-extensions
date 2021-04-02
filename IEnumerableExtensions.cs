using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityExtensions
{
	public static class EnumerableExtensions
	{
		public static T RandomElement<T>(this IEnumerable<T> enumerable)
		{
			return enumerable.RandomElementUsing(new Random());
		}

		public static T RandomElementUsing<T>(this IEnumerable<T> enumerable, Random rand)
		{
			int index = rand.Next(0, enumerable.Count());
			return enumerable.ElementAt(index);
		}

		public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
		{
			return enumerable == null || !enumerable.Any();
		}

		public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
		{
			foreach (T element in enumerable)
			{
				action?.Invoke(element);
			}
		}

		public static bool HasNullElements<T>(this IEnumerable<T> enumerable)
		{
			T[] array = enumerable.ToArray();
			if (array.IsNullOrEmpty())
			{
				return true;
			}

			foreach (T element in array)
			{
				if (element == null)
				{
					return true;
				}
			}

			return false;
		}
	}
}