using UnityEngine;
using System.Collections;

internal static class GameObjectExtensions
{
	public static T GetAbstract<T>(this GameObject inObj) where T : class
	{
		return inObj.GetComponent<T>();
	}

	public static T GetInterface<T>(this GameObject inObj) where T : class
	{
		if (!typeof(T).IsInterface)
		{
			Debug.LogError(typeof(T).ToString() + ": is not an actual interface!");
			return null;
		}
		return inObj.GetComponent<T>();
	}

	public static T[] GetInterfaces<T>(this GameObject inObj) where T : class
	{
		if (!typeof(T).IsInterface)
		{
			Debug.LogError(typeof(T).ToString() + ": is not an actual interface!");
			return null;
		}
		return inObj.GetComponents<T>();
	}

}
