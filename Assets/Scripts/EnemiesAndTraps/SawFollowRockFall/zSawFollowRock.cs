using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zSawFollowRock : MonoBehaviour {

    public Transform target;
    public Vector3 offSet;

    private void Start()
    {
        offSet = transform.position - target.position;
    }

    private void LateUpdate()
    {
        transform.position = target.position + offSet;
    }
}
