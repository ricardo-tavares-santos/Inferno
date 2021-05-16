using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour
{ /*
    public static UnityAds instance;
    public string gameID;
    string gameID_IOS = GameInfo.IOS.UnityAdsID;
    string gameID_Android = GameInfo.Android.UnityAdsID;
    bool enableTestMode;

    void MakeInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);

#if UNITY_ANDROID
            gameID = gameID_Android;
#elif UNITY_IPHONE
            gameID = gameID_IOS;
#endif
            if (Advertisement.isSupported)
            {
                Advertisement.Initialize(gameID, enableTestMode);
            }
        }
    }
    void Start()
    {
        MakeInstance();
    }


    public void ShowSkipVideoAds()
    {
        if (Advertisement.IsReady("video"))
        {
            ShowOptions options1 = new ShowOptions();
            options1.resultCallback = HandleShowResult_skipAds;
            Advertisement.Show("video", options1);
        }
        else
        {
            Debug.Log("Ad not loaded");
        }
    }
    public void ShowRewardedVideoAds()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            ShowOptions options = new ShowOptions();
            options.resultCallback = HandleShowResult;
            Advertisement.Show("rewardedVideo", options);
        }
        else
        {
            Debug.Log("Ad not loaded");
        }
    }
    private void HandleShowResult_skipAds(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Video completed. User rewarded for skip ads.");
                if (zPlayer.instance != null)
                {
                    zPlayer.instance.f_IncreaseLife_SkipAds();
                }
                break;
            case ShowResult.Skipped:
                Debug.LogWarning("Video was skipped.");
                if (zPlayer.instance != null)
                {
                    zPlayer.instance.f_IncreaseLife_SkipAds();
                }
                break;
            case ShowResult.Failed:
                Debug.LogError("Video failed to show.");
                break;
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Video completed. User rewarded for full video ads.");
                if (zPlayer.instance != null)
                {
                    zPlayer.instance.f_IncreaseLife_VideoAds();
                }
                break;
            case ShowResult.Skipped:
                Debug.LogWarning("Video was skipped.");
                break;
            case ShowResult.Failed:
                Debug.LogError("Video failed to show.");
                break;
        }
    } */
}
