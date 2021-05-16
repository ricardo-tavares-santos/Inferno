using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class zChooseMapsController : MonoBehaviour
{
    public static zChooseMapsController instance;
	
	public GameObject ButtonNoAds;
	
    public GameObject Intro;
    public GameObject Circles;
    public GameObject Levels;
    public GameObject[] btn_Circle;
    public GameObject[] Levels_Group;

    private void Start()
    {
        Application.targetFrameRate = 60;
        MakeInstance();

		int noAds = PlayerPrefs.GetInt("NoAds");
        if (noAds == 667)
        {
			ButtonNoAds.SetActive(false);
		}
		
		
        if (zMapController.instance != null)
        {
            if (!zMapController.instance.isStartIntro)
            {
                zMapController.instance.isStartIntro = true;
                Intro.SetActive(true);
            }
            else
            {
                if (AdsController.instance != null)
                {
					if (noAds == 667){} else { AdsController.instance.ShowBanner();	}					 
                }
            }
        }

        //Intro.SetActive(true);
        Circles.SetActive(true);
        Levels.SetActive(false);

    }
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
	}	

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void f_LoadCircle(int id)
    {	
        StopCoroutine(i_f_LoadCircle(id));
        StartCoroutine(i_f_LoadCircle(id));
    }

    IEnumerator i_f_LoadCircle(int id)
    {
        zMapController.instance.SetIDCircle(id);
        for (int i = 0; i < btn_Circle.Length; i++)
        {
            btn_Circle[i].GetComponent<Animator>().Play("Popup_Fall");
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.9f);
        Circles.SetActive(false);
        for (int i = 0; i < Levels_Group.Length; i++) {
            Levels_Group[i].SetActive(false);   
        }
        Levels_Group[id].SetActive(true);  
        Levels.SetActive(true);
    }

    public void f_UnLoadCircles()
    {
        StopCoroutine("i_f_UnLoadCircles");
        StartCoroutine("i_f_UnLoadCircles");
    }

    IEnumerator i_f_UnLoadCircles()
    {
        Levels.SetActive(false);
        Circles.SetActive(true);
        for (int i = 0; i < btn_Circle.Length; i++)
        {
            btn_Circle[i].GetComponent<Animator>().Play("Popup_Up");
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void f_LoadLevel(int idLevel)
    {
        zMapController.instance.SetIDLevel(idLevel);
        SceneManager.LoadScene("Loading02");
    }

    public void f_ReplayIntro()
    {
        Intro.SetActive(true);
    }

    public void f_ResetPlayerpref() {
        PlayerPrefs.DeleteAll();
    }
}
