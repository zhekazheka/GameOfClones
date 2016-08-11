using UnityEngine;
using System.Collections;

public class UIAssetDescription
{
	public string prefabName;
	public string prefabPath;
	public EUIType uiType;

	public UIAssetDescription(string pPrefabName, string pPrefabPath, EUIType pUIType)
	{
		prefabName = pPrefabName;
		prefabPath = pPrefabPath;
		uiType = pUIType;
	}
}
