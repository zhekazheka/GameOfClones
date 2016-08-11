using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EUIType
{
	Panel = 0,
	Dialog,
	Popup
}

public class UIController : MonoBehaviour 
{
	private static UIController _instace;

	public static UIController instance
	{
		get 
		{
			return _instace;
		}
	}

	private LayersController _layersController;

	private Dictionary<string, UIBaseElement> uiElementsPool = new Dictionary<string, UIBaseElement>();

	private void Awake()
	{
		_instace = this;

		_layersController = GetComponentInChildren<LayersController>();

		DontDestroyOnLoad(gameObject);
	}

	#region Public Methods

	public void Show(UIAssetDescription pAssetDescription)
	{
		UIBaseElement uiElement;
		if(uiElementsPool.ContainsKey(pAssetDescription.prefabName))
		{
			uiElement = uiElementsPool[pAssetDescription.prefabName];
		}
		else 
		{
			GameObject uiPrefab = ResourcesManager.GetUIPrefab(pAssetDescription.prefabName, pAssetDescription.prefabPath);
			GameObject uiInstance = Instantiate(uiPrefab);
			AssignParent(pAssetDescription.uiType, uiInstance.transform);

			uiElement = uiInstance.GetComponent<UIBaseElement>();
		}

		uiElement.Show();
	}

	public void Hide(UIAssetDescription pAssetDescription)
	{
		if(uiElementsPool.ContainsKey(pAssetDescription.prefabName))
		{
			UIBaseElement uiElement = uiElementsPool[pAssetDescription.prefabName];
			uiElement.Hide();
		}
		else 
		{
			Debug.LogError("Can't Hide ui element with name: " + pAssetDescription.prefabName + " and type: " + pAssetDescription.uiType);
		}
	}

	public void Remove(UIAssetDescription pAssetDescription)
	{
		if(uiElementsPool.ContainsKey(pAssetDescription.prefabName))
		{
			UIBaseElement uiElement = uiElementsPool[pAssetDescription.prefabName];
			uiElement.Close();
		}
		else 
		{
			Debug.LogError("Can't Remove ui element with name: " + pAssetDescription.prefabName + " and type: " + pAssetDescription.uiType);
		}
	}

	#endregion

	private void AssignParent(EUIType pUIType, Transform uiObject)
	{
		switch(pUIType) 
		{
			case EUIType.Panel:
				uiObject.SetParent(_layersController.panelsLayer, false);
				break;
			case EUIType.Dialog:
				uiObject.SetParent(_layersController.dialogsLayer, false);
				break;
			case EUIType.Popup:
				uiObject.SetParent(_layersController.popupsLayer, false);
				break;
			default:
				Debug.LogError("Can't assign parent for UI element with type: " + pUIType);
				break;
		}
	}
}
