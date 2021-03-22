using UnityEngine;

namespace Plugins.ClassExtensions.UnityExtensions
{
	public static class CameraExtensions
	{
		public static Vector3 GetPointerPosition(this Camera camera)
		{
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);

			Vector3 result = Physics.Raycast(ray, out RaycastHit hit) ? hit.point : Vector3.zero;

			return result;
		}

		public static bool GetIsWorldPointVisible(this Camera camera, Vector3 position)
		{
			Vector3 viewportPoint = camera.WorldToViewportPoint(position);

			return
				viewportPoint.x >= 0 && viewportPoint.x <= 1 &&
				viewportPoint.y >= 0 && viewportPoint.y <= 1 &&
				viewportPoint.z > 0;
		}

		public static Vector3 GetWorldPositionWithRaycast(this Camera camera, Vector3 viewportPos)
		{
			Ray ray = camera.ViewportPointToRay(viewportPos);

			return Physics.Raycast(ray, out RaycastHit hit) ? hit.point : Vector3.zero;
		}
	}
}