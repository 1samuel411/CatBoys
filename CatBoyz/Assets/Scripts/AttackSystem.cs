using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    private HealthSystem _health;
    void Start()
    {
        _health = GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _health.Damage(50);
        }
    }
}
