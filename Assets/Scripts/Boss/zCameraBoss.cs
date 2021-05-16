using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zCameraBoss : MonoBehaviour
{
    public static zCameraBoss instance;

    public Transform target;

    public float smoothSpeed = 0.035f;

    public Vector3 offSet = new Vector3(0.0f, 0.0f, -10.0f);

    private void Awake()
    {
        MakeInstance();
    }

    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SetTarget(Transform t)
    {
        target = t;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
