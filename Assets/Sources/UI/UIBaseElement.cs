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
		UIController.instance.Remove(name);
	}

	protected virtual void OnDestroy()
	{

	}
}

public class UIBaseElement<T> : UIBaseElement where T : IUIProperties
{
	protected T properties;

	public virtual void SetProperties(T pProperties)
	{
		properties = pProperties;
	}
}
