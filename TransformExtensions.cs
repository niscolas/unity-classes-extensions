using UnityEngine;

namespace Plugins.ClassExtensions.UnityExtensions {
	public static class TransformExtensions {
		public static Vector3 GetAppliedRotation(this Vector3 direction, Transform referential) {
			Vector3 referentialForward = referential.forward;
			Vector3 referentialRight = referential.right;

			referentialForward.y = 0f;
			referentialRight.y = 0f;
			referentialForward = referentialForward.normalized;
			referentialRight = referentialRight.normalized;

			return referentialForward * direction.z + referentialRight * direction.x;
		}

		public static Quaternion? GetLookDirection(this Vector2 lookDirection, Transform referential) {
			return new Vector3(lookDirection.x, 0, lookDirection.y).GetLookDirection(referential);
		}

		public static Quaternion? GetLookDirection(this Vector3 lookDirection, Transform referential) {
			Vector3 lookRot = referential.TransformDirection(lookDirection);
			lookRot = Vector3.ProjectOnPlane(lookRot, Vector3.up);

			Quaternion? newRotation = null;
			if (lookRot != Vector3.zero) {
				newRotation = Quaternion.LookRotation(lookRot);
			}

			return newRotation;
		}

		public static Transform FindInAllChildrenHierarchy(this Transform transform, string name) {
			Transform directChildFound = transform.Find(name);

			if (directChildFound != null) {
				return directChildFound;
			}

			foreach (Transform child in transform) {
				Transform notDirectChildFound = FindInAllChildrenHierarchy(child, name);

				if (notDirectChildFound != null) {
					return notDirectChildFound;
				}
			}

			return null;
		}

		public static void DestroyChildren(this Transform transform) {
			foreach (Transform child in transform) {
				Object.Destroy(child.gameObject);
			}
		}

		public static float AngleTo(this Transform transform, Vector3 targetPos) {
			Vector3 targetDir = targetPos - transform.position;
			return Vector3.Angle(targetDir, transform.forward);
		}
	}
}