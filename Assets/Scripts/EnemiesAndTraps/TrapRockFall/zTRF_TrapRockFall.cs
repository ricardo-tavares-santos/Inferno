using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zTRF_TrapRockFall : MonoBehaviour
{
    private void Start()
    {
        GetComponentInChildren<Rigidbody2D>().simulated = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponentInChildren<Rigidbody2D>().simulated = true;
        }
    }
}
