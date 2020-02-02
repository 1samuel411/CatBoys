using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIController : MonoBehaviour
{
    public GameObject companionPopUp;
    public GameObject characterSelect;
    public GameObject companionImageA;
    public GameObject companionImageB;
    public GameObject player;
    public Text ammoText;
    public bool gotCompanion = false;
    private PlayerController playerController;
    private Shooting shootingController;
    private CharacterSelectController characterSelectController;

    private void Start()
    {
        characterSelectController = characterSelect.GetComponent<CharacterSelectController>();
    }
    private void Update()
    {
        CheckForCompanion();
        CreateCharacterUI();
        UpdateAmmo();
    }

    public void CheckForCompanion()
    {
        if(gotCompanion == true) //change later for check from player controller
        {
            this.gameObject.SetActive(false);
            companionPopUp.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void UpdateAmmo()
    {
        ammoText.text = shootingController.currAmmo + "/100";
    }

    public void CreateCharacterUI()
    {
        if(characterSelectController.characterChoice == 0)
        {
            companionImageA.SetActive(true);
            companionImageB.SetActive(false);
            characterSelectController.characterChoice = -9999;
        }
        else if(characterSelectController.characterChoice == 1)
        {
            companionImageA.SetActive(false);
            companionImageB.SetActive(true);
            characterSelectController.characterChoice = -9999;
        }
    }
}
