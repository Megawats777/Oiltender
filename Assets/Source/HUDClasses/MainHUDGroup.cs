using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class MainHUDGroup : GameHUDBase
{
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        //showHUD();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
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
        throw new NotImplementedException();
    }




}