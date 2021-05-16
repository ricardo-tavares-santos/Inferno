using UnityEngine;
using GoogleMobileAds.Api;
using System;

//public class GoogleMobileAdsDemoHandler : IDefaultInAppPurchaseProcessor
//{
//    private readonly string[] validSkus = { "android.test.purchased" };

//    //Will only be sent on a success.
//    public void ProcessCompletedInAppPurchase(IInAppPurchaseResult result)
//    {
//        result.FinishPurchase();
//        AdsController.OutputMessage = "Purchase Succeeded! Credit user here.";
//    }

//    //Check SKU against valid SKUs.
//    public bool IsValidPurchase(string sku)
//    {
//        foreach (string validSku in validSkus)
//        {
//            if (sku == validSku)
//            {
//                return true;
//            }
//        }
//        return false;
//    }

//    //Return the app's public key.
//    public string AndroidPublicKey
//    {
//        //In a real app, return public key instead of null.
//        get { return null; }
//    }
//}

public class AdsController : MonoBehaviour
{
    public static AdsController instance;
    public BannerView bannerView;
    private static RewardBasedVideoAd rewardBasedVideo;
    private static InterstitialAd interstitial;
    private static string outputMessage = "";
    public static string OutputMessage
    {
        set { outputMessage = value; }
    }
	
	private int premioRW;

    public string android_BannerAds;
    public string android_FullAds;
    public string android_VideoAds;
    public string ios_BannerAds;
    public string ios_FullAds;
    public string ios_VideoAds;
    const string CountAds = "CountAds";
    int _CountAds;
    void Awake()
    {
        MakeSingleton();
        if (!PlayerPrefs.HasKey(CountAds))
        {
            PlayerPrefs.SetInt(CountAds, 0);
        }
        _CountAds = PlayerPrefs.GetInt(CountAds);

    }
    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            //SetID
			int noAds = PlayerPrefs.GetInt("NoAds");
			if (noAds != 667) { android_BannerAds = "ca-app-pub-2697339358784861/7639688232"; } else { android_BannerAds = ""; }
            android_FullAds = GameInfo.Android.GoogleAds_FullAds;
            android_VideoAds = GameInfo.Android.GoogleAds_VideoAds;
            ios_BannerAds = GameInfo.IOS.GoogleAds_BannerAds;
            ios_FullAds = GameInfo.IOS.GoogleAds_FullAds;
            ios_VideoAds = GameInfo.IOS.GoogleAds_VideoAds;


