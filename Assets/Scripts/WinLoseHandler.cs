using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseHandler : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject noKeyNotification;
    public GameObject gotKeyNotification;
    public Player player;

    public void DisplayWinScreen(){
        player.ToggleHideCursor(false);
        winScreen.SetActive(true);
        gotKeyNotification.SetActive(false);
        Time.timeScale = 0;
    }
    public void DisplayLoseScreen(){
        player.ToggleHideCursor(false);
        loseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void ToggleNoKeyNotification(){
        //Display notification about "key" item requirement
        switch (noKeyNotification.activeSelf)
        {
            case true:
            noKeyNotification.SetActive(false);
            break;
            case false:
            noKeyNotification.SetActive(true);
            break;
        }   
    }

    public void DisplayGotKeyNotification(){
        //Display notification that player has the key item
        gotKeyNotification.SetActive(true);
    }
}
