using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zWinArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            zGameController.instance.f_Win();
        }
    }
}
