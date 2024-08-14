using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    void Start(){
        Time.timeScale = 1;
    }
    public void ToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToLevel(){
        SceneManager.LoadScene("LevelSample");
    }
    public void ExitGame(){
        Application.Quit();
    }

}
