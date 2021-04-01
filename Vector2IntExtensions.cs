using UnityEngine;

namespace Plugins.UnityExtensions
{
	public static class Vector2IntExtensions
	{
		public static int Random(this Vector2Int self)
		{
			return UnityEngine.Random.Range(self.x, self.y + 1);
		}
	}
}