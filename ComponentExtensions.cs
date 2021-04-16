using System;
using System.Reflection;
using UnityEngine;

namespace UnityExtensions
{
	public static class ComponentExtensions
	{
		public static T GetCopyOf<T>(this Component component, T other) where T : Component
		{
			Type type = component.GetType();

			if (type != other.GetType()) return null;

			BindingFlags flags = BindingFlags.Public | 
			                     BindingFlags.NonPublic | 
			                     BindingFlags.Instance | 
			                     BindingFlags.Default |
			                     BindingFlags.DeclaredOnly;
			
			PropertyInfo[] propertyInfos = type.GetProperties(flags);
			foreach (PropertyInfo propertyInfo in propertyInfos)
			{
				if (!propertyInfo.CanWrite)
				{
					continue;
				}

				try
				{
					propertyInfo.SetValue(component, propertyInfo.GetValue(other, null), null);
				}
				catch { }
			}

			FieldInfo[] fieldInfos = type.GetFields(flags);
			foreach (FieldInfo fieldInfo in fieldInfos)
			{
				fieldInfo.SetValue(component, fieldInfo.GetValue(other));
			}

			return component as T;
		}
	}
}