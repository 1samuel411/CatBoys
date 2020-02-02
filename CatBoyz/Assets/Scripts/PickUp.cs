using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject player;
    public int ammo = 15;
    private Shooting shootingScript;

    private void Start()
    {
        shootingScript = player.GetComponent<Shooting>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && shootingScript.currAmmo < 100)
        {
            shootingScript.currAmmo += ammo; 
            Destroy(this.gameObject);
        }
        else if(other.gameObject.CompareTag("Player") && shootingScript.currAmmo + ammo > 100)
        {
            shootingScript.currAmmo = 100;
            Destroy(this.gameObject);
        }
    }
}
