using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public float fireRate = 0.2f;
    public GameObject bulletPrefab;
    public Transform directionObj;
    public Vector3 bulletOffset;

    private bool canShoot = true;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        if (!canShoot)
            yield break;
        Vector3 offset = directionObj.TransformDirection(bulletOffset);
        canShoot = false;
        Instantiate(bulletPrefab, transform.position + (offset), directionObj.rotation);
        yield return new WaitForSeconds(fireRate + Random.Range(-0.05f, 0.05f));
        canShoot = true;
    }
}
