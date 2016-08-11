using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameHUDPanel : UIBaseElement<GameHUDPanelProperties>
{
	[SerializeField]
	private Text txtClonesCount;

	[SerializeField]
	private Button btnPause;

	public override void Show()
	{
		base.Show();

		btnPause.onClick.AddListener(OnPauseClick);
	}

	protected override void OnDestroy()
	{
		btnPause.onClick.RemoveListener(OnPauseClick);

		base.OnDestroy();
	}

	public override void SetProperties(GameHUDPanelProperties pProperties)
	{
		base.SetProperties(pProperties);

		txtClonesCount.text = properties.maxClonesCount.ToString();
	}

	private void OnPauseClick()
	{
		UIController.instance.Show(UIElementsDescriptions.pauseMenuDescription);
	}
}
