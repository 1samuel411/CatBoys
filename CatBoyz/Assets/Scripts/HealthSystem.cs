using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    //minimumHealth
    void Start()
    {
        currentHealth = maxHealth;
    }

    
    void Update()
    {
        if(currentHealth < 0)
        {
            Destroy(gameObject);
        }
        
    }

    public void Damage(int damageAmount)
    {
        currentHealth = currentHealth - damageAmount;

        //if currentHealth is less than minium
        //current health equals 0;
        //Destroy the object
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
