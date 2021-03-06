﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Companion : MonoBehaviour
{

    private new Rigidbody rigidbody;

    public float attackRadius;
    public float attackSpeed;
    public float offset;

    private float timeHitting;

    private bool hit = false;

    private List<Transform> thingsToHit = new List<Transform>();

    void Start()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), PlayerManager.instance.player.GetComponent<Collider>(), true);
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector2 v = rigidbody.velocity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if(thingsToHit.Count > 0)
        {
            transform.position = Vector3.Lerp(transform.position, thingsToHit[0].position + (Vector3.forward * offset), attackSpeed * Time.deltaTime);
            if ((transform.position - (thingsToHit[0].position + (Vector3.forward * offset))).magnitude <= 0.25f)
            {
                if (timeHitting > .15f)
                {
                    timeHitting = 0;
                    thingsToHit.RemoveAt(0);
                }
                else
                    timeHitting += Time.deltaTime;
            }
        }
        else
        {
            if (hit)
                Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        thingsToHit = new List<Transform>();
        rigidbody.isKinematic = true;
        Collider[] hits = Physics.OverlapSphere(transform.position, attackRadius);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform.tag == "Enemy")
            {
                if(thingsToHit.Count <= 4)
                    thingsToHit.Add(hits[i].transform);
            }
        }
        hit = true;
        transform.eulerAngles = Vector3.zero;
        thingsToHit = thingsToHit.OrderBy(x => Vector2.Distance(transform.position, x.transform.position)).ToList();
    }
}
