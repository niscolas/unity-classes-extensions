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

		public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> enumerable)
		{
			return enumerable != null && enumerable.Any();
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

		public static bool IsValid<T>(this IEnumerable<T> enumerable)
		{
			if (enumerable == null)
			{
				return false;
			}

			T[] array = enumerable.ToArray();

			if (array.Length == 0)
			{
				return false;
			}

			bool isValid = array.All(element => element != null);
			return isValid;
		}

		public static T[] AsArray<T>(this IEnumerable<T> enumerable)
		{
			return enumerable as T[] ?? enumerable.ToArray();
		}

		public static List<T> AsList<T>(this IEnumerable<T> enumerable)
		{
			return enumerable as List<T> ?? enumerable.ToList();
		}
	}
}