using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class zUIGroupController : MonoBehaviour
{
    public static zUIGroupController instance;
    public GameObject btn_TestMode;
    public GameObject panel_Revival;
    public GameObject panel_Win;
    public GameObject panel_Tutorial;
    public GameObject panel_Pause;
    public GameObject panel_Ads;
    public GameObject panel_BossWarning;
    public GameObject panel_WinToNextCircle;
    public GameObject btn_NextLevel;
    public GameObject btn_NextCircle;
    public Text message;
    public Text life;
    public Text time;
    int minutes;
    public float second;
    public Image btn_Sound;
    public Sprite SoundOn;
    public Sprite SoundOff;
    public Image[] Stars;
    public Sprite StarON;
    private void Awake()
    {
        MakeInstance();
        Color c = btn_TestMode.GetComponent<Image>().color;
        c.a = 0.2f;
        btn_TestMode.GetComponent<Image>().color = c;

        //Setup for Sound Button
        btn_Sound.sprite = SoundOn;
        AudioListener.volume = 1.0f;
    }
    private void Start()
    {
        life.text = zPlayer.instance.f_GetLife().ToString();
        panel_Revival.SetActive(false);
        panel_Win.SetActive(false);
        panel_Tutorial.SetActive(false);
        panel_Pause.SetActive(false);
        panel_Ads.SetActive(false);
        panel_BossWarning.SetActive(false);
        message.text = "";
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        second += Time.deltaTime;
        minutes = (int)(second / 60);
        time.text = ((int)(second / 60)).ToString("00") + " : " + ((int)(second - minutes * 60)).ToString("00");
    }

    public void SetStar()
    {
        Debug.Log("SetStar");
        //Only call this function for those levels which were unlocked
        int _mapID = 0;
        if (zMapController.instance != null)
        {
            _mapID = zMapController.instance.GetIDLevel();
        }
        _mapID++;
        int starcount = 1;

        if (zPlayer.instance.deathCount <= _mapID)
        {
            starcount++;
        }
        if (second <= 60 * 2 + 20 * _mapID)
        {
            starcount++;
        }
        Debug.Log("Startcount " + starcount);
        switch (starcount)
        {
            case 1:
                Stars[0].sprite = StarON;
                Stars[3].sprite = StarON;
                break;
            case 2:
                Stars[0].sprite = StarON;
                Stars[1].sprite = StarON;
                Stars[3].sprite = StarON;
                Stars[4].sprite = StarON;
                break;
            case 3:
                Stars[0].sprite = StarON;
                Stars[1].sprite = StarON;
                Stars[2].sprite = StarON;
                Stars[3].sprite = StarON;
                Stars[4].sprite = StarON;
                Stars[5].sprite = StarON;
                break;
            default:
                Stars[0].sprite = StarON;
                Stars[3].sprite = StarON;
                break;
        }
    }

    //Give message to the screen
    public void f_ShowMessage(string _message)
    {
        StartCoroutine(i_f_ShowMessage(_message));
    }
    IEnumerator i_f_ShowMessage(string _message)
    {
        message.text = _message;
        yield return new WaitForSeconds(1.0f);
        message.text = "";
    }

    //4 functions to set player's flag of moving behaviour
    public void f_PointerDownPanelLeft()
    {
        zPlayer.instance.f_PointerDownPanelLeft();
    }
    public void f_PointerUpPanelLeft()
    {
        zPlayer.instance.f_PointerUpPanelLeft();
    }
    public void f_PointerDownPanelRight()
    {
        zPlayer.instance.f_PointerDownPanelRight();
    }
    public void f_PointerUpPanelRight()
    {
        zPlayer.instance.f_PointerUpPanelRight();
    }

    // 2 function for revival panel
    public void f_Revival_Yes()
    {
        ResumeTimeScale();
        zPlayer.instance.f_Revival_Yes();
    }

    public void f_BackToMenu()
    {
        ResumeTimeScale();
        zGameController.instance.f_BackToMenu();
    }

    public void f_NextLevel()
    {
        ResumeTimeScale();
        zGameController.instance.f_NextLevel();
    }
    public void f_NextCircle()
    {
        ResumeTimeScale();
        zGameController.instance.f_NextCircle();
    }
    public void f_TestMode()
    {
        if (!zPlayer.instance.f_TestMode())
        {
            Color c = btn_TestMode.GetComponent<Image>().color;
            c.a = 0.2f;
            btn_TestMode.GetComponent<Image>().color = c;
        }
        else
        {
            Color c = btn_TestMode.GetComponent<Image>().color;
            c.a = 1.0f;
            btn_TestMode.GetComponent<Image>().color = c;
        }
    }
    public void f_WinPanel_TurnOn()
    {
        if (!zPlayer.instance.isDead)
        {
            zPlayer.instance.isWin = true;
            if (zMapController.instance != null)
            {
                if (zMapController.instance.isTheLastLevel(zMapController.instance.GetIDCircle()))
                {
                    btn_NextLevel.SetActive(false);
                }
            }
            PauseTimeScale();
            f_PanelRevival_TurnOff();
            f_PanelAds_TurnOFF();
            f_PausePanel_TurnOff();
            f_TutorialPanel_TurnOff();

            panel_Win.SetActive(true);
        }
    }
    public void f_WinPanelToNextCircle_TurnOn()
    {
        if (!zPlayer.instance.isDead)
        {
            zPlayer.instance.isWin = true;
            if (zMapController.instance != null)
            {
                if (zMapController.instance.isTheLastCircle())
                {
                    btn_NextCircle.SetActive(false);
                }
            }
            PauseTimeScale();
            f_PanelRevival_TurnOff();
            f_PanelAds_TurnOFF();
            f_PausePanel_TurnOff();
            f_TutorialPanel_TurnOff();

            panel_WinToNextCircle.SetActive(true);
        }
    }
    public void f_BossWarningPanel_TurnOn()
    {
        if (!zPlayer.instance.isDead)
        {
            PauseTimeScale();
            f_PanelRevival_TurnOff();
            f_PanelAds_TurnOFF();
            f_PausePanel_TurnOff();
            f_TutorialPanel_TurnOff();

            panel_BossWarning.SetActive(true);
        }
    }
    public void f_BossWarning_Ready()
    {
        zGameController.instance.f_BossWarning_Ready();
    }
    public void f_TutorialPanel_TurnOn()
    {
        PauseTimeScale();
        panel_Tutorial.SetActive(true);
    }
    public void f_TutorialPanel_TurnOff()
    {
        ResumeTimeScale();
        panel_Tutorial.SetActive(false);
    }
    public void f_PausePanel_TurnOn()
    {
        PauseTimeScale();
        f_TutorialPanel_TurnOff();

        panel_Pause.SetActive(true);
    }
    public void f_PausePanel_TurnOff()
    {
        ResumeTimeScale();
        panel_Pause.SetActive(false);
    }
    public void f_PanelRevival_TurnOn()
    {
        //StartCoroutine(i_f_PanelRevival_TurnOn());
        PauseTimeScale();
        f_PanelAds_TurnOFF();
        f_PausePanel_TurnOff();
        f_TutorialPanel_TurnOff();
        panel_Revival.SetActive(true);
    }

    IEnumerator i_f_PanelRevival_TurnOn()
    {
        //In first version the animator of each child object in panel run faster than the panel, this coroutine is using to fix it.
        //but unity have fixed it in version 2017.3.1f1, however I think we shouldnt delete this code.
        f_PanelAds_TurnOFF();
        f_PausePanel_TurnOff();
        f_TutorialPanel_TurnOff();

        Animator[] anims = panel_Revival.GetComponentsInChildren<Animator>();
        foreach (Animator a in anims)
        {
            if (a.gameObject != gameObject)
            {
                a.gameObject.SetActive(false);
            }
        }
        panel_Revival.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        PauseTimeScale();
        foreach (Animator a in anims)
        {
            if (a.gameObject != gameObject)
            {
                a.gameObject.SetActive(true);
            }
        }
    }
    public void f_PanelRevival_TurnOff()
    {
        ResumeTimeScale();
        panel_Revival.SetActive(false);
    }
    public void f_PanelAds_TurnON()
    {
        PauseTimeScale();
        panel_Ads.SetActive(true);
    }
	
	
	 
    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(2);
    }	
    public void f_PanelAds_TurnOFF()
    {
		//StartCoroutine(WaitAndPrint());
        panel_Ads.SetActive(false);
    }
	
	
    public void f_Sound()
    {
        if (btn_Sound.sprite == SoundOn)
        {
            btn_Sound.sprite = SoundOff;
            AudioListener.volume = 0.0f;
        }
        else
        {
            btn_Sound.sprite = SoundOn;
            AudioListener.volume = 1.0f;
        }
    }
    public void f_replay()
    {
        ResumeTimeScale();
        if (AdsController.instance != null)
        {
            AdsController.instance.CheckFullAds();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void f_UnitySkipAds()
    {
       /* 3 ??? if (UnityAds.instance != null)
        {
            UnityAds.instance.ShowSkipVideoAds();
        } */ 
		AdsController.instance.ShowRewardBasedVideo(1);
    }
    public void f_UnityRewardAds()
    {
        /* 5 ??? if (UnityAds.instance != null)
        {
            UnityAds.instance.ShowRewardedVideoAds();
        } */
		AdsController.instance.ShowRewardBasedVideo(1);
    }
    public void f_rate()
    {
		Application.OpenURL("https://fb.me/rwdesenvgames");
    }
    public void f_Leaderboard()
    {
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.RWdesenv.Inferno");
#if UNITY_IOS
        //LeaderBoardController.instance.OpenLeaderboards();
#else
        //LeaderBoardController.instance.OpenLeaderboards();
#endif
    }
	
	
	string subject = "Inferno";
	string body = "Inferno\n\nAndroid\nhttps://play.google.com/store/apps/details?id=com.RWdesenv.Inferno\n\niOS Games\nhttps://itunes.apple.com/us/developer/willian-sato/id1308106832";	 
	public void shareText(){
		//execute the below lines if being run on a Android device
		#if UNITY_ANDROID
			  //Refernece of AndroidJavaClass class for intent
			  AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
			  //Refernece of AndroidJavaObject class for intent
			  AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
			  //call setAction method of the Intent object created
			  intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
			  //set the type of sharing that is happening
			  intentObject.Call<AndroidJavaObject>("setType", "text/plain");
			  //add data to be passed to the other activity i.e., the data to be sent
			  intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
			  intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body);
			  //get the current activity
			  AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
			  AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
			  //start the activity by sending the intent data
			  currentActivity.Call ("startActivity", intentObject);
		#endif
	}	
	
    public void f_ShareFB()
    {
		shareText();
        //??? ShareFB.instance.OnShareFBClick();
    }
    void PauseTimeScale()
    {
        //Time.timeScale = 0.0f;
    }
    void ResumeTimeScale()
    {
        //Time.timeScale = 1.0f;
    }
}
