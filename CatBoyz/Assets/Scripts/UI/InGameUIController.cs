using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIController : MonoBehaviour
{
    public GameObject companionPopUp;
    public GameObject companionImage;
    public GameObject player;
    public Text ammoText;
    public bool gotCompanion = false;
    private PlayerController playerController;
    private Shooting shootingController;

    public void Awake()
    {
        companionImage.SetActive(false);
    }
    private void Update()
    {
        CheckForCompanion();
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
}
