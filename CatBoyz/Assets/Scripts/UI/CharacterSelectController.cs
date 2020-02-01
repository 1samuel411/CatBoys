using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectController : MonoBehaviour
{
    public GameObject inGameUI;
    public void CreateCharacterA()
    {
        this.gameObject.SetActive(false);
        inGameUI.SetActive(true);
        //create character A
        Time.timeScale = 1;
    }

    public void CreateCharacterB()
    {
        this.gameObject.SetActive(false);
        inGameUI.SetActive(true);
        //create character B
        Time.timeScale = 1;
    }
}
