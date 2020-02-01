using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject characterSelect;
    public GameObject optionsMenu;
    public GameObject creditsMenu;
    public void StartGame()
    {
        this.gameObject.SetActive(false);
        characterSelect.SetActive(true);
    }

    public void Options()
    {
        this.gameObject.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Credits()
    {
        this.gameObject.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
