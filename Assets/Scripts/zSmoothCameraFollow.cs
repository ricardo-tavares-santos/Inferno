using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zSmoothCameraFollow : MonoBehaviour {

    Transform target;

    public float smoothSpeed = 0.035f;

    public Vector3 offSet;

    private void Start()
    {
        target = zPlayer.instance.transform;
        transform.position = target.transform.position - new Vector3(0.0f, 0.0f, 10.0f);
        //offset use when we need camera keep a distance from the target
        offSet = transform.position - target.position;

    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
