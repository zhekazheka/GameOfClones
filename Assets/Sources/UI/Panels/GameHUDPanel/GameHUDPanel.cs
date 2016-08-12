using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameHUDPanel : UIBaseElement<GameHUDPanelProperties>
{
	[SerializeField]
	private Text txtClonesCount;

	[SerializeField]
	private Button btnPause;

	public override void Init()
	{
		base.Init();

		txtClonesCount.text = properties.maxClonesCount.ToString();

		btnPause.onClick.AddListener(OnPauseClick);
	}

	protected override void OnDestroy()
	{
		btnPause.onClick.RemoveListener(OnPauseClick);

		base.OnDestroy();
	}

	private void OnPauseClick()
	{
		UIController.instance.Show(UIElementsDescriptions.pauseMenuDescription);
	}
}
