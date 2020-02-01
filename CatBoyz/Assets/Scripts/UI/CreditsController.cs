using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    public GameObject mainMenu;
    public void GoToMainMenu()
    {
        this.gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}
