using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zStopMoveSaw : MonoBehaviour {

    public zRockFallSaw_BossVFT saw;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss")){
            saw.StopAllCoroutines();
            saw.CallIEnumeratorTurnBack();
        }
    }
}
