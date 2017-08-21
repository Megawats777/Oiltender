using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayHUDGroup : GameHUDBase
{

    // Use this for initialization
    void Start()
    {
        setIsHUDVisible(false);
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
    }

    public override void updateHUDContent()
    {
        
    }

}
