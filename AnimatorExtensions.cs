using System;
using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Plugins.CsharpExtensions;
using UnityEngine;

namespace Plugins.ClassExtensions.UnityExtensions
{
	public static class AnimatorExtensions
	{
		public static async Task WaitUntilGivenStateEnd(
			this Animator animator, string stateName, int layerIndex = 0
		)
		{
			AnimatorStateInfo currentStateInfo;
			do
			{
				await UniTask.Yield();

				if (animator)
				{
					currentStateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);
				}
				else
				{
					return;
				}
			} while (animator.IsInTransition(layerIndex) || !currentStateInfo.IsName(stateName));

			do
			{
				await UniTask.Yield();

				if (animator)
				{
					currentStateInfo = animator.GetCurrentAnimatorStateInfo(layerIndex);
				}
				else
				{
					return;
				}
			} while (currentStateInfo.IsName(stateName) && currentStateInfo.normalizedTime < 1);
		}

		public static bool GetIsMainLayerOrHasWeight(this Animator animator, int layerIndex)
		{
			return layerIndex == 0 || animator.GetLayerWeight(layerIndex) > 0;
		}

		public static string GetCurrentAnimationName(this Animator animator, int layer = 0)
		{
			AnimatorClipInfo[] clipsInfo = animator.GetCurrentAnimatorClipInfo(layer);

			return clipsInfo.IsNullOrEmpty() ? null : clipsInfo[0].clip.name;
		}

		public static string GetNextAnimationName(this Animator animator, int layer = 0)
		{
			AnimatorClipInfo[] clipsInfo = animator.GetNextAnimatorClipInfo(layer);

			return clipsInfo.IsNullOrEmpty() ? null : clipsInfo[0].clip.name;
		}

		public static float GetCurrentAnimationLength(this Animator animator, int layer = 0)
		{
			return animator.GetCurrentAnimatorStateInfo(layer).length;
		}

		public static float GetCurrentAnimationTime(this Animator animator, int layer = 0)
		{
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(layer);
			AnimatorClipInfo[] clipsInfo = animator.GetCurrentAnimatorClipInfo(layer);

			if (!clipsInfo.IsNullOrEmpty())
			{
				return clipsInfo[0].clip.length * stateInfo.normalizedTime;
			}

			return 0;
		}

		public static float GetRemainingAnimationTime(this Animator animator, int layer = 0)
		{
			return animator.GetCurrentAnimationLength(layer) - animator.GetCurrentAnimationTime(layer);
		}

		public static bool HasParameter(this Animator animator, string paramName)
		{
			for (int i = 0; i < animator.parameters.Length; i++)
			{
				if (animator.parameters[i].name == paramName)
				{
					return true;
				}
			}

			return false;
		}

		public static float GetAnimationClipLength(this RuntimeAnimatorController animator, string stateName)
		{
			return (
				from clip in animator.animationClips
				where clip.name.Equals(stateName, StringComparison.InvariantCultureIgnoreCase)
				select clip.length
			).FirstOrDefault();
		}
	}
}