using UnityEngine;

namespace Plugins {
	public static class ColliderExtensions {
		public static Vector3 GetRandomPoint(this Collider collider) {
			Bounds bounds = collider.bounds;
			
			Vector3 point = new Vector3(
				Random.Range(bounds.min.x, bounds.max.x),
				Random.Range(bounds.min.y, bounds.max.y),
				Random.Range(bounds.min.z, bounds.max.z)
			);

			if (point != collider.ClosestPoint(point)) {
				point = GetRandomPoint(collider);
			}

			return point;
		}
	}
}