using System.Collections.Generic;

namespace Plugins.UnityExtensions
{
	public static class CollectionExtensions
	{
		public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> otherEnumerable)
		{
			foreach (T enumerableElement in otherEnumerable)
			{
				collection.Add(enumerableElement);
			}
		}
	}
}