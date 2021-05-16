using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zWolfFire : MonoBehaviour
{

    public GameObject prefab_bullet;
    public float delayTimeAtFirstAttack;
    public float delayTimeBetweenAttack = 2.0f;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("Attack", delayTimeAtFirstAttack, delayTimeBetweenAttack);
    }
    void Attack()
    {
        anim.SetTrigger("Attack");
    }
    void Shot()
    {
        GameObject o = Instantiate(prefab_bullet, transform.position, Quaternion.identity);
        o.GetComponent<zHypnosicBullet>().direction = -transform.right * transform.localScale.x / Mathf.Abs(transform.localScale.x);
    }
}
