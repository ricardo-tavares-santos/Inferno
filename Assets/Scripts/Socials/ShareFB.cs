using UnityEngine;
using System.Collections;
//using Facebook.Unity;
using System;
public class ShareFB : MonoBehaviour
{ /*
    public static ShareFB instance;
    void Awake()
    {
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
    }
    void Start()
    {
        MakeSingleton();
    }
    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
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
            DontDestroyOnLoad (gameObject);
        }
    }
    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }
    public void OnShareFBClick()
    {
#if UNITY_IOS
        FB.ShareLink(
            new Uri(GameInfo.IOS.URL_RateApp),
            GameInfo.GameName + ", " + "Can you beat my Best Time " + zHighScoreController.instance.GetHighScore_BestTime(1,zMapController.instance.GetIDLevel() - 1).ToString() 
            + "On Map " + zMapController.instance.GetIDLevel().ToString(),
            "Try To Defeat me on this game!!!", new Uri(GameInfo.URL_img),
            callback: ShareCallback);
#else
        FB.ShareLink(
            new Uri(GameInfo.Android.URL_RateApp),
            GameInfo.GameName + ", " + "Can you beat my Best Time " + zHighScoreController.instance.GetHighScore_BestTime(1,zMapController.instance.GetIDLevel() - 1).ToString() 
            + "On Map " + zMapController.instance.GetIDLevel().ToString(),
            "Try To Defeat me on this game!!!", new Uri(GameInfo.URL_img),
            callback: ShareCallback);
#endif
    }
	public void UpImage(){
		StartCoroutine (TakeScreenshot());
	}
	private IEnumerator TakeScreenshot()
	{
		yield return new WaitForEndOfFrame();

		var width = Screen.width;
		var height = Screen.height;
		var tex = new Texture2D(width, height, TextureFormat.RGB24, false);

		// Read screen contents into the texture
		tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		tex.Apply();
		byte[] screenshot = tex.EncodeToPNG();

		var wwwForm = new WWWForm();
		wwwForm.AddBinaryData("image", screenshot, "InteractiveConsole.png");
		wwwForm.AddField("message", "herp derp.  I did a thing!  Did I do this right?");
		FB.API("me/photos", HttpMethod.POST, this.HandleResult, wwwForm);
	}
	public void HandleResult(IGraphResult result){
		if (result.Error == null) {
			Debug.Log ("Error Handle");
		}
	}
	private void ShareCallback (IShareResult result) {
		
	} */
}
