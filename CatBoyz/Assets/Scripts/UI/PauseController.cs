using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject inGameUI;
    public void ResumeGame()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        inGameUI.SetActive(false);
        this.gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}
