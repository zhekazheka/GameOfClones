using UnityEngine;
using System.Collections;

// this class suppose to be auto generated based on folder structure and ui prefabs location
public static class UIElementsDescriptions
{
	#region Panels

	public static UIAssetDescription mainMenuDescription = new UIAssetDescription("MainMenuPanel", "UI/Panels", EUIType.Panel);
	public static UIAssetDescription gameHUDDescription = new UIAssetDescription("GameHUDPanel", "UI/Panels", EUIType.Panel);

	#endregion


	#region Dialogs

	public static UIAssetDescription pauseMenuDescription = new UIAssetDescription("PauseMenuDialog", "UI/Dialogs", EUIType.Dialog);

	#endregion
}
