using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject characterSelect;
    public GameObject optionsMenu;
    public GameObject creditsMenu;
    public GameObject inGameMenu;
    public GameObject pauseMenu;
    public GameObject winMenu;
    public GameObject loseMenu;
    public GameObject blackPanel;

    public Animator animator;

    public GameObject player;
    private PlayerController playerController;
    void Start()
    {
        mainMenu.SetActive(true);
        characterSelect.SetActive(false);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        inGameMenu.SetActive(false);
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        loseMenu.SetActive(false);

        Time.timeScale = 0;
    }

    void Update()
    {
        PauseGame();
    }

    void PauseGame()
    {
        if(Input.GetKey(KeyCode.Escape) && inGameMenu.activeSelf == true)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void OpenMainMenu()
    {
        animator = blackPanel.GetComponent<Animator>();

        bool isOpen = animator.GetBool("open");

        animator.SetBool("open", !isOpen);
    }

    /*public void LoseGame()
    {
        if(playerController.health <= 0)
        {
            inGameMenu.SetActive(false);
            loseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void WinGame()
    {
        if(playerController.score => totalScore)
        {
            inGameMenu.SetActive(false);
            winMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }*/
}
