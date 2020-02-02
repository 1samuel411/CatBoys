using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionPopUpController : MonoBehaviour
{
    public GameObject inGameUI;
    public GameObject companionImage;
    public GameObject player;

    private PlayerController playerController;
    private InGameUIController inGameUIController;

    public void OkButton()
    {
        inGameUI.SetActive(true);
        companionImage.SetActive(true);
        this.gameObject.SetActive(false);
        inGameUIController.gotCompanion = false;
        Time.timeScale = 1;
    }
}
