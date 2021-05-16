using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class zBossWolf : MonoBehaviour
{

    public zBoss boss;
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

    int countHurt;

    private void Start()
    {
        boss = zBoss.instance.GetComponent<zBoss>();
        StartCoroutine(ShowOff());
        zBoss.instance.hurt = PlayHurtAnimation;
        zBoss.instance.dead = PlayDeadAnimation;
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
    }

    #region Hurt And dead animation and sound
    void PlayHurtAnimation(bool value)
    {
        if (value)
        {
            //play hurt animation
            AudioSource.PlayClipAtPoint(sound_Hurt, transform.position);
            countHurt++;
        }
    }

    void PlayDeadAnimation(bool value)
    {
        if (value)
        {
            //play dead animation
            AudioSource.PlayClipAtPoint(sound_Dead, transform.position);
            InstantiateWinArea();
        }
    }

    void InstantiateWinArea()
    {
        Destroy(gameObject);
        Instantiate(_winArea, transform.position, Quaternion.identity);
    }
    #endregion
}