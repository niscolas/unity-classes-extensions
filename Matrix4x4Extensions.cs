using UnityEngine;

namespace Plugins.ClassExtensions.UnityExtensions
{
	public static class Matrix4x4Extensions
	{
		public static Vector3 GetPosition(this Matrix4x4 matrix4x4)
		{
			return matrix4x4.GetColumn(3);
		}
	}
}