using System;
using System.Reflection;
using UnityEngine;
using UnityExtensions;

namespace Plugins.UnityExtensions
{
	public static class StringExtensions
	{
		public static string WithoutSpaces(this string str)
		{
			return str.Replace(" ", "");
		}
		
		public static string Without(this string str, string toRemove)
		{
			return str.Replace(toRemove, "");
		}
		
		public static Type FindType(this string fullTypeName, params Assembly[] assembliesToSearch)
		{
			if (string.IsNullOrEmpty(fullTypeName))
			{
				Debug.LogWarning($"The input Type was null or empty");
				return null;
			}

			if (assembliesToSearch.IsNullOrEmpty())
			{
				assembliesToSearch = AppDomain.CurrentDomain.GetAssemblies();
			}

			foreach (Assembly assembly in assembliesToSearch)
			{
				Type type = assembly.GetType(fullTypeName);

				if (type != null)
				{
					return type;
				}
			}

			Debug.LogWarning($"Couldn't find the Type for \"{fullTypeName}\"");
			return null;
		}

		public static string SubstringUntilLastCharacter(this string str, char lastCharacter)
		{
			int lastIndex = str.LastIndexOf(lastCharacter);
			string substr = str.Substring(0, lastIndex);
			return substr;
		}
	}
}