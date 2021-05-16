using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class zBossVFT : MonoBehaviour
{
    public zBoss boss;
    public GameObject Head;
    public GameObject JawLeft;
    public GameObject JawRight;
    public GameObject bossSword;
    public GameObject _winArea;
    public float StandBackSpeed = 0.4f;
    public float AttakSpeed = 0.1f;
    public float DelayNextAttack = 0.2f;
    public float FallBackAfterAttackSpeed = 0.8f;
    public float DelayAfterFallBack = 1.0f;
    public float timeWaitCamera = 0.5f;
    public float timeSoundBossAttack = 0.5f;
    public float timeWaitBossAttackFinish = 0.5f;
    public float durationShakeCamera = 2.5f;
    public AudioClip sound_Scream;
    public AudioClip sound_Hurt;
    public AudioClip sound_Dead;
    public AudioClip sound_FallBack;
    public AudioClip sound_Jump;
    public AudioClip sound_Attack;
    public Vector3 FallBackVector3 = new Vector3(0.0f, 0.3f, 0.0f);
    public Animator anim;
    public Animator animHead;

    bool isAttack;
    int countHurt;
    Vector3 StartPos;
    Quaternion StartRotation;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        StartPos = Head.transform.position;
        StartRotation = Head.transform.rotation;
        JawLeft.transform.DOLocalRotate(new Vector3(0.0f, 0.0f, 10.0f), DelayAfterFallBack);
        JawRight.transform.DOLocalRotate(new Vector3(0.0f, 0.0f, -10.0f), DelayAfterFallBack);
    }

    private void Start()
    {
        boss = zBoss.instance.GetComponent<zBoss>();
        StartCoroutine(ShowOff());
        zBoss.instance.hurt = PlayHurtAnimation;
        zBoss.instance.dead = PlayDeadAnimation;
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

    IEnumerator ShowOff()
    {
        //State 0: Lock Player control
        zPlayer.instance.isLoseControl = true;

        // State 1: Camera move to Boss
        if (zCameraBoss.instance != null)
        {
            zCameraBoss.instance.SetTarget(transform);
        }
        //AudioSource.PlayClipAtPoint(sound_FallBack, zPlayer.instance.transform.position);
        yield return new WaitForSeconds(timeWaitCamera);// Wait until camera get to boss position

        //State 2: HP bar of boss is filling up
        boss.CallIEnumratorHPFillUp();

        //State 3: Boss roar animation + Sound Attack
        yield return new WaitForSeconds(timeSoundBossAttack);
        AudioSource.PlayClipAtPoint(sound_Scream, zPlayer.instance.transform.position);

        //State 4: Camera Shake
        Camera.main.DOShakePosition(durationShakeCamera, 1, 10, 15, true);
        if (SystemInfo.supportsVibration)
        {
            //Vibrate if device user is support
            Handheld.Vibrate();
        }

        //After boss roar set camera back to player
        yield return new WaitForSeconds(timeWaitBossAttackFinish);
        if (zCameraBoss.instance != null)
        {
            zCameraBoss.instance.SetTarget(zPlayer.instance.transform);
        }

        //Turnoff head animator to unlock head
        animHead.enabled = false;

        //Unlock player control
        zPlayer.instance.isLoseControl = false;
    }

    #region Hurt And dead animation and sound
    void PlayHurtAnimation(bool value)
    {
        if (value)
        {
            //play hurt animation
            GetComponent<Animator>().Play("Boss_VFT_Hurt", 1);
            AudioSource.PlayClipAtPoint(sound_Hurt, transform.position);
            countHurt++;
            if (countHurt < 3)
            {
                StartCoroutine(StateAttack1());
            }
            else
            {
                StateAttack2();
            }
        }
    }

    void PlayDeadAnimation(bool value)
    {
        if (value)
        {
            //play dead animation
            anim.SetLayerWeight(3, 0.0f);
            GetComponent<Animator>().Play("Boss_VFT_Dead", 1);
            AudioSource.PlayClipAtPoint(sound_Dead, transform.position);
            StartCoroutine(InstantiateWinArea());
        }
    }

    IEnumerator InstantiateWinArea() {
        yield return new WaitForSeconds(1.75f);
        Instantiate(_winArea, transform.position, Quaternion.identity);
    }
    #endregion


    IEnumerator StateAttack1()
    {
        //Attack leaf every times boss get hurt
        Debug.Log("StateAttack1");
        anim.SetInteger("StateAttack", 1);
        yield return new WaitForSeconds(1.0f);
        anim.SetInteger("StateAttack", 0);
    }
    void StateAttack2()
    {
        //Attack leaf wont turn off after HP lower than maxHP/2
        anim.SetInteger("StateAttack", 2);
    }
}
