using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public abstract class GameHUDBase : MonoBehaviour
{
    //<Summary>
    // The root of all HUD content
    //</Summary>
    [SerializeField]
    protected GameObject hudContentRoot;

    // Hide the HUD
    public abstract void hideHUD();

    // Show the HUD
    public abstract void showHUD();

    // Update the content of the HUD
    public abstract void updateHUDContent();
}
