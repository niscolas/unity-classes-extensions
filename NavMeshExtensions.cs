using UnityEngine.AI;

namespace __Utils._ClassExtensions.UnityExtensions {
	public static class NavMeshExtensions {
		private const float SampleRadius = 50f;

		public static bool GetIsStoppingDistanceReached(this NavMeshAgent navMeshAgent) {
			return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance;
		}

		public static void BuildOrUpdateNavMesh(this NavMeshSurface navMeshSurface) {
			if (navMeshSurface.navMeshData == null) {
				navMeshSurface.BuildNavMesh();
			}
			else {
				navMeshSurface.UpdateNavMesh(navMeshSurface.navMeshData);
			}
		}
	}
}