using System;

namespace UnityExtensions
{
	public static class TypeExtensions
	{
		public static object CreateInstance(this Type genericType, Type concreteType)
		{
			Type finalType = genericType.MakeGenericType(concreteType);
			object instance = Activator.CreateInstance(finalType);
			return instance;
		}
	}
}