using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int currAmmo;
    public float fireRate = 0.2f;
    public GameObject bulletPrefab;
    public Transform directionObj;
    public Vector3 bulletOffset;

    private bool canShoot = true;

    void Start()
    {
        currAmmo = 0;   
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && currAmmo > 0)
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
        GameObject bullet = Instantiate(bulletPrefab, transform.position + (offset), directionObj.rotation);
        currAmmo--;
        bullet.transform.eulerAngles = new Vector3(0, bullet.transform.eulerAngles.y + Random.Range(-5.0f, 5.0f), 0);

        CameraShake.instance.SetShake(3);
        yield return new WaitForSeconds(fireRate + Random.Range(-0.05f, 0.05f));
        canShoot = true;
    }
}
