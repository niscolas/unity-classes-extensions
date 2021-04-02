using UnityEditor;
using UnityEngine;

namespace UnityExtensions
{
	public static class ObjectExtensions
	{
		public static void Rename(this Object obj, string newName)
		{
#if UNITY_EDITOR
			string objPath = AssetDatabase.GetAssetPath(obj.GetInstanceID());

			AssetDatabase.RenameAsset(objPath, newName);
			AssetDatabase.SaveAssets();
#endif
		}

		public static bool IsNull(this object obj)
		{
			return obj == null || obj.Equals(null);
		}
	}
}