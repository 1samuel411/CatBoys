using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject characterSelect;
    public GameObject controlsMenu;
    public GameObject creditsMenu;
    public GameObject companionImage;

    public void Update()
    {
        if(this.gameObject.activeSelf == true)
        {
            companionImage.SetActive(false);
        }
    }
    public void StartGame()
    {
        this.gameObject.SetActive(false);
        characterSelect.SetActive(true);
    }

    public void Options()
    {
        this.gameObject.SetActive(false);
        controlsMenu.SetActive(true);
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
