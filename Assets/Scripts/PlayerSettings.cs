using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerSettings
{
    //Control settings
    public static (KeyCode forward, KeyCode backward, KeyCode left, KeyCode right, KeyCode runHold, KeyCode pauseMenu) keyboardControls = 
    (
        KeyCode.W, 
        KeyCode.S,
        KeyCode.A,
        KeyCode.D, 
        KeyCode.LeftShift,
        KeyCode.Escape
    );
}
