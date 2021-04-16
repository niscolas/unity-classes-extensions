namespace UnityExtensions
{
	public static class StructExtensions
	{
		public static bool IsDefault<T>(this T obj) where T : struct
		{
			return obj.Equals(default);
		}
	}
}