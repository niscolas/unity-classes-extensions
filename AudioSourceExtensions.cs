using UnityEngine;

namespace Plugins.UnityExtensions
{
	public static class AudioSourceExtensions
	{
		public static void TogglePlay(this AudioSource audioSource)
		{
			if (audioSource.isPlaying)
			{
				audioSource.Pause();
			}
			else
			{
				audioSource.Play();
			}
		}
	}
}