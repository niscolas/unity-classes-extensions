using UnityEngine.Animations;

namespace UnityExtensions
{
	public static class ParentConstraintExtensions
	{
		public static void RemoveAllSources(this ParentConstraint parentConstraint)
		{
			for (int i = 0; i < parentConstraint.sourceCount; i++)
			{
				parentConstraint.RemoveSource(0);
			}
		}
	}
}