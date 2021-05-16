using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zTRF_Rock : MonoBehaviour
{
    //public GameObject prefab_explo;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!zPlayer.instance.isTestMode && !zPlayer.instance.isWin)
            {
                if (!zPlayer.instance.isDead)
                {
                    zPlayer.instance.isDead = true;
                    zPlayer.instance.Dead_ShowRevival();
                }
            }
            //Destroy(GetComponentInParent<zTRF_TrapRockFall>().gameObject, 1.0f);
        }
    }
}
