using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuPanel : UIBaseElement<IUIProperties>
{
	[Header("Buttons")]
	[SerializeField]
	private Button btnStartGame;

	[SerializeField]
	private Button btnExitGame;

	public override void Init()
	{
		base.Init();

		btnStartGame.onClick.AddListener(OnStartGameClick);
		btnExitGame.onClick.AddListener(OnExitGameClick);
	}

	protected override void OnDestroy()
	{
		btnStartGame.onClick.RemoveListener(OnStartGameClick);
		btnExitGame.onClick.RemoveListener(OnExitGameClick);

		base.OnDestroy();
	}
		
	#region Button Action Handling

	private void OnStartGameClick()
	{
		MapLoader.LoadMap(MapsConstants.LEVEL + "00");
	}

	private void OnExitGameClick()
	{
		Application.Quit();
	}

	#endregion
}
