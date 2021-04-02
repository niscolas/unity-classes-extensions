using System;

namespace UnityExtensions
{
	public static class FloatExtensions
	{
		private static readonly Random _random = new Random();

		public static float Round(this float number, int decimalPlaces)
		{
			return (float) Math.Round(number, decimalPlaces);
		}

		public static bool GetIsBetween(this float value, float min, float max, bool inclusive = true)
		{
			return inclusive && value >= min && value <= max ||
			       !inclusive && value > min && value < max;
		}

		public static float GetNearest(this float value, float test1, float test2)
		{
			float absValue = Math.Abs(value);
			float absTest1 = Math.Abs(test1);
			float absTest2 = Math.Abs(test2);

			float difference1 = Math.Abs(absTest1 - absValue);
			float difference2 = Math.Abs(absTest2 - absValue);

			if (difference1 <= difference2)
			{
				return test1;
			}

			return test2;
		}

		public static float Randomize(this float number, float randomizationRate)
		{
			float baseRandom = number * randomizationRate;
			float result = _random.NextFloat(number - baseRandom, number + baseRandom);
			return result;
		}
	}
}