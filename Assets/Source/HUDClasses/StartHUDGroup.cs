using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHUDGroup : GameHUDBase
{
    

    // Use this for initialization
    void Start()
    {
		showHUD();
        setIsHUDVisible(true);setIsHUDVisible(true);
        print(GetType().ToString() + " " + getIsHUDVisible());
    }

    // Update is called once per frame
    void Update()
    {

    }

	public override void hideHUD()
    {
        setIsHUDVisible(false);
        hudContentRoot.SetActive(false);
    }

    public override void showHUD()
    {
        setIsHUDVisible(true);
        hudContentRoot.SetActive(true);
		MouseCursorVisiblityManager.hideMouseCursor();
    }

    public override void updateHUDContent()
    {
        throw new System.NotImplementedException();
    }
}
