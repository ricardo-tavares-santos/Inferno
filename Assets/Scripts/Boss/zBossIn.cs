using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zBossIn : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            zGameController.instance.f_OpenBossWarning();
        }
    }
}
