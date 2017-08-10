using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorVisiblityManager : MonoBehaviour
{
    // Show the mouse cursor
    public static void showMouseCursor()
    {
        // Unlock the mouse cursor
        // Show the mouse cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Hide the mouse cursor
    public static void hideMouseCursor()
    {
        // Lock the mouse cursor
        // Show the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
}
