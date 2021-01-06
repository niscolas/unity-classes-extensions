using System;
using System.Collections;
using UnityEngine;

namespace __Utils._ClassExtensions.UnityExtensions {
	public static class MonoBehaviourExtensions {
		public static void DoAfterFrames(this MonoBehaviour monoBehaviour, Action action, int frames = 1) {
			monoBehaviour.StartCoroutine(DoAfterFramesRoutine(action, frames));
		}

		private static IEnumerator DoAfterFramesRoutine(Action action, int frames) {
			while (frames > 0) {
				yield return new WaitForEndOfFrame();

				frames--;
			}

			action?.Invoke();
		}

		public static Coroutine DoAfterSeconds(
			this MonoBehaviour monoBehaviour, Action action, float timeInSeconds, bool unscaledTime = false
		) {
			return monoBehaviour
				? monoBehaviour.StartCoroutine(DoAfterSeconds(action, timeInSeconds, unscaledTime))
				: null;
		}

		private static IEnumerator DoAfterSeconds(Action action, float timeInSeconds, bool unscaledTime = false) {
			if (unscaledTime) {
				yield return new WaitForSecondsRealtime(timeInSeconds);
			}
			else {
				yield return new WaitForSeconds(timeInSeconds);
			}

			action?.Invoke();
		}
	}
}