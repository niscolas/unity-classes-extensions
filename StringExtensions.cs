using System;
using System.Reflection;

namespace Plugins.UnityExtensions
{
	public static class StringExtensions
	{
		public static Type FindType(this string fullTypeName, Assembly[] assembliesToSearch = null)
		{
			if (assembliesToSearch == null)
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

			return null;
		}
	}
}