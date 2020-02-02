using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectController : MonoBehaviour
{
    public GameObject inGameUI;
    public int characterChoice = -9999;

    public void CreateCharacterA()
    {
        this.gameObject.SetActive(false);
        inGameUI.SetActive(true);
        characterChoice = 0;
        Time.timeScale = 1;
    }

    public void CreateCharacterB()
    {
        this.gameObject.SetActive(false);
        inGameUI.SetActive(true);
        characterChoice = 1;
        Time.timeScale = 1;
    }
}
