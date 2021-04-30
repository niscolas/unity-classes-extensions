using System.Collections.Generic;

namespace Plugins.UnityExtensions
{
	public static class DictionaryExtensions
	{
		public static void AddManyKeys<TKey, TValue>
		(
			this IDictionary<TKey, TValue> dictionary, IEnumerable<TKey> keys, TValue value
		)
		{
			if (dictionary == null) return;

			foreach (TKey key in keys)
			{
				if (key == null ||
				    dictionary.ContainsKey(key)) continue;

				dictionary.Add(key, value);
			}
		}
	}
}