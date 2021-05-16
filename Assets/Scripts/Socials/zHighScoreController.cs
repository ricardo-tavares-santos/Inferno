using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zHighScoreController : MonoBehaviour
{
    public static zHighScoreController instance;
    public string[] C0_BestTime = new string[5];
    public string[] C0_Deaths = new string[5];
    public string[] C1_BestTime = new string[25];
    public string[] C1_Deaths = new string[25];
//???
    public string[] C2_BestTime = new string[5];
    public string[] C2_Deaths = new string[5];
	public string[] C3_BestTime = new string[5];
    public string[] C3_Deaths = new string[5];
	public string[] C4_BestTime = new string[5];
    public string[] C4_Deaths = new string[5];
    public string[] C5_BestTime = new string[5];
    public string[] C5_Deaths = new string[5];
	public string[] C6_BestTime = new string[5];
    public string[] C6_Deaths = new string[5];
	public string[] C7_BestTime = new string[5];
    public string[] C7_Deaths = new string[5];
	public string[] C8_BestTime = new string[5];
    public string[] C8_Deaths = new string[5];
	
	
    public const string Endless_BestTime = "Endless_BestTime";
    public const string Endless_BestScore = "Endless_BestScore";

    private void Awake()
    {
        for (int i = 0; i < C0_BestTime.Length; i++)
        {
            C0_BestTime[i] = "C0_BestTime_" + i;
            C0_Deaths[i] = "C0_Deaths_" + i;
        }

        if (!PlayerPrefs.HasKey(C0_BestTime[0]))
        {
            //only need to check 1 variable because I set all variable at the same time, so if 1 variable haven't set then all variable too.
            for (int i = 0; i < C0_Deaths.Length; i++)
            {
                PlayerPrefs.SetInt(C0_Deaths[i], int.MaxValue);
                PlayerPrefs.SetInt(C0_BestTime[i], int.MaxValue);
            }
        }

        for (int i = 0; i < C1_BestTime.Length; i++)
        {
            C1_BestTime[i] = "C1_BestTime_" + i;
            C1_Deaths[i] = "C1_Deaths_" + i;
        }

        if (!PlayerPrefs.HasKey(C1_Deaths[0]))
        {
            //only need to check 1 variable because I set all variable at the same time, so if 1 variable haven't set then all variable too.
            for (int i = 0; i < C1_Deaths.Length; i++)
            {
                PlayerPrefs.SetInt(C1_Deaths[i], int.MaxValue);
                PlayerPrefs.SetInt(C1_BestTime[i], int.MaxValue);
            }
        }
		
//???		
		
        for (int i = 0; i < C1_BestTime.Length; i++)
        {
            C1_BestTime[i] = "C1_BestTime_" + i;
            C1_Deaths[i] = "C1_Deaths_" + i;
        }

        if (!PlayerPrefs.HasKey(C1_Deaths[0]))
        {
            //only need to check 1 variable because I set all variable at the same time, so if 1 variable haven't set then all variable too.
            for (int i = 0; i < C1_Deaths.Length; i++)
            {
                PlayerPrefs.SetInt(C1_Deaths[i], int.MaxValue);
                PlayerPrefs.SetInt(C1_BestTime[i], int.MaxValue);
            }
        }


        for (int i = 0; i < C2_BestTime.Length; i++)
        {
            C2_BestTime[i] = "C2_BestTime_" + i;
            C2_Deaths[i] = "C2_Deaths_" + i;
        }

        if (!PlayerPrefs.HasKey(C2_Deaths[0]))
        {
            //only need to check 1 variable because I set all variable at the same time, so if 1 variable haven't set then all variable too.
            for (int i = 0; i < C2_Deaths.Length; i++)
            {
                PlayerPrefs.SetInt(C2_Deaths[i], int.MaxValue);
                PlayerPrefs.SetInt(C2_BestTime[i], int.MaxValue);
            }
        }

        for (int i = 0; i < C3_BestTime.Length; i++)
        {
            C3_BestTime[i] = "C3_BestTime_" + i;
            C3_Deaths[i] = "C3_Deaths_" + i;
        }

        if (!PlayerPrefs.HasKey(C3_Deaths[0]))
        {
            //only need to check 1 variable because I set all variable at the same time, so if 1 variable haven't set then all variable too.
            for (int i = 0; i < C3_Deaths.Length; i++)
            {
                PlayerPrefs.SetInt(C3_Deaths[i], int.MaxValue);
                PlayerPrefs.SetInt(C3_BestTime[i], int.MaxValue);
            }
        }

        for (int i = 0; i < C4_BestTime.Length; i++)
        {
            C4_BestTime[i] = "C4_BestTime_" + i;
            C4_Deaths[i] = "C4_Deaths_" + i;
        }

        if (!PlayerPrefs.HasKey(C4_Deaths[0]))
        {
            //only need to check 1 variable because I set all variable at the same time, so if 1 variable haven't set then all variable too.
            for (int i = 0; i < C4_Deaths.Length; i++)
            {
                PlayerPrefs.SetInt(C4_Deaths[i], int.MaxValue);
                PlayerPrefs.SetInt(C4_BestTime[i], int.MaxValue);
            }
        }


        for (int i = 0; i < C5_BestTime.Length; i++)
        {
            C5_BestTime[i] = "C5_BestTime_" + i;
            C5_Deaths[i] = "C5_Deaths_" + i;
        }

        if (!PlayerPrefs.HasKey(C5_Deaths[0]))
        {
            //only need to check 1 variable because I set all variable at the same time, so if 1 variable haven't set then all variable too.
            for (int i = 0; i < C5_Deaths.Length; i++)
            {
                PlayerPrefs.SetInt(C5_Deaths[i], int.MaxValue);
                PlayerPrefs.SetInt(C5_BestTime[i], int.MaxValue);
            }
        }


        for (int i = 0; i < C6_BestTime.Length; i++)
        {
            C6_BestTime[i] = "C6_BestTime_" + i;
            C6_Deaths[i] = "C6_Deaths_" + i;
        }

        if (!PlayerPrefs.HasKey(C6_Deaths[0]))
        {
            //only need to check 1 variable because I set all variable at the same time, so if 1 variable haven't set then all variable too.
            for (int i = 0; i < C6_Deaths.Length; i++)
            {
                PlayerPrefs.SetInt(C6_Deaths[i], int.MaxValue);
                PlayerPrefs.SetInt(C6_BestTime[i], int.MaxValue);
            }
        }


        for (int i = 0; i < C7_BestTime.Length; i++)
        {
            C7_BestTime[i] = "C7_BestTime_" + i;
            C7_Deaths[i] = "C7_Deaths_" + i;
        }

        if (!PlayerPrefs.HasKey(C7_Deaths[0]))
        {
            //only need to check 1 variable because I set all variable at the same time, so if 1 variable haven't set then all variable too.
            for (int i = 0; i < C7_Deaths.Length; i++)
            {
                PlayerPrefs.SetInt(C7_Deaths[i], int.MaxValue);
                PlayerPrefs.SetInt(C7_BestTime[i], int.MaxValue);
            }
        }



        for (int i = 0; i < C8_BestTime.Length; i++)
        {
            C8_BestTime[i] = "C8_BestTime_" + i;
            C8_Deaths[i] = "C8_Deaths_" + i;
        }

        if (!PlayerPrefs.HasKey(C8_Deaths[0]))
        {
            //only need to check 1 variable because I set all variable at the same time, so if 1 variable haven't set then all variable too.
            for (int i = 0; i < C8_Deaths.Length; i++)
            {
                PlayerPrefs.SetInt(C8_Deaths[i], int.MaxValue);
                PlayerPrefs.SetInt(C8_BestTime[i], int.MaxValue);
            }
        }		
		
		
		
		
		
        if (!PlayerPrefs.HasKey(Endless_BestTime))
        {
            PlayerPrefs.SetInt(Endless_BestTime, int.MaxValue);
            PlayerPrefs.SetInt(Endless_BestScore, int.MinValue);
        }
        MakeIntance();
    }
    void MakeIntance()
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
    public int GetHighScore_BestTime(int _CircleID, int _MapID)
    {
        switch (_CircleID)
        {
            case 0:
                return PlayerPrefs.GetInt(C0_BestTime[_MapID]);
            case 1:
                return PlayerPrefs.GetInt(C1_BestTime[_MapID]);
            case 2:
                return PlayerPrefs.GetInt(C2_BestTime[_MapID]);
            case 3:
                return PlayerPrefs.GetInt(C3_BestTime[_MapID]);
            case 4:
                return PlayerPrefs.GetInt(C4_BestTime[_MapID]);
            case 5:
                return PlayerPrefs.GetInt(C5_BestTime[_MapID]);
            case 6:
                return PlayerPrefs.GetInt(C6_BestTime[_MapID]);
            case 7:
                return PlayerPrefs.GetInt(C7_BestTime[_MapID]);
            case 8:
                return PlayerPrefs.GetInt(C8_BestTime[_MapID]);				
            default:
                return PlayerPrefs.GetInt(C8_BestTime[_MapID]);
        }
    }
    public int GetHighScore_Deaths(int _CircleID, int _MapID)
    {
        switch (_CircleID)
        {
            case 0:
                return PlayerPrefs.GetInt(C0_Deaths[_MapID]);
            case 1:
                return PlayerPrefs.GetInt(C1_Deaths[_MapID]);
            case 2:
                return PlayerPrefs.GetInt(C2_Deaths[_MapID]);
            case 3:
                return PlayerPrefs.GetInt(C3_Deaths[_MapID]);
            case 4:
                return PlayerPrefs.GetInt(C4_Deaths[_MapID]);
            case 5:
                return PlayerPrefs.GetInt(C5_Deaths[_MapID]);
            case 6:
                return PlayerPrefs.GetInt(C6_Deaths[_MapID]);
            case 7:
                return PlayerPrefs.GetInt(C7_Deaths[_MapID]);
            case 8:
                return PlayerPrefs.GetInt(C8_Deaths[_MapID]);				
            default:
                return PlayerPrefs.GetInt(C8_Deaths[_MapID]);
        }
    }
    public void SetHighScore_BestTime(int _CircleID, int _MapID, int _value)
    {
        switch (_CircleID)
        {
            case 0:
                PlayerPrefs.SetInt(C0_BestTime[_MapID], _value);
                break;
            case 1:
                PlayerPrefs.SetInt(C1_BestTime[_MapID], _value);
                break;
            case 2:
                PlayerPrefs.SetInt(C2_BestTime[_MapID], _value);
                break;
            case 3:
                PlayerPrefs.SetInt(C3_BestTime[_MapID], _value);
                break;
            case 4:
                PlayerPrefs.SetInt(C4_BestTime[_MapID], _value);
                break;
            case 5:
                PlayerPrefs.SetInt(C5_BestTime[_MapID], _value);
                break;
            case 6:
                PlayerPrefs.SetInt(C6_BestTime[_MapID], _value);
                break;
            case 7:
                PlayerPrefs.SetInt(C7_BestTime[_MapID], _value);
                break;
            case 8:
                PlayerPrefs.SetInt(C8_BestTime[_MapID], _value);
                break;				
            default:
                PlayerPrefs.SetInt(C8_BestTime[_MapID], _value);
                break;
        }
    }
    public void SetHighScore_Deaths(int _CircleID, int _MapID, int _value)
    {
        switch (_CircleID)
        {
            case 0:
                PlayerPrefs.SetInt(C0_Deaths[_MapID], _value);
                break;
            case 1:
                PlayerPrefs.SetInt(C1_Deaths[_MapID], _value);
                break;
            case 2:
                PlayerPrefs.SetInt(C2_Deaths[_MapID], _value);
                break;
            case 3:
                PlayerPrefs.SetInt(C3_Deaths[_MapID], _value);
                break;
            case 4:
                PlayerPrefs.SetInt(C4_Deaths[_MapID], _value);
                break;
            case 5:
                PlayerPrefs.SetInt(C5_Deaths[_MapID], _value);
                break;
            case 6:
                PlayerPrefs.SetInt(C6_Deaths[_MapID], _value);
                break;
            case 7:
                PlayerPrefs.SetInt(C7_Deaths[_MapID], _value);
                break;
            case 8:
                PlayerPrefs.SetInt(C8_Deaths[_MapID], _value);
                break;				
            default:
                PlayerPrefs.SetInt(C8_Deaths[_MapID], _value);
                break;
        }
    }

    public int GetBestTimeOfEndless()
    {
        return PlayerPrefs.GetInt(Endless_BestTime);
    }
    public void SetBestTimeOfEndless(int _value)
    {
        PlayerPrefs.SetInt(Endless_BestTime, _value);
    }

    public int GetBestScoreOfEndless()
    {
        return PlayerPrefs.GetInt(Endless_BestScore);
    }
    public void SetBestScoreOfEndless(int _value)
    {
        PlayerPrefs.SetInt(Endless_BestScore, _value);
    }
}
