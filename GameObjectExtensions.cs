using System;
using System.Collections.Generic;
using __Utils._ClassExtensions.LanguageExtensions;
using UnityEngine;

namespace __Utils._ClassExtensions.UnityExtensions {
	public static class GameObjectExtensions {
		public static bool GetIsPrefab(this GameObject gameObject) {
			return gameObject.scene.rootCount == 0;
		}

		/// <summary>
		/// Returns the component of Type type. If one doesn't already exist on the GameObject it will be added.
		/// </summary>
		/// <typeparam name="T">The type of Component to return.</typeparam>
		/// <param name="gameObject">The GameObject this Component is attached to.</param>
		/// <returns>Component</returns>
		public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component {
			T component = gameObject.GetComponent<T>();

			if (component == null) {
				// Debug.Log("No " + typeof(T) + " on " + gameObject.name + " adding...", gameObject);

				component = gameObject.AddComponent<T>();
			}

			return component;
		}

		public static T GetSafeComponent<T>(this GameObject gameObject) {
			T component = gameObject.GetComponent<T>();

			if (component == null) {
				Debug.LogWarning("No " + typeof(T) + " on " + gameObject.name, gameObject);
			}

			return component;
		}

		public static T GetComponentInSiblings<T>(this GameObject gameObject) {
			Transform parent = gameObject.transform.parent;

			return parent == null ? default : parent.GetComponentInChildren<T>();
		}

		public static TTest IfNullAddComponent<TTest, TAdd>(this GameObject gameObject)
			where TAdd : Component, TTest {
			TTest component = gameObject.GetSafeComponent<TTest>();

			if (component.IsReallyNull()) {
				component = gameObject.AddComponent<TAdd>();
			}

			return component;
		}

		public static List<GameObject> FindChildrenWithTag(this Transform parent, string tag) {
			List<GameObject> taggedGameObjects = new List<GameObject>();

			for (int i = 0; i < parent.childCount; i++) {
				Transform child = parent.GetChild(i);
				if (child.CompareTag(tag)) {
					taggedGameObjects.Add(child.gameObject);
				}

				if (child.childCount > 0) {
					taggedGameObjects.AddRange(child.FindChildrenWithTag(tag));
				}
			}

			return taggedGameObjects;
		}

		public static void SetComponentsState(this GameObject gameObject, bool shouldEnable, params Type[] componentTypes) {
			foreach (Type componentType in componentTypes) {
				if (componentType == null) {
					continue;
				}

				Behaviour component = (Behaviour) gameObject.GetComponent(componentType);
				if (component != null) {
					component.enabled = shouldEnable;
				}
			}
		}
	}
}