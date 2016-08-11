using UnityEngine.SceneManagement;
using UnityEngine;

public static class MapLoader 
{
	public static void LoadMap(string pMapName)
	{
		// TODO add fade out / fade in transition on map loads
		CleanScene();

		SceneManager.LoadScene(pMapName);
	}

	private static void CleanScene()
	{
		Time.timeScale = 1.0f;

		UIController.instance.Clear();
	}
}
