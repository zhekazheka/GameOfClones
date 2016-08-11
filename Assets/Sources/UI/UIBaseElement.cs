using UnityEngine;
using System.Collections;

public class UIBaseElement : MonoBehaviour 
{
	public virtual void Show()
	{
		gameObject.SetActive(true);
	}

	public virtual void Hide()
	{
		gameObject.SetActive(false);
	}

	public virtual void Close()
	{
		Destroy(gameObject);
	}

	protected virtual void OnDestroy()
	{

	}
}
