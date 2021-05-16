using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zWolfFire_Creep : MonoBehaviour
{
    public GameObject prefab_bullet1;
    public GameObject prefab_bullet2;
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
    void Shot1()
    {
        GameObject o = Instantiate(prefab_bullet1, transform.position, Quaternion.identity);
        o.GetComponent<zHypnosicBullet>().direction = -transform.right * transform.localScale.x / Mathf.Abs(transform.localScale.x);
    }
    void Shot2()
    {
        GameObject o = Instantiate(prefab_bullet2, transform.position, Quaternion.identity);
        o.GetComponent<zBossWolf_Bullet>().direction = -transform.right * transform.localScale.x / Mathf.Abs(transform.localScale.x);
    }
    void dead() {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss")) {
            Debug.Log("Catch Boss Attack");
            CancelInvoke();
            anim.SetTrigger("Dead");
        }
    }
}
