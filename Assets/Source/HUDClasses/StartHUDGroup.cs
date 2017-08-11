using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHUDGroup : GameHUDBase
{
    

    // Use this for initialization
    void Start()
    {
		showHUD();
    }

    // Update is called once per frame
    void Update()
    {

    }

	public override void hideHUD()
    {
        hudContentRoot.SetActive(false);
    }

    public override void showHUD()
    {
        hudContentRoot.SetActive(true);
		MouseCursorVisiblityManager.hideMouseCursor();
    }

    public override void updateHUDContent()
    {
        throw new System.NotImplementedException();
    }
}
