using System;

namespace UnityExtensions
{
	public static class IntExtensions
	{
		public static bool IsValidIndex(this int i, int length)
		{
			return i >= 0 && i < length;
		}

		public static int FlattenIndex(this ValueTuple<int, int> index2d, int width)
		{
			(int row, int col) = index2d;
			int flattenedIndex = width * row + col;
			return flattenedIndex;
		}
	}
}