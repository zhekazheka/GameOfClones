using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour 
{
	[SerializeField]
	private string _nextLevel;
	[SerializeField]
	private float _trasintionDelay;

	private void OnTriggerEnter(Collider pOther)
	{
		GameObject obj = pOther.gameObject;
		if(obj.tag == "Player")
		{
			if(string.IsNullOrEmpty(_nextLevel))
			{
				Debug.LogError("Next Level is Empty - no trasition will happen");
			}
			else 
			{
				StartCoroutine(Delay());
			}
		}
	}

	private IEnumerator Delay()
	{
		// 42 - THE NUMBER ^_^
		Time.timeScale = 0.42f;
	
		float startTime = Time.unscaledTime;
		while(Time.unscaledTime - startTime < _trasintionDelay)
		{
			yield return new WaitForFixedUpdate();
		}

		MapLoader.LoadMap(_nextLevel);
	}
}
