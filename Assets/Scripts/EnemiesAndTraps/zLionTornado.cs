using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zLionTornado : MonoBehaviour
{

    public GameObject prefab_Tornado;
    public Transform Pos_InitTornado;
    public float sizeTornado = 0.7f;
    public AudioClip sound_FallBack;
    public AudioClip sound_Jump;
    public AudioClip sound_Attack;
    bool isAttack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!zPlayer.instance.isDead)
            {
                if (!isAttack)
                {
                    StartCoroutine(i_Attack());
                }
            }
        }
    }

    public void Attack()
    {
        StartCoroutine(i_Attack());
    }

    IEnumerator i_Attack()
    {
        isAttack = true;
        AudioSource.PlayClipAtPoint(sound_FallBack, transform.position);
        GetComponent<Animator>().SetTrigger("IsAttack");
        yield return new WaitForSeconds(1.5f);

        isAttack = false;
    }

    void InitTornado()
    {
        GameObject o = Instantiate(prefab_Tornado) as GameObject;
        o.transform.localScale = new Vector3(sizeTornado * transform.localScale.x, sizeTornado, sizeTornado);
        o.transform.position = Pos_InitTornado.position;
        o.transform.rotation = transform.rotation;
        AudioSource.PlayClipAtPoint(sound_Attack, transform.position);
    }

}
