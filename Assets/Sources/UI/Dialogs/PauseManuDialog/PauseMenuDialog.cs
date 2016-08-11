using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuDialog : UIBaseElement 
{
	[Header("Buttons")]
	[SerializeField]
	private Button btnResumeGame;

	[SerializeField]
	private Button btnBackToMenu;

	public override void Show()
	{
		base.Show();

		btnResumeGame.onClick.AddListener(OnResumeGameClick);
		btnBackToMenu.onClick.AddListener(OnBackToMenuClick);

		Time.timeScale = 0.0f;
	}

	protected override void OnDestroy()
	{
		btnResumeGame.onClick.RemoveListener(OnResumeGameClick);
		btnBackToMenu.onClick.RemoveListener(OnBackToMenuClick);

		base.OnDestroy();
	}

	#region Button Action Handling

	private void OnResumeGameClick()
	{
		ResetTimeScale();

		Hide();
	}

	private void OnBackToMenuClick()
	{
		ResetTimeScale();

		MapLoader.LoadMap(MapsConstants.MAIN_MENU);
	}

	private void ResetTimeScale()
	{
		Time.timeScale = 1.0f;
	}

	#endregion
}
