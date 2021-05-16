using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class zBossTornado : MonoBehaviour
{

    public zBoss boss;
    public GameObject turnOffWhenDead;
    public GameObject TornadoBounce;
    public GameObject _winArea;
    public GameObject _TornadoAttack1;
    public GameObject _TornadoAttack2;
    public float delayBetween2Waves = 0.5f;
    public float delayBetween2Attack = 0.5f;
    public float timeWaitCamera = 0.5f;
    public float timeSoundBossAttack = 0.5f;
    public float timeWaitBossAttackFinish = 0.5f;
    public float durationShakeCamera = 2.5f;
    public float timeStartAttack = 0.5f;
    public AudioClip sound_Scream;
    public AudioClip sound_Hurt;
    public AudioClip sound_Dead;
    public AudioClip sound_FallBack;
    public AudioClip sound_Jump;
    public AudioClip sound_Attack;

    Vector3 StartPos;
    int countHurt;

    private void Awake()
    {
        StartPos = transform.position;
    }
    private void Start()
    {
        zBoss.instance.hurt = PlayHurtAction;
        zBoss.instance.dead = PlayDeadAction;
        StartCoroutine(ShowOff());
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

        //Unlock player control
        zPlayer.instance.isLoseControl = false;

        //TornadoBounce.

        yield return new WaitForSeconds(timeStartAttack);
        reCallAttackAction();
    }
    void reCallAttackAction() {
        if (countHurt < 3)
        {
            StartCoroutine(Attack1());
        }
        else {
            StartCoroutine(Attack2());
        }
    }
    IEnumerator Attack1()
    {
        //Get direction attack Player
        Vector3 direction = zPlayer.instance.transform.position - transform.position;
        //Instantiate Attack Wave
        InstantiateTornadoAttack1(direction);
        yield return new WaitForSeconds(delayBetween2Waves);
        InstantiateTornadoAttack1(Quaternion.Euler(0, 0, 30) * direction);
        InstantiateTornadoAttack1(Quaternion.Euler(0, 0, -30) * direction);
        yield return new WaitForSeconds(delayBetween2Waves);
        InstantiateTornadoAttack1(direction);
        //End Instantiate Attack Wave and recall Attack action
        yield return new WaitForSeconds(delayBetween2Attack);
        reCallAttackAction();
    }
    IEnumerator Attack2()
    {
        //Get direction attack Player
        Vector3 direction = zPlayer.instance.transform.position - transform.position;
        //Instantiate Attack Wave
        InstantiateTornadoAttack1(direction);
        yield return new WaitForSeconds(delayBetween2Waves);
        InstantiateTornadoAttack1(Quaternion.Euler(0, 0, 30) * direction);
        InstantiateTornadoAttack1(Quaternion.Euler(0, 0, -30) * direction);
        yield return new WaitForSeconds(delayBetween2Waves);
        InstantiateTornadoAttack1(direction);
        InstantiateTornadoAttack1(Quaternion.Euler(0, 0, 60) * direction);
        InstantiateTornadoAttack1(Quaternion.Euler(0, 0, -60) * direction);
        //End Instantiate Attack Wave and recall Attack action
        yield return new WaitForSeconds(delayBetween2Attack);
        reCallAttackAction();
    }
    IEnumerator AttackWhenHurt()
    {
        //Get direction attack Player
        Vector3 direction = zPlayer.instance.transform.position - transform.position;
        InstantiateTornadoAttack2(direction);
        InstantiateTornadoAttack1(Quaternion.Euler(0, 0, 60) * direction);
        InstantiateTornadoAttack1(Quaternion.Euler(0, 0, 120) * direction);
        InstantiateTornadoAttack1(Quaternion.Euler(0, 0, 180) * direction);
        InstantiateTornadoAttack1(Quaternion.Euler(0, 0, 240) * direction);
        InstantiateTornadoAttack1(Quaternion.Euler(0, 0, 300) * direction);
        //End Instantiate Attack Wave and recall Attack action
        yield return new WaitForSeconds(delayBetween2Attack);
        reCallAttackAction();
    }
    void InstantiateTornadoAttack1(Vector3 direction) { 
        GameObject o = Instantiate(_TornadoAttack1, transform.position, Quaternion.identity) as GameObject;
        o.GetComponent<zBossTornado_Attack1>().direction = direction;
    }
    void InstantiateTornadoAttack2(Vector3 direction)
    {
        GameObject o = Instantiate(_TornadoAttack2, transform.position, Quaternion.identity) as GameObject;
        o.GetComponent<zBossTornado_Attack2>().direction = direction;
    }
    #region Hurt And dead animation and sound
    void PlayHurtAction(bool value)
    {
        if (value)
        {
            //play hurt animation
            countHurt++;
            StopAllCoroutines();
            StartCoroutine(AttackWhenHurt());
            AudioSource.PlayClipAtPoint(sound_Hurt, transform.position);
        }
    }

    void PlayDeadAction(bool value)
    {
        if (value)
        {
            //play dead animation
            AudioSource.PlayClipAtPoint(sound_Dead, transform.position);
            StopAllCoroutines();
            TornadoBounce.SetActive(false);
            GameObject[] attacks = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject o in attacks) {
                Destroy(o);
            }
            StartCoroutine(InstantiateWinArea());   
        }
    }

    IEnumerator InstantiateWinArea()
    {
        
        yield return new WaitForSeconds(1.75f);
        turnOffWhenDead.SetActive(false);
        Instantiate(_winArea, transform.position, Quaternion.identity);
    }
    #endregion
}