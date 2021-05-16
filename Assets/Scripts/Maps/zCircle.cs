using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zCircle : MonoBehaviour
{
    public int circleID;

	public Sprite circle_ON;
    public Sprite circle_OFF;
	
    void OnEnable()
    {	
//Debug.Log("-circleID--------------------->"+circleID);	
		
        //if (circleID <= zMapController.instance.GetCircle_Unlock())
		if (circleID <= PlayerPrefs.GetInt("Circle_Unlock"))	
        {
            //GetComponent<Image>().sprite = zLevelController.instance.circle_ON[circleID];
			GetComponent<Image>().sprite = circle_ON;
            GetComponent<Button>().enabled = true;
        }
        else
        {		
            //GetComponent<Image>().sprite = zLevelController.instance.circle_OFF;		
			GetComponent<Image>().sprite = circle_OFF;
            GetComponent<Button>().enabled = false;				
        }

	}
}
