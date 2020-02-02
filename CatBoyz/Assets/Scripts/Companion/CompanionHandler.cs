using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionHandler : MonoBehaviour
{

    public GameObject companionAttackPrefab;

    public float initAngle = 60;
    public float xOffset;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 99999f))
            {
                SpawnCompanionAttack(hit.point);
            }
        }
    }

    void SpawnCompanionAttack(Vector3 targetPos)
    {
        Vector3 camPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, targetPos.z - Camera.main.transform.position.z));
        Vector3 spawnPos = new Vector3(camPos.x - 5, Camera.main.transform.position.y - 5, targetPos.z);
        float turretAngle = initAngle; //Turret is 10 deg tilted up (350 in inspector)
        float g = Physics.gravity.magnitude; //G force
        float y = (Camera.main.transform.position.y - 5) + targetPos.y; //Height of the target
        float x = Vector3.Distance(targetPos, spawnPos); //distance to hit, slight off because turret is lifted up

        Vector3 forward = Vector3.right;
        float tanG = Mathf.Tan(turretAngle * Mathf.Deg2Rad);
        float upper = Mathf.Sqrt(g) * Mathf.Sqrt(x) * Mathf.Sqrt(tanG * tanG + 1.0f);
        float lower = Mathf.Sqrt(2 * tanG - ((2 * y) / x));

        float velocity = upper / lower;

        GameObject newObj = Instantiate(companionAttackPrefab);
        newObj.transform.position = spawnPos;
        newObj.transform.eulerAngles = new Vector3(0, 0,initAngle);
        newObj.transform.localScale = Vector3.one;
        newObj.transform.GetComponent<Rigidbody>().velocity = new Vector3(velocity * Mathf.Cos(turretAngle * Mathf.Deg2Rad), velocity * Mathf.Sin(turretAngle * Mathf.Deg2Rad));
    }
}
