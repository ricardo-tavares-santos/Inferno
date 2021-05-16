using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zMapController : MonoBehaviour
{
    public static zMapController instance;
    const string Circle_Unlock = "Circle_Unlock";
    readonly string[] Map_Unlock = { "C0_Map_Unlock","C1_Map_Unlock","C2_Map_Unlock","C3_Map_Unlock","C4_Map_Unlock","C5_Map_Unlock","C6_Map_Unlock","C7_Map_Unlock","C8_Map_Unlock" };
    public readonly int[] TotalOfMaps = { 5, 3, 3, 4, 3, 4, 4, 2, 4 };
    public int IDCircleChoose;
    public int IDLevelChoose;
    public bool isStartIntro;
    void Awake()
    {
        MakeInstance();
        if (!PlayerPrefs.HasKey(Circle_Unlock))
        {
            PlayerPrefs.SetInt(Circle_Unlock, 0);
        }
		
        if (!PlayerPrefs.HasKey(Map_Unlock[0]))
        {
            PlayerPrefs.SetInt(Map_Unlock[0], 0);
        }
        if (!PlayerPrefs.HasKey(Map_Unlock[1]))
        {
            PlayerPrefs.SetInt(Map_Unlock[1], 0);
        }
		
		//???

        if (!PlayerPrefs.HasKey(Map_Unlock[2]))
        {
            PlayerPrefs.SetInt(Map_Unlock[2], 0);
        }
        if (!PlayerPrefs.HasKey(Map_Unlock[3]))
        {
            PlayerPrefs.SetInt(Map_Unlock[3], 0);
        }
        if (!PlayerPrefs.HasKey(Map_Unlock[4]))
        {
            PlayerPrefs.SetInt(Map_Unlock[4], 0);
        }
        if (!PlayerPrefs.HasKey(Map_Unlock[5]))
        {
            PlayerPrefs.SetInt(Map_Unlock[5], 0);
        }
        if (!PlayerPrefs.HasKey(Map_Unlock[6]))
        {
            PlayerPrefs.SetInt(Map_Unlock[6], 0);
        }
        if (!PlayerPrefs.HasKey(Map_Unlock[7]))
        {
            PlayerPrefs.SetInt(Map_Unlock[7], 0);
        }
        if (!PlayerPrefs.HasKey(Map_Unlock[8]))
        {
            PlayerPrefs.SetInt(Map_Unlock[8], 0);
        }		
		
		
		
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
			
        }
    }
    public int GetLevel_Unlock(int _CircleID)
    {
        return PlayerPrefs.GetInt(Map_Unlock[_CircleID]);
    }
    public void SetLevel_Unclock_NextMap(int _CircleID)
    {
        if (IDLevelChoose <= TotalOfMaps[IDCircleChoose] && IDLevelChoose == GetLevel_Unlock(IDCircleChoose))
        {
            PlayerPrefs.SetInt(Map_Unlock[_CircleID], IDLevelChoose + 1);
        }
    }
    public int GetCircle_Unlock()
    {
//???--------------------------------------------------------------------------------------------------
//return 8;
		
       return PlayerPrefs.GetInt(Circle_Unlock);
    }
    public void SetCircle_Unclock_NextCircle()
    {
        if (IDCircleChoose <= 8)
        {
            PlayerPrefs.SetInt(Circle_Unlock, IDCircleChoose + 1);
        }
    }
    public int GetIDCircle()
    {
        return IDCircleChoose;
    }
    public void SetIDCircle(int _id)
    {
        IDCircleChoose = _id;
    }
    public int IncreaseIDCircle()
    {
        IDLevelChoose = 0;
        return ++IDCircleChoose;
    }
    public int GetIDLevel()
    {
        return IDLevelChoose;
    }
    public void SetIDLevel(int _id)
    {
        IDLevelChoose = _id;
    }
    public int IncreaseIDLevel()
    {
        return ++IDLevelChoose;
    }
    public bool isTheLastLevel(int _CircleID)
    {
        if (IDLevelChoose == TotalOfMaps[_CircleID] - 1)
        {
            return true;
        }
        return false;
    }
    public bool isTheLastCircle()
    {
        if (IDCircleChoose == 8)
        {
            return true;
        }
        return false;
    }
}