            RequestRewardBasedVideo();
            RequestBanner();
            RequestInterstitial();
        }
    }
    public void RequestRewardBasedVideo ()
    {
    #if UNITY_EDITOR
         string adUnitId = "unused";
    #elif UNITY_ANDROID
          string adUnitId = android_VideoAds;
    #else
              string adUnitId = "unexpected_platform";
    #endif

        // Get singleton reward based video ad reference.
        rewardBasedVideo = RewardBasedVideoAd.Instance;

        // RewardBasedVideoAd is a singleton, so handlers should only be registered once.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;
			
        AdRequest request = new AdRequest.Builder ().Build ();
        rewardBasedVideo.LoadAd (request, adUnitId);
    }

    public void RequestBanner()
    {
        AdSize adsize = AdSize.SmartBanner;
        int width = Screen.currentResolution.width;
        int height = Screen.currentResolution.height;

        if (width >= 728 && height >= 90)
        {
            adsize = AdSize.Leaderboard;
        }
        else if (width >= 468 && height >= 60)
        {
            adsize = AdSize.IABBanner;
        }
        else if (width >= 320 && height >= 50)
        {
            adsize = AdSize.Banner;
        }

#if UNITY_ANDROID
        string adUnitId = android_BannerAds;
        bannerView = new BannerView (adUnitId, AdSize.Banner, AdPosition.Bottom);
#elif UNITY_IPHONE
        string adUnitId = ios_BannerAds;
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
#else
        string adUnitId = ios_BannerAds;
        bannerView = new BannerView (adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
#endif

        // Register for ad events.
        bannerView.OnAdLoaded += HandleAdLoaded;
        bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
        bannerView.OnAdLoaded += HandleAdOpened;
        bannerView.OnAdClosed += HandleAdClosed;
        bannerView.OnAdLeavingApplication += HandleAdLeftApplication;
        AdRequest request = new AdRequest.Builder().Build();
        bannerView.LoadAd(request);
    }
    public void HideBanner()
    {
        if (bannerView != null)
        {
            Debug.Log("HideBanner");
            bannerView.Hide();
        }
    }
    public void ShowBanner()
    {
		int noAds = PlayerPrefs.GetInt("NoAds");
        if (noAds != 667)
        {
			
		//	if (bannerView != null)
		//	{
				Debug.Log("ShowBanner");
				bannerView.Show();
				
		//	}
        }
    }
    public void RequestInterstitial()
    {

#if UNITY_ANDROID
        string adUnitId = android_FullAds;
#elif UNITY_IPHONE
        string adUnitId = ios_FullAds;
#else
        string adUnitId = ios_FullAds;
#endif

        // Create an interstitial.
        interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();

        // Register for ad events.
        interstitial.OnAdClosed += HandleInterstitialAdClosed;
        interstitial.OnAdFailedToLoad += HandleInterstitialAdFailedToLoad;
        interstitial.OnAdLeavingApplication += HandleInterstitialAdLeftApplication;
        interstitial.OnAdLoaded += HandleInterstitialAdLoaded;
        interstitial.OnAdOpening += HandleInterstitialAdOpening;
        // Load an interstitial ad.
        interstitial.LoadAd(request);
    }


    public void ShowRewardBasedVideo(int premio)
    {
		premioRW = premio;
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
			RequestRewardBasedVideo();
        }
    }

    public void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
            RequestInterstitial();
        }
    }

    #region Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args)
    {
        //		print("Loaded event received.");
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        //		print("Failed event received.");
    }

    public void HandleAdOpened(object sender, EventArgs args)
    {
        //		print("Opened event received.");
    }

    void HandleAdClosing(object sender, EventArgs args)
    {
        //		print("Closing event received.");
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
        //		print("Closed event received.");
    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        //		print("Left event received.");
    }

    #endregion


    #region RewardBasedVideo callback handlers

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        //		print("HandleRewardBasedVideoLoaded event received.");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        //		print("HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        //		print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {


    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {

    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
		if (premioRW==1) {
			zPlayer.instance.f_IncreaseLife_SkipAds();
		} else {		
			zPlayer.instance.f_IncreaseLife_VideoAds();
		}	
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {

    }

    #endregion

    #region Interstitials

    public void HandleInterstitialAdLoaded(object sender, EventArgs args)
    {
    }

    public void HandleInterstitialAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {

    }

    public void HandleInterstitialAdOpening(object sender, EventArgs args)
    {
        if (zSoundController.instance != null)
        {
            zSoundController.instance.Pause();
        }
    }

    public void HandleInterstitialAdClosed(object sender, EventArgs args)
    {
        if (zSoundController.instance != null)
        {
            zSoundController.instance.resume();
        }
    }

    public void HandleInterstitialAdLeftApplication(object sender, EventArgs args)
    {
        //		print("HandleRewardBasedVideoLeft event received");
    }

    #endregion

    public void IncreaseCountFullAdsWhenDeath()
    {
        _CountAds++;
    }
    public void CheckFullAds()
    {
		
		int noAds = PlayerPrefs.GetInt("NoAds");
        if (noAds != 667)
        {

			if (_CountAds >= 1)
			{
				ShowInterstitial();
				_CountAds = 0;
			}
			
		}	
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(CountAds, _CountAds);
    }
    private void OnApplicationPause()
    {
        PlayerPrefs.SetInt(CountAds, _CountAds);
    }
}
