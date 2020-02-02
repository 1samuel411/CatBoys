using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIController : MonoBehaviour
{
    public GameObject companionPopUp;
    public GameObject companionImage;
    public GameObject player;
    public bool gotCompanion = false;
    private PlayerController playerController;

    public void Awake()
    {
        companionImage.SetActive(false);
    }
    private void Update()
    {
        CheckForCompanion();
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
    //updates ammo text
    //updates heart health
}
