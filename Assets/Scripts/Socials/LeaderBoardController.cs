using UnityEngine;

#if UNITY_ANDROID
//using GooglePlayGames;
//using GooglePlayGames.BasicApi;
#endif

public class LeaderBoardController : MonoBehaviour
{/*
    public static LeaderBoardController instance;
    public static readonly string[] C0_leaderboard_Deaths = GameInfo.C0_leaderboard_Deaths;
    public static readonly string[] C0_leaderboard_BestTime = GameInfo.C0_leaderboard_BestTime;
    public static readonly string[] C1_leaderboard_Deaths = GameInfo.C1_leaderboard_Deaths;
    public static readonly string[] C1_leaderboard_BestTime = GameInfo.C1_leaderboard_BestTime;

    void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
#if UNITY_ANDROID
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();

        //LoginGameCenter();
#else
        LoginGameCenter();
#endif
    }

    //Open Leaderboard UI
    public void OpenLeaderboards()
    {
        Debug.Log("Try to call OpenLeaderboards function");
        if (Social.localUser.authenticated)
        {
            Debug.Log("authenticated == true, show leaderboard UI");
            Social.ShowLeaderboardUI();
        }
        else
        {
            Debug.Log("authenticated == false, goi ham login");
            LoginGameCenter();
        }
    }

    //Open Achievements UI
    public void OpenAchivements()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
    }

    //Method to login GameCenter with current user
    public void LoginGameCenter()
    {
        //Check if does not has account login before
        if (!Social.localUser.authenticated)
        {
            //Start login
            Social.localUser.Authenticate((bool success) =>
                {
                    if (success)
                    {
                        Debug.Log("Login thanh cong nha cu");
                    }
                    else
                    {
                        Debug.Log("Can not login. Please input your account to game center.");
                    }
                });
        }
    }

    //Report score to leaderboard
    public void ReportScore_BestTime(int _circleID, int _mapID, int _time)
    {
        if (Social.localUser.authenticated)
        {
#if UNITY_IOS
            switch (_circleID)
            {
                case 0:
                    //IOS submit time dang second
                    Social.ReportScore(_time, C0_leaderboard_BestTime[_mapID], (bool success) =>
                    {
                        if (success)
                        {
                            Debug.Log("Changed HighScore of Best Time");
                        }
                    });
                    break;
                case 1:
                    //IOS submit time dang second
                    Social.ReportScore(_time, C1_leaderboard_BestTime[_mapID], (bool success) =>
                    {
                        if (success)
                        {
                            Debug.Log("Changed HighScore of Best Time");
                        }
                    });
                    break;
            }
#else
            //Android submit time dang milisecond
            switch (_circleID)
            {
                case 0:
                    //IOS submit time dang second
                    Social.ReportScore(_time * 1000, C0_leaderboard_BestTime[_mapID], (bool success) =>
                    {
                        if (success)
                        {
                            Debug.Log("Changed HighScore of Best Time");
                        }
                    });
                    break;
                case 1:
                    //IOS submit time dang second
                    Social.ReportScore(_time * 1000, C1_leaderboard_BestTime[_mapID], (bool success) =>
                    {
                        if (success)
                        {
                            Debug.Log("Changed HighScore of Best Time");
                        }
                    });
                    break;
            }
#endif
        }
    }

    public void ReportScore_Deaths(int _circleID, int _mapID, int _deaths)
    {
        if (Social.localUser.authenticated)
        {
            switch (_circleID)
            {
                case 0:
                    Social.ReportScore(_deaths, C0_leaderboard_Deaths[_mapID], (bool success) =>
                    {
                        if (success)
                        {
                            Debug.Log("Changed HighScore of Deaths");
                        }
                    });
                    break;
                case 1:
                    Social.ReportScore(_deaths, C1_leaderboard_Deaths[_mapID], (bool success) =>
                    {
                        if (success)
                        {
                            Debug.Log("Changed HighScore of Deaths");
                        }
                    });
                    break;
            }
        }
    }
*/
}