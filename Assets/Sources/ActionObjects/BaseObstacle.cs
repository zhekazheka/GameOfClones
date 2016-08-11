using UnityEngine;
using System.Collections;

public class BaseObstacle : MonoBehaviour, IActionListener, IGameResetable
{
	[Header("Interactable Colliders")]
	[SerializeField]
	protected Collider[] _colliders;

	#region IGameResetable implementation

	public virtual void Reset()
	{
		gameObject.SetActive(true);
	}

	#endregion

	#region IActionListener implementation

	public virtual void OnActionButton(EActionButtonState pState)
	{
		for(int i = 0; i < _colliders.Length; ++i) 
		{
			_colliders[i].enabled = pState == EActionButtonState.Unpressed;
		}
	}

	#endregion


}
