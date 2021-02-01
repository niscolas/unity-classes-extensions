using Cysharp.Threading.Tasks;
using UnityEngine.AI;

namespace Plugins.UnityClassesExtensions {
	public static class NavMeshExtensions {
		public static async UniTask WaitForDestinationReached(this NavMeshAgent navMeshAgent, float tolerance = 0.3f) {
			while (navMeshAgent.remainingDistance > tolerance) {
				await UniTask.Yield();
				await UniTask.NextFrame();
			}
		}
	}
}