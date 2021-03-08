using UnityEngine;

namespace Plugins.ClassExtensions.UnityExtensions {
	public static class Vector2Extensions {
		public static int Compare(this Vector2 self, Vector2 other) {
			if (self.x > other.x && self.y > other.y) {
				return 1;
			}

			if (self.x < other.x && self.y < other.y) {
				return -1;
			}

			return 0;
		}

		public static float Random(this Vector2 self) {
			return UnityEngine.Random.Range(self.x, self.y);
		}
		
		public static float DistanceFrom(this Vector2 baseVector, Vector2 target) {
			return (baseVector - target).sqrMagnitude;
		}
	}
}