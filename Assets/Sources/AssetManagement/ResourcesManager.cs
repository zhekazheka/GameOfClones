using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ResourcesManager 
{
	#region Fields & Properties

	private static Dictionary<string, GameObject> uiPrefabs = new Dictionary<string, GameObject>();

	#endregion

	#region Public Methods

	public static GameObject GetUIPrefab(string pPrefabName, string pPrefabPath) 
	{
		if(uiPrefabs.ContainsKey(pPrefabName)) 
		{
			return uiPrefabs[pPrefabName];
		}

		GameObject go = Resources.Load(GetFullPath(pPrefabPath, pPrefabName)) as GameObject;
		if(go != null) 
		{
			uiPrefabs.Add(pPrefabName, go);
			return go;
		}
		return null;
	}
		
	public static T GetSettings<T>(string pSettingsName, string pSettingsPath) where T : UnityEngine.Object 
	{
		return Resources.Load<T>(GetFullPath(pSettingsPath, pSettingsName));
	}

	#endregion

	#region Private Methods

	private static string GetFullPath(string aPath, string aFileName) 
	{
		return string.Format("{0}/{1}", aPath, aFileName);
	}

	#endregion

}
