using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Companion : MonoBehaviour
{

    private new Rigidbody rigidbody;

    public float attackRadius;
    public float attackSpeed;
    public float offset;

    private bool hit = false;

    private List<Transform> thingsToHit = new List<Transform>();

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector2 v = rigidbody.velocity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if(thingsToHit.Count > 0)
        {
            if((transform.position - (thingsToHit[0].position + (Vector3.forward * offset))).magnitude <= 0.5f)
            {
                thingsToHit.RemoveAt(0);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, thingsToHit[0].position + (Vector3.forward * offset), attackSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (hit)
                Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        thingsToHit = new List<Transform>();
        rigidbody.isKinematic = true;
        Collider[] hits = Physics.OverlapSphere(transform.position, attackRadius);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform.tag == "Enemy")
            {
                thingsToHit.Add(hits[i].transform);
            }
        }
        hit = true;
        thingsToHit = thingsToHit.OrderBy(x => Vector2.Distance(transform.position, x.transform.position)).ToList();
    }
}
