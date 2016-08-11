using UnityEngine;
using System.Collections;

public class MainMenuMapController : BaseMapController
{
	protected override void Start()
	{
		base.Start();

		UIController.instance.Show(UIElementsDescriptions.mainMenuDescription);
	}
}
