using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private new Rigidbody rigidbody;
    public float speed = 90;

    public GameObject decalPrefab;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
            return;

        Destroy(gameObject);
        GameObject obj = Instantiate(decalPrefab, collision.contacts[0].point, Quaternion.FromToRotation(Vector3.up, collision.contacts[0].normal));
        obj.transform.SetParent(collision.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Health>().Damage(1);
            Destroy(gameObject);
        }
    }
}
