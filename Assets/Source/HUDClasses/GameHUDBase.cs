using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public abstract class GameHUDBase : MonoBehaviour
{
    // Is the HUD visible
    private bool isHUDVisible = true;

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

    
    /*--GETTERS AND SETTERS--*/

    // Get and set is the HUD visible value
    public bool getIsHUDVisible()
    {
        return isHUDVisible;
    }

    public void setIsHUDVisible(bool isHUDVisible)
    {
        this.isHUDVisible = isHUDVisible;
    }

    /*--END OF GETTERS AND SETTERS--*/

}
