using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zPlayer : MonoBehaviour
{
    public static zPlayer instance;
    public GameObject PS_Normal;
    public GameObject PS_Poison;
    public GameObject NormalPlayer;
    public GameObject DeadPlayer;
    public Transform img;
    public Transform checkPoint;
    public AudioClip DeadSoundEffect;
    public bool isMoveLeft;
    public bool isMoveRight;
    public bool isDead;
    public bool isPoisoned;
    public bool isLoseControl;
    public bool isWin;
    public bool isTestMode;
    public int deathCount;

    Rigidbody2D mRigid;
    public bool isGetLife_;
    public float timePoison;
    int life = 2;

    private void Awake()
    {
        MakeInstance();
    }

    private void Start()
    {
        if (zMapController.instance != null)
        {
            if (zMapController.instance.GetIDLevel() <= 3)
            {
                life = 5;
            }
            else if (zMapController.instance.GetIDLevel() <= 6)
            {
                life = 4;
            }
            else
            {
                life = 3;
            }
            zUIGroupController.instance.life.text = life.ToString();
        }
        mRigid = GetComponent<Rigidbody2D>();
        if (zSoundController.instance != null)
        {
            DeadSoundEffect = zSoundController.instance.DeadSoundEffect;
        }
        isMoveLeft = false;
        isMoveRight = false;
        NormalPlayer.SetActive(true);
        PS_Normal.SetActive(true);
        PS_Poison.SetActive(false);
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void f_PointerDownPanelLeft()
    {
        isMoveLeft = true;
    }
    public void f_PointerUpPanelLeft()
    {
        isMoveLeft = false;
    }
    public void f_PointerDownPanelRight()
    {
        isMoveRight = true;
    }
    public void f_PointerUpPanelRight()
    {
        isMoveRight = false;
    }

    private void Update()
    {
        U_Keyboard();
    }

    void U_Keyboard()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            f_PointerDownPanelLeft();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            f_PointerUpPanelLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            f_PointerDownPanelRight();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            f_PointerUpPanelRight();
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            f_Revival_Yes();
        }
        if (Input.GetKeyUp(KeyCode.N))
        {
            zUIGroupController.instance.f_TestMode();
        }
    }

    private void FixedUpdate()
    {
        FU_PlayerMove();
    }
    void FU_PlayerMove()
    {
        if (!isDead && !isLoseControl)
        {
            if (!isPoisoned)
            {
                if (isMoveLeft && !isMoveRight)
                {
                    mRigid.velocity = new Vector2(-1.5f, 3.0f);
                }
                else if (!isMoveLeft && isMoveRight)
                {
                    mRigid.velocity = new Vector2(1.5f, 3.0f);
                }
                else if (isMoveLeft && isMoveRight)
                {
                    mRigid.velocity = new Vector2(0.0f, 3.0f);
                }
            }
            else
            {
                timePoison -= Time.deltaTime;
                if (timePoison < 0.0f)
                {
                    detoxicatePlayer();
                }
                if (isMoveLeft && !isMoveRight)
                {
                    mRigid.velocity = new Vector2(1.0f, 2.0f);
                }
                else if (!isMoveLeft && isMoveRight)
                {
                    mRigid.velocity = new Vector2(-1.0f, 2.0f);
                }
                else if (isMoveLeft && isMoveRight)
                {
                    mRigid.velocity = new Vector2(0.0f, 2.4f);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            if (!isTestMode && !isWin)
            {
                if (!isDead)
                {
                    isDead = true;
                    deathCount++;
                    if (!isGetLife_)
                    {
                        if (AdsController.instance != null)
                        {
                            AdsController.instance.IncreaseCountFullAdsWhenDeath();
                        }
                    }
                    AudioSource.PlayClipAtPoint(DeadSoundEffect, transform.position);
                    Dead_ShowRevival();
                }
            }
        }
        if (collision.CompareTag("CheckPoint"))
        {
            if (!isDead)
            {
                checkPoint = collision.transform;
            }
        }
        if (collision.CompareTag("Orchid"))
        {
            if (!isDead)
            {
                poisonPlayer();
            }
        }
        if (collision.CompareTag("Tornado"))
        {
            if (!isTestMode && !isDead)
            {
                if (collision.transform.localScale.x > 0.0f)
                {
                    StartCoroutine(i_Windy(true));
                }
                else
                {
                    StartCoroutine(i_Windy(false));
                }
            }
        }
        if (collision.CompareTag("TornadoBounce"))
        {
            if (!isTestMode && !isDead)
            {
                StartCoroutine(i_Bounce());
                mRigid.velocity = Vector3.Reflect(mRigid.velocity.normalized * 10.0f, (transform.position - collision.transform.position).normalized);
            }
        }
    }
    IEnumerator i_Bounce()
    {
        isLoseControl = true;
        yield return new WaitForSeconds(1.0f);
        isLoseControl = false;
    }
    IEnumerator i_Windy(bool isRight)
    {
        isLoseControl = true;
        if (isRight)
        {
            mRigid.velocity = new Vector2(15.0f, 5.0f);
        }
        else
        {
            mRigid.velocity = new Vector2(-15.0f, 5.0f);
        }
        yield return new WaitForSeconds(1.0f);
        isLoseControl = false;
    }
    void poisonPlayer()
    {
        timePoison = 5.0f;
        isPoisoned = true;
        PS_Normal.SetActive(false);
        PS_Poison.SetActive(true);
    }
    void detoxicatePlayer()
    {
        PS_Normal.SetActive(true);
        PS_Poison.SetActive(false);
        isPoisoned = false;
    }
    public void Dead_ShowRevival()
    {
        StartCoroutine(i_Dead_ShowRevival());
    }
    IEnumerator i_Dead_ShowRevival()
    {
        NormalPlayer.SetActive(false);
        GameObject o = Instantiate(DeadPlayer, transform.position, Quaternion.identity) as GameObject;
        Destroy(o, 2.0f);
        zUIGroupController.instance.f_PanelRevival_TurnOn();
        yield return new WaitForSeconds(0.01f);

    }

    public void f_Revival_Yes()
    {
        if (AdsController.instance != null)
        {
            AdsController.instance.CheckFullAds();
        }
        if (life > 0)
        {
            life--;
            zUIGroupController.instance.life.text = life.ToString();
            //active normal state of player
            NormalPlayer.SetActive(true);

            //turnoff panel ask for revival
            zUIGroupController.instance.f_PanelRevival_TurnOff();

            //turnoff poison effect if have
            detoxicatePlayer();

            //move player back to the checkpoint
            transform.position = checkPoint.position;

            //release player
            isDead = false;
        }
        else
        {
            isGetLife_ = true;
            zUIGroupController.instance.f_PanelAds_TurnON();
        }
    }

    public bool f_TestMode()
    {
        isTestMode = !isTestMode;
        return isTestMode;
    }
    public int f_GetLife()
    {
        return life;
    }
    public void f_IncreaseLife_SkipAds()
    {
        life = 1;
        if (zUIGroupController.instance != null)
        {
            zUIGroupController.instance.life.text = life.ToString();
            zUIGroupController.instance.f_PanelAds_TurnOFF();
        }
    }
    public void f_IncreaseLife_VideoAds()
    {
        life = 1;
        if (zUIGroupController.instance != null)
        {
            zUIGroupController.instance.life.text = life.ToString();
            zUIGroupController.instance.f_PanelAds_TurnOFF();
        }
    }

    public void f_IncreaseLife_IAP()
    {
        life = life+5;
        if (zUIGroupController.instance != null)
        {
            zUIGroupController.instance.life.text = life.ToString();
            zUIGroupController.instance.f_PanelAds_TurnOFF();
        }
    }	
	
}
