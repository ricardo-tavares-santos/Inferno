using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zLevel : MonoBehaviour
{
    public int circleID;
    public int levelID;
    public Image[] spriteStar;
    public int temp;

    void OnEnable()
    {
        spriteStar = GetComponentsInChildren<Image>();
        circleID = zMapController.instance.GetIDCircle();
        if (levelID < zMapController.instance.GetLevel_Unlock(circleID))
        {
            SetStar(levelID);
        }
        if (levelID < zMapController.instance.GetLevel_Unlock(circleID) + 1)
        {
            //if (circleID > 0 && (levelID == 4 || levelID == 9 || levelID == 14))
			if (  (circleID == 2 &&	levelID == 1) || (circleID == 4 &&	levelID == 0) || (circleID == 5 &&	levelID == 2) || (circleID == 7 &&	levelID == 0) )
            {
                GetComponent<Image>().sprite = zLevelController.instance.btn_ON_Boss;
            }
            else
            {
                GetComponent<Image>().sprite = zLevelController.instance.btn_ON;
            }
            GetComponent<Button>().enabled = true;
        }
        else
        {
            GetComponent<Image>().sprite = zLevelController.instance.btn_OFF;
            GetComponent<Button>().enabled = false;
        }
    }

    void SetStar(int _levelID)
    {
        //Only call this function for those levels which were unlocked
        int starcount = 1;
        if (zHighScoreController.instance != null)
        {
            if (zHighScoreController.instance.GetHighScore_Deaths(circleID, _levelID) <= (_levelID + 1))
            {
                starcount++;
            }
            if (zHighScoreController.instance.GetHighScore_BestTime(circleID, _levelID) <= 60 * 2 + 20 * (_levelID + 1))
            {
                starcount++;
            }
        }

        switch (starcount)
        {
            case 1:
                spriteStar[1].sprite = zLevelController.instance.Star1;
                break;
            case 2:
                spriteStar[1].sprite = zLevelController.instance.Star2;
                break;
            case 3:
                spriteStar[1].sprite = zLevelController.instance.Star3;
                break;
            default:
                spriteStar[1].sprite = zLevelController.instance.Star1;
                break;
        }
    }
}
