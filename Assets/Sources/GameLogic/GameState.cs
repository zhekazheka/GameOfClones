using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameState : MonoBehaviour 
{
	private List<Dictionary<int, Vector2>> _recordedInput;

	private Dictionary<int, Vector2> _currentInput;

	private List<IGameResetable> resetables = new List<IGameResetable>();

	private int _currentRecordIndex;
	private int _maxShadowsAmount;

	public void Init(int pMaxShadowAmount)
	{
		_maxShadowsAmount = pMaxShadowAmount;
		_currentRecordIndex = 0;

		_recordedInput = new List<Dictionary<int, Vector2>>();

		AddNewRecord();

		GameObject[] interactableObjs = GameObject.FindGameObjectsWithTag("Interactable");
		for(int i = 0; i < interactableObjs.Length; ++i)
		{
			resetables.Add(interactableObjs[i].GetInterface<IGameResetable>());
		}
	}

	public void Reset()
	{
		for(int i = 0; i < resetables.Count; ++i)
		{
			resetables[i].Reset();
		}
	}

	public void NextShadow()
	{
		++_currentRecordIndex;

		_currentRecordIndex = Mathf.Min(_currentRecordIndex, _maxShadowsAmount - 1);

		if(_currentRecordIndex < _recordedInput.Count)
		{
			_currentInput = _recordedInput[_currentRecordIndex];
			_currentInput.Clear();
		}
		else 
		{
			AddNewRecord();
		}
	}

	public void PrevShadow()
	{
		--_currentRecordIndex;

		if(_currentRecordIndex < 0)
		{
			_currentRecordIndex = 0;
		}

		_currentInput = _recordedInput[_currentRecordIndex];
		_currentInput.Clear();
	}

	private void AddNewRecord()
	{
		_currentInput = new Dictionary<int, Vector2>();
		_recordedInput.Add(_currentInput);
	}

	public void RegisterUserAxisInput(Vector2 pInput)
	{
		if(pInput.sqrMagnitude > 0.0f)
		{
			_currentInput.Add(FrameCounter.currentFrame, pInput);
		}
	}

	public List<Dictionary<int, Vector2>> GetRecordedInput()
	{
		return _recordedInput;
	}

	public int GetCurrentRecordIndex()
	{
		return _currentRecordIndex;
	}
}
