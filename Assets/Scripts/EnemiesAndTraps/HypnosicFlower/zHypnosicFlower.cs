using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zHypnosicFlower : MonoBehaviour {
    public GameObject prefab_bullet;
    public float delayTimeBetweenAttack = 2.0f;
    Animator anim;

	void Start () {
        anim = GetComponent<Animator>();

        InvokeRepeating("Attack", 0, delayTimeBetweenAttack);
	}
    void Attack() {
        anim.SetTrigger("Attack");
    }
    void Shot() {
        GameObject o = Instantiate(prefab_bullet, transform.position, Quaternion.identity);
        o.GetComponent<zHypnosicBullet>().direction = transform.up;
    }
}
