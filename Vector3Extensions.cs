using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UnityExtensions
{
	public static class Vector3Extensions
	{
		public static float DistanceFrom(this Vector3 vector, Vector3 target)
		{
			return (vector - target).sqrMagnitude;
		}

		public static Vector3[] GetRandomPointsInRadius(this Vector3 origin, float radius, int numPoints,
			bool radius3d = false)
		{
			Vector3[] points = new Vector3[numPoints];
			for (int i = 0; i < numPoints; i++)
			{
				if (radius3d)
				{
					points[i] = origin + Random.insideUnitSphere * radius;
				}
				else
				{
					Vector2 randomPos2d = Random.insideUnitCircle * radius;
					points[i] = origin + new Vector3(randomPos2d.x, origin.y, randomPos2d.y);
				}
			}

			return points;
		}

		public static Quaternion GetRotationTo(this Vector3 origin, Vector3 target)
		{
			Vector3 direction = (target - origin).normalized;

			return Quaternion.LookRotation(direction);
		}

		public static Vector3 RotatePointAround(this Vector3 pivot, Vector3 point, Vector3 angles)
		{
			Vector3 dir = point - pivot;
			dir = Quaternion.Euler(angles) * dir;
			point = dir + pivot;
			return point;
		}

		public static Vector3[] GetPointsBetween(
			this Vector3 origin, Vector3 target, int numPoints, float startPadding = 0, float endPadding = 0f
		)
		{
			Vector3[] points = new Vector3[numPoints];
			Vector3 paddingVector = (target - origin).normalized;

			Vector3 startPaddingVector = paddingVector * startPadding;
			Vector3 endPaddingVector = paddingVector * endPadding;

			float spacingPercentage = (float) 1 / numPoints;
			for (int i = 0; i < numPoints; i++)
			{
				float interpolationPoint = (i + 0.5f) * spacingPercentage;

				Vector3 itemPosition = Vector3.Lerp(
					origin - startPaddingVector,
					target + endPaddingVector,
					interpolationPoint
				);

				points[i] = itemPosition;
			}

			return points;
		}

		public static Vector3 GetOutsideBoundsVector(this Vector3 center, Vector3 size, Vector3 point)
		{
			float absSizeX = Math.Abs(size.x);
			float absSizeY = Math.Abs(size.y);
			float absSizeZ = Math.Abs(size.z);

			float leftOffsetLimit = center.x - absSizeX;
			float rightOffsetLimit = center.x + absSizeX;
			float upOffsetLimit = center.y + absSizeY;
			float downOffsetLimit = center.y - absSizeY;
			float forwardOffsetLimit = center.z + absSizeZ;
			float backOffsetLimit = center.z - absSizeZ;

			Vector3 result = Vector3.zero;

			if (point.x < leftOffsetLimit)
			{
				result.x = point.x - leftOffsetLimit;
			}
			else if (point.x > rightOffsetLimit)
			{
				result.x = point.x - rightOffsetLimit;
			}

			if (point.y > upOffsetLimit)
			{
				result.y = point.y - upOffsetLimit;
			}
			else if (point.y < downOffsetLimit)
			{
				result.y = point.y - downOffsetLimit;
			}

			if (point.z > forwardOffsetLimit)
			{
				result.z = point.z - forwardOffsetLimit;
			}
			else if (point.z < backOffsetLimit)
			{
				result.z = point.z - backOffsetLimit;
			}

			return result;
		}
	}
}