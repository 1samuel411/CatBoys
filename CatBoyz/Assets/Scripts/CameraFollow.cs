using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public float lookAtSpeed = 0.125f;
    public Vector3 offset;
    public Vector3 lookOffset;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed*Time.deltaTime);

        Quaternion rotation = transform.rotation;
        transform.LookAt(target.position + lookOffset);
        transform.rotation = Quaternion.Lerp(rotation, transform.rotation, lookAtSpeed * Time.deltaTime);
    }
}
