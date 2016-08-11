using System;

public class GameHUDPanelProperties : IUIProperties 
{
	public int maxClonesCount;

	public GameHUDPanelProperties(int pMaxClonesCount)
	{
		maxClonesCount = pMaxClonesCount;
	}
}
