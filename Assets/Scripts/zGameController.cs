using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class zGameController : MonoBehaviour
{
    public static zGameController instance;
    // Use this for initialization
    private void Awake()
    {
        Application.targetFrameRate = 60;
        for (int i = 8; i <= 11; i++)
        {
            for (int j = i; j <= 11; j++)
            {
                Physics2D.IgnoreLayerCollision(i, j);
            }
        }
    }
    void Start()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void f_BackToMenu()
    {
        SceneManager.LoadScene("ChooseMaps");
    }

    public void f_NextLevel()
    {
        if (zMapController.instance != null)
        {
            zMapController.instance.IncreaseIDLevel();
            SceneManager.LoadScene("Loading02");
        }
    }

    public void f_Win()
    {
        //Unlock next map
        if (zMapController.instance != null)
        {
            zMapController.instance.SetLevel_Unclock_NextMap(zMapController.instance.GetIDCircle());
        }

        //Setup star
        zUIGroupController.instance.SetStar();

        //show up winpanel
        zUIGroupController.instance.f_WinPanel_TurnOn();

        //Check and change Highscore and report leaderboard if highscore change
        if (zMapController.instance != null)
        {
            int _circleID = zMapController.instance.GetIDCircle();
            int _mapID = zMapController.instance.GetIDLevel();
            if (zUIGroupController.instance.second < zHighScoreController.instance.GetHighScore_BestTime(_circleID, _mapID))
            {
                zHighScoreController.instance.SetHighScore_BestTime(_circleID, _mapID, (int)zUIGroupController.instance.second);
                //LeaderBoardController.instance.ReportScore_BestTime(_circleID,_mapID, (int)zUIGroupController.instance.second);
            }
            if (zPlayer.instance.deathCount < zHighScoreController.instance.GetHighScore_Deaths(_circleID, _mapID))
            {
                zHighScoreController.instance.SetHighScore_Deaths(_circleID, _mapID, zPlayer.instance.deathCount);
                //LeaderBoardController.instance.ReportScore_Deaths(_circleID,_mapID, zPlayer.instance.deathCount);
            }
        }
    }

    public void f_OpenBossWarning() {
        zUIGroupController.instance.f_BossWarningPanel_TurnOn();
    }

    public void f_BossWarning_Ready() { 
        SceneManager.LoadScene("Loading03");
    }

    public void f_NextCircle()
    {
        if (zMapController.instance != null)
        {
            zMapController.instance.IncreaseIDCircle();
            SceneManager.LoadScene("Loading02");
        }
    }

    public void f_WinToNextCircle()
    {
        //Unlock next map
        if (zMapController.instance != null)
        {
            zMapController.instance.SetLevel_Unclock_NextMap(zMapController.instance.GetIDCircle());
        }

        //Setup star
        Debug.Log("f_WinToNextCircle");

        zUIGroupController.instance.SetStar();

        if (zMapController.instance != null)
        {
            zMapController.instance.SetCircle_Unclock_NextCircle();
        }

        //show up winpanel
        zUIGroupController.instance.f_WinPanelToNextCircle_TurnOn();

        //Check and change Highscore and report leaderboard if highscore change
        if (zMapController.instance != null)
        {
            int _circleID = zMapController.instance.GetIDCircle();
            int _mapID = zMapController.instance.GetIDLevel();
            if (zUIGroupController.instance.second < zHighScoreController.instance.GetHighScore_BestTime(_circleID, _mapID))
            {
                zHighScoreController.instance.SetHighScore_BestTime(_circleID, _mapID, (int)zUIGroupController.instance.second);
                //LeaderBoardController.instance.ReportScore_BestTime(_circleID, _mapID, (int)zUIGroupController.instance.second);
            }
            if (zPlayer.instance.deathCount < zHighScoreController.instance.GetHighScore_Deaths(_circleID, _mapID))
            {
                zHighScoreController.instance.SetHighScore_Deaths(_circleID, _mapID, zPlayer.instance.deathCount);
                //LeaderBoardController.instance.ReportScore_Deaths(_circleID, _mapID, zPlayer.instance.deathCount);
            }
        }
    }
}
