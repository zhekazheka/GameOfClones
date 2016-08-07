using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EActionButtonState
{
	Default = 0,
	Unpressed,
	Pressed
}

public class ActionButton : MonoBehaviour, IGameResetable
{
	[SerializeField]
	private SpriteRenderer _spriteRenderer;

	[Header("States")]
	[SerializeField]
	private EActionButtonState initialState = EActionButtonState.Unpressed;
	[SerializeField]
	private Sprite _unpressedSprite;
	[SerializeField]
	private Sprite _pressedSprite;

	[Header("Action Listeners")]
	[SerializeField]
	private List<GameObject> listeners = new List<GameObject>();

	public delegate void OnButtonInteract(EActionButtonState pNewState);
	public event OnButtonInteract onButtonInteract;

	private EActionButtonState _currentState;
	public  EActionButtonState currentState
	{
		get 
		{
			return _currentState;
		}
		private set 
		{
			_currentState = value;
			SetState(value);
		}
	}

	private void Awake()
	{
		currentState = initialState;
	}

	#region IGameResetable implementation

	public void Reset()
	{
		currentState = initialState;
	}

	#endregion

	private void OnTriggerEnter(Collider pOther)
	{
		GameObject obj = pOther.gameObject;
		if(obj.tag == "Player" || obj.tag == "Shadow")
		{
			currentState = EActionButtonState.Pressed;

			TriggerListeners(currentState);

			if(onButtonInteract != null)
			{
				onButtonInteract(_currentState);
			}
		}
	}

	private void OnTriggerExit(Collider pOther)
	{
		GameObject obj = pOther.gameObject;
		if(obj.tag == "Player" || obj.tag == "Shadow")
		{
			currentState = EActionButtonState.Unpressed;

			TriggerListeners(currentState);

			if(onButtonInteract != null)
			{
				onButtonInteract(_currentState);
			}
		}
	}

	private void TriggerListeners(EActionButtonState pState)
	{
		for(int  i = 0; i < listeners.Count; ++i)
		{
			IActionListener listener = listeners[i].GetInterface<IActionListener>();
			if(listener != null)
			{
				listener.OnActionButton(pState);
			}
		}
	}

	private void SetState(EActionButtonState pNewState)
	{
		gameObject.SetActive(true);
		switch(pNewState) 
		{
			case EActionButtonState.Default:
				gameObject.SetActive(false);
				break;
			case EActionButtonState.Unpressed:
				_spriteRenderer.sprite = _unpressedSprite;
				break;
			case EActionButtonState.Pressed:
				_spriteRenderer.sprite = _pressedSprite;
				break;
		}
	}
}
