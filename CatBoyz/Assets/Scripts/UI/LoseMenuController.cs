using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMenuController : MonoBehaviour
{
    public GameObject characterSelect;
    public GameObject mainMenu;
    public void TryAgain()
    {
        this.gameObject.SetActive(false);
        characterSelect.SetActive(true);
    }

    public void GoToMainMenu()
    {
        this.gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
