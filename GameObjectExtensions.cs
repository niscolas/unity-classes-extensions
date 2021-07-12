using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityExtensions
{
	public static class GameObjectExtensions
	{
		public static bool IsPrefab(this GameObject gameObject)
		{
			return gameObject.scene.rootCount == 0;
		}

		public static T AddComponent<T>(this GameObject gameObject, T toAdd) where T : Component
		{
			return gameObject.AddComponent<T>().GetCopyOf(toAdd);
		}

		public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
		{
			if (!gameObject) return default;

			T component = gameObject.GetComponent<T>();

			if (!component)
			{
				component = gameObject.AddComponent<T>();
			}

			return component;
		}

		public static T GetSafeComponent<T>(this GameObject gameObject)
		{
			T component = gameObject.GetComponent<T>();

			if (component == null)
			{
				Debug.LogWarning("No " + typeof(T) + " on " + gameObject.name, gameObject);
			}

			return component;
		}

		public static T GetComponentInSiblings<T>(this GameObject gameObject)
		{
			Transform parent = gameObject.transform.parent;

			return parent == null ? default : parent.GetComponentInChildren<T>();
		}

		public static TTest IfNullAddComponent<TTest, TAdd>(this GameObject gameObject)
			where TAdd : Component, TTest
		{
			TTest component = gameObject.GetSafeComponent<TTest>();

			if (component.IsUnityNull())
			{
				component = gameObject.AddComponent<TAdd>();
			}

			return component;
		}

		public static T IfNullGetComponent<T>(this GameObject gameObject, T test, bool searchChildren = false)
		{
			if (test.IsUnityNull())
			{
				if (searchChildren)
				{
					return gameObject.GetComponentInChildren<T>();
				}

				return gameObject.GetComponent<T>();
			}

			return test;
		}

		public static T IfUnityNullGetOrAddComponent<T>(this GameObject gameObject, T component) where T : Component
		{
			if (component.IsUnityNull())
			{
				component = gameObject.GetOrAddComponent<T>();
			}

			return component;
		}

		public static TTest IfNullGetOrAddComponent<TTest, TAdd>(
			this GameObject gameObject, TTest test, bool searchChildren = true
		)
			where TAdd : Component, TTest
		{
			if (!test.IsUnityNull())
			{
				return test;
			}

			if (searchChildren)
			{
				test = gameObject.GetComponentInChildren<TTest>();
			}
			else
			{
				test = gameObject.GetComponent<TTest>();
			}

			if (test == null)
			{
				test = gameObject.AddComponent<TAdd>();
			}

			return test;
		}

		public static T IfUnityNullTryGetComponent<T>(this GameObject gameObject, T component)
		{
			if (component.IsUnityNull())
			{
				gameObject.TryGetComponent(out component);
			}

			return component;
		}

		public static List<GameObject> FindChildrenWithTag(this Transform parent, string tag)
		{
			List<GameObject> taggedGameObjects = new List<GameObject>();

			for (int i = 0; i < parent.childCount; i++)
			{
				Transform child = parent.GetChild(i);
				if (child.CompareTag(tag))
				{
					taggedGameObjects.Add(child.gameObject);
				}

				if (child.childCount > 0)
				{
					taggedGameObjects.AddRange(child.FindChildrenWithTag(tag));
				}
			}

			return taggedGameObjects;
		}

		public static void SetComponentsState(this GameObject gameObject, bool shouldEnable, params Type[] componentTypes)
		{
			foreach (Type componentType in componentTypes)
			{
				if (componentType == null)
				{
					continue;
				}

				Behaviour component = (Behaviour) gameObject.GetComponent(componentType);
				if (component != null)
				{
					component.enabled = shouldEnable;
				}
			}
		}

		public static IEnumerable<T> GetComponents<T>(this IEnumerable<GameObject> gameObjects)
		{
			return gameObjects
				.Select(
					taggedChild => taggedChild.GetComponent<T>())
				.Where(
					component => !component.IsUnityNull());
		}
	}
}