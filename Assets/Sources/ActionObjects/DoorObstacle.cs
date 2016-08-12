using UnityEngine;
using System.Collections;

public class DoorObstacle : BaseObstacle 
{
	[Header("Door Specific")]
	[SerializeField]
	private Transform door;

	[SerializeField]
	private Transform finishCloseTransfom;

	[SerializeField]
	private Transform finishOpenTransfom;

	[SerializeField]
	private float openningSpeed = 2.0f;

	private bool _isOpenning;

	public override void OnActionButton(EActionButtonState pState)
	{
		_isOpenning = pState == EActionButtonState.Pressed;
	}

	private void Update()
	{
		if(_isOpenning)
		{
			AnimateOpen();
		}
		else 
		{
			AnimateClose();
		}
	}

	private void AnimateOpen()
	{
		if(Vector3.Distance(door.localPosition, finishOpenTransfom.localPosition) > 0.1f)
		{
			door.localPosition = Vector3.MoveTowards(door.localPosition, finishOpenTransfom.localPosition, Time.deltaTime * openningSpeed);
		}
	}

	private void AnimateClose()
	{
		if(Vector3.Distance(door.localPosition, finishCloseTransfom.localPosition) > 0.1f)
		{
			door.localPosition = Vector3.MoveTowards(door.localPosition, finishCloseTransfom.localPosition, Time.deltaTime * openningSpeed);
		}
	}
}
