using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public WinLoseHandler winLoseHandler;
    public Player player;
    public GameObject pauseMenu;
    public GameObject controlMenu;
    public GameObject quitGameConfirm;
    private bool isPaused = false;

    void Start(){

        player.ToggleHideCursor(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Toggle Pause Menu using "Esc" key
        if(Input.GetKeyDown(PlayerSettings.keyboardControls.pauseMenu) && 
        winLoseHandler.winScreen.activeSelf == false &&
        winLoseHandler.loseScreen.activeSelf == false &&
        controlMenu.activeSelf == false &&
        quitGameConfirm.activeSelf == false){
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu(){
        switch (isPaused)
        {
            case false:
            pauseMenu.SetActive(true);
            player.ToggleHideCursor(false);
            isPaused = true;
            Time.timeScale = 0;
            break;
            case true:
            if(pauseMenu.activeSelf){
                pauseMenu.SetActive(false);
                player.ToggleHideCursor(true);
                isPaused = false;
                Time.timeScale = 1;
            }
            break; 
        }
    }

}
