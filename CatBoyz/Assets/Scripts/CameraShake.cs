using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    public float shake = 0;
    public float shakeSlowdown = 3;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        transform.localPosition = new Vector3(UnityEngine.Random.Range(-shake, shake), UnityEngine.Random.Range(-shake, shake), 0);
        shake -= shakeSlowdown * Time.deltaTime;
        shake = Mathf.Clamp(shake, 0, 1);
    }

    public void SetShake(float amount)
    {
        shake = amount * 0.1f;
    }
}
