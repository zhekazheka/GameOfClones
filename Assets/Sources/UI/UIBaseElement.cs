using UnityEngine;
using System.Collections;

public class UIBaseElement : MonoBehaviour
{
	public virtual void SetProperties(IUIProperties pProperties) {}

	public virtual void Init() {}

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

public class UIBaseElement<TProperties> : UIBaseElement where TProperties : IUIProperties
{
	protected TProperties properties;

	public override void SetProperties(IUIProperties pProperties)
	{
		properties = (TProperties)pProperties;
	}
}
