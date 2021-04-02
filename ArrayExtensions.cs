using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityExtensions
{
	public static class ArrayExtensions
	{
		public static IEnumerable<T> GetColumn<T>(this T[][] jaggedArray, int column)
		{
			return jaggedArray.Select(row => row[column]);
		}

		public static void ShiftLeft<T>(this T[] array, Action<T, T, int> callback = null)
		{
			T temp = array[0];

			int lastIndex = array.Length - 1;
			for (int i = 0; i < lastIndex; i++)
			{
				int j = i + 1;

				callback?.Invoke(array[j], array[i], i);

				array[i] = array[j];
			}

			callback?.Invoke(temp, array[lastIndex], lastIndex);
			array[lastIndex] = temp;
		}

		public static void ShiftRight<T>(this T[] array, Action<T, T, int> callback = null)
		{
			int lastIndex = array.Length - 1;
			T temp = array[lastIndex];

			for (int i = lastIndex; i > 0; i--)
			{
				int j = i - 1;

				callback?.Invoke(array[j], array[i], i);

				array[i] = array[j];
			}

			callback?.Invoke(temp, array[0], 0);
			array[0] = temp;
		}

		public static void ShiftUp<T>(this T[][] array2d, int column, Action<T, T, int> callback = null)
		{
			T temp = array2d[0][column];

			int lastIndex = array2d.Length - 1;
			for (int i = 0; i < lastIndex; i++)
			{
				int j = i + 1;

				callback?.Invoke(array2d[j][column], array2d[i][column], i);

				array2d[i][column] = array2d[j][column];
			}

			callback?.Invoke(temp, array2d[lastIndex][column], lastIndex);
			array2d[lastIndex][column] = temp;
		}

		public static void ShiftDown<T>(this T[][] array2d, int column, Action<T, T, int> callback = null)
		{
			int lastIndex = array2d.Length - 1;
			T temp = array2d[lastIndex][column];

			for (int i = array2d.Length - 1; i > 0; i--)
			{
				int j = i - 1;

				callback?.Invoke(array2d[j][column], array2d[i][column], i);

				array2d[i][column] = array2d[j][column];
			}

			callback?.Invoke(temp, array2d[0][column], 0);
			array2d[0][column] = temp;
		}
	}
}