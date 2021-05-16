using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class zVenusFlyTrap : MonoBehaviour
{
    public GameObject Head;
    public GameObject JawLeft;
    public GameObject JawRight;
    public float StandBackSpeed = 0.4f;
    public float AttakSpeed = 0.1f;
    public float DelayNextAttack = 0.2f;
    public float FallBackAfterAttackSpeed = 0.8f;
    public float DelayAfterFallBack = 1.0f;
    public Vector3 FallBackVector3 = new Vector3(0.0f, 0.3f, 0.0f);
    public AudioClip sound_FallBack;
    public AudioClip sound_Jump;
    public AudioClip sound_Attack;
    bool isAttack;
    Vector3 StartPos;
    Quaternion StartRotation;
    private void Start()
    {
        StartPos = Head.transform.position;
        StartRotation = Head.transform.rotation;
        JawLeft.transform.DOLocalRotate(new Vector3(0.0f, 0.0f, 10.0f), DelayAfterFallBack);
        JawRight.transform.DOLocalRotate(new Vector3(0.0f, 0.0f, -10.0f), DelayAfterFallBack);
    }
    private void OnEnable()
    {
        isAttack = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!zPlayer.instance.isDead)
            {
                if (!isAttack)
                {
                    StartCoroutine(Attack(collision.transform.position));
                }
            }
        }
    }
    IEnumerator Attack(Vector3 pos)
    {
        isAttack = true;

        // Make Plant Look at player 
        Vector3 dir = zPlayer.instance.transform.position - Head.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //Plant Stand back
        AudioSource.PlayClipAtPoint(sound_FallBack, transform.position);
        Head.transform.DOMove(Head.transform.position - FallBackVector3, StandBackSpeed);
        Head.transform.DORotate(Quaternion.AngleAxis(angle - 90.0f, Vector3.forward).eulerAngles, StandBackSpeed);
        yield return new WaitForSeconds(StandBackSpeed);

        //Plant attack
        AudioSource.PlayClipAtPoint(sound_Attack, transform.position);
        JawLeft.transform.DOLocalRotate(new Vector3(0.0f, 0.0f, 20.0f), AttakSpeed);
        JawRight.transform.DOLocalRotate(new Vector3(0.0f, 0.0f, -20.0f), AttakSpeed);
        Head.transform.DOMove(pos, AttakSpeed);
        yield return new WaitForSeconds(AttakSpeed);
        JawLeft.transform.DOLocalRotate(new Vector3(0.0f, 0.0f, -3.0f), DelayNextAttack);
        JawRight.transform.DOLocalRotate(new Vector3(0.0f, 0.0f, 3.0f), DelayNextAttack);
        yield return new WaitForSeconds(DelayNextAttack);

        //Plant Fallback
        Head.transform.DOMove(StartPos, FallBackAfterAttackSpeed);
        Head.transform.DORotate(StartRotation.eulerAngles, FallBackAfterAttackSpeed);
        yield return new WaitForSeconds(FallBackAfterAttackSpeed + DelayAfterFallBack);
        JawLeft.transform.DOLocalRotate(new Vector3(0.0f, 0.0f, 10.0f), DelayNextAttack);
        JawRight.transform.DOLocalRotate(new Vector3(0.0f, 0.0f, -10.0f), DelayNextAttack);
        isAttack = false;
    }
}
