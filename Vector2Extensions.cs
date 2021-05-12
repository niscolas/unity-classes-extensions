using UnityEngine;

namespace UnityExtensions
{
	public static class Vector2Extensions
	{
		public static int Compare(this Vector2 self, Vector2 other)
		{
			if (self.x > other.x && self.y > other.y)
			{
				return 1;
			}

			if (self.x < other.x && self.y < other.y)
			{
				return -1;
			}

			return 0;
		}

		public static float Random(this Vector2 self)
		{
			return UnityEngine.Random.Range(self.x, self.y);
		}

		public static float DistanceFrom(this Vector2 baseVector, Vector2 target)
		{
			return (baseVector - target).sqrMagnitude;
		}

		public static Vector3 PointerAs3dPosition(this Vector2 pointerPosition, Camera camera = null)
		{
			if (!camera)
			{
				camera = Camera.main;
			}

			Vector3 worldPoint = camera.ScreenToWorldPoint(pointerPosition);
			return worldPoint;
		}

		public static Vector2 RandomPointInRing(this Vector2 origin, float minRadius, float maxRadius)
		{
			Vector2 v = UnityEngine.Random.insideUnitCircle;
			return origin + (v.normalized * minRadius + v * (maxRadius - minRadius));
		}
	}
}