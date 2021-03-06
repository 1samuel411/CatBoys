﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    Rigidbody rigidbody;
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (rigidbody.isKinematic)
        {
            agent.SetDestination(transform.position);
            return;
        }
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                //attack the target
                FaceTarget();
            }
        } 
    }

    void FaceTarget()
    {
       // Vector3 direction = (target.position - transform.position).normalized;
       // Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
       // transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
