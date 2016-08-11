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

	private Dictionary<string, UIBaseElement> openedUIElements = new Dictionary<string, UIBaseElement>();

	private void Awake()
	{
		if(_instace != null)
		{
			Destroy(gameObject);
			return;
		}

		_instace = this;

		_layersController = GetComponentInChildren<LayersController>();

		DontDestroyOnLoad(gameObject);
	}

	#region Public Methods

	public UIBaseElement Show(UIAssetDescription pAssetDescription, IUIProperties pProperties = null)
	{
		UIBaseElement uiElement;

		// [warn]: currently only one the same ui element can be opne at the time, if this should be different change it here 
		if(openedUIElements.ContainsKey(pAssetDescription.prefabName))
		{
			uiElement = openedUIElements[pAssetDescription.prefabName];
		}
		else 
		{
			GameObject uiPrefab = ResourcesManager.GetUIPrefab(pAssetDescription.prefabName, pAssetDescription.prefabPath);
			GameObject uiInstance = Instantiate(uiPrefab);
			uiInstance.name = pAssetDescription.prefabName;
			AssignParent(pAssetDescription.uiType, uiInstance.transform);

			uiElement = uiInstance.GetComponent<UIBaseElement>();

			openedUIElements.Add(pAssetDescription.prefabName, uiElement);
		}

		uiElement.Show();

		return uiElement;
	}

	public void Hide(UIAssetDescription pAssetDescription)
	{
		if(openedUIElements.ContainsKey(pAssetDescription.prefabName))
		{
			UIBaseElement uiElement = openedUIElements[pAssetDescription.prefabName];
			uiElement.Hide();
		}
		else 
		{
			Debug.LogError("Can't Hide ui element with name: " + pAssetDescription.prefabName + " and type: " + pAssetDescription.uiType);
		}
	}

	public void Remove(string pElementName)
	{
		if(openedUIElements.ContainsKey(pElementName))
		{
			UIBaseElement uiElement = openedUIElements[pElementName];
			Destroy(uiElement.gameObject);

			openedUIElements.Remove(pElementName);
		}
		else 
		{
			Debug.LogError("Can't Remove ui element with name: " + pElementName);
		}
	}

	public void Clear()
	{
		List<string> allKeys = new List<string>(openedUIElements.Keys);

		for(int i = 0; i < allKeys.Count; ++i)
		{
			string uiElementName = allKeys[i];
			Remove(uiElementName);
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
