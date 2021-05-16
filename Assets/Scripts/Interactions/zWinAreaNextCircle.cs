using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zWinAreaNextCircle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("zWinAreaNextCircle.OnTriggerEnter2D()");
            zGameController.instance.f_WinToNextCircle();
        }
    }
}
