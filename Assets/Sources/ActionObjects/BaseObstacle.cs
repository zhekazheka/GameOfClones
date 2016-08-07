using UnityEngine;
using System.Collections;

public class BaseObstacle : MonoBehaviour, IActionListener, IGameResetable
{
	#region IGameResetable implementation

	public void Reset()
	{
		gameObject.SetActive(true);
	}

	#endregion

	#region IActionListener implementation

	public void OnActionButton(EActionButtonState pState)
	{
		gameObject.SetActive(pState == EActionButtonState.Unpressed);
	}

	#endregion


}
