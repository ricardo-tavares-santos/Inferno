using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zSawMachine : MonoBehaviour
{
    public Transform target;
    public float speed;

    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, speed * Time.timeScale);
    }
}
