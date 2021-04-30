using Plugins.UnityExtensions;
using UnityEditor;
using UnityEngine;

namespace UnityExtensions
{
	public static class UnityObjectExtensions
	{
		private const char DirectorySeparatorChar = '/';

#if UNITY_EDITOR
		public static string FolderPath(this Object asset)
		{
			string assetPath = AssetDatabase.GetAssetPath(asset);
			string folderPath = assetPath.SubstringUntilLastCharacter(DirectorySeparatorChar);

			return folderPath;
		}
#endif

		public static void Create(this Object asset, string fullPath)
		{
#if UNITY_EDITOR
			string fullFolderPath = fullPath.SubstringUntilLastCharacter(DirectorySeparatorChar);

			if (!AssetDatabase.IsValidFolder(fullFolderPath))
			{
				string parentFolderPath = fullFolderPath.SubstringUntilLastCharacter(DirectorySeparatorChar);
				int lastDirSeparatorCharIndex = fullFolderPath.LastIndexOf(DirectorySeparatorChar);
				string newFolderName = fullFolderPath.Substring(lastDirSeparatorCharIndex + 1);

				AssetDatabase.CreateFolder(parentFolderPath, newFolderName);
			}

			AssetDatabase.CreateAsset(asset, fullPath);
			AssetDatabase.SaveAssets();
#endif
		}

		public static void SelfDelete(this Object obj)
		{
#if UNITY_EDITOR
			string assetPath = AssetDatabase.GetAssetPath(obj);

			AssetDatabase.DeleteAsset(assetPath);
			AssetDatabase.SaveAssets();
#endif
		}

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