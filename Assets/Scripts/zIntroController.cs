using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zIntroController : MonoBehaviour
{
    public GameObject Pic01;
    public GameObject Pic02;
    public GameObject Pic03;
    public GameObject Pic04;
    public GameObject Pic05;
    public GameObject btn_Replay;
    public GameObject btn_Skip;
    public Text message;
    void Start()
    {
        message.lineSpacing = 2.5f;
        float resolution = (float)Screen.height / (float)Screen.width;
        if (resolution > 0.7f && resolution < 0.8f)
        {
            message.transform.localPosition += new Vector3(0.0f, 185.0f, 0.0f);
        }
    }
    private void OnEnable()
    {
        StartCoroutine("i_Intro");
    }
    IEnumerator i_Intro()
    {
        //Ready
        Pic01.SetActive(false);
        Pic02.SetActive(false);
        Pic03.SetActive(false);
        Pic04.SetActive(false);
        Pic05.SetActive(false);
        btn_Replay.SetActive(false);
        //Endready

        Pic01.SetActive(true);
        message.text = "In the darkness there is the old book, no one knows how long its been there.";
        yield return new WaitForSeconds(4.0f);
        Pic02.SetActive(true);
        message.text = "Its name was Inferno by Dante, and someone has picked it up.";
        yield return new WaitForSeconds(4.0f);
        Pic03.SetActive(true);
        message.text = "Its a young and curious boy, he open it.";
        yield return new WaitForSeconds(4.0f);
        Pic04.SetActive(true);
        message.text = "Suddenly He gets sucked into the mystery tornado from the book";
        yield return new WaitForSeconds(4.0f);
        Pic05.SetActive(true);
        message.text = "His soul being captured to the mystery world.";
        yield return new WaitForSeconds(4.0f);
        message.text = "He must finish 9 circles of Hell to get back to his world.";
        btn_Replay.SetActive(true);
        yield return new WaitForSeconds(8.0f);
        gameObject.SetActive(false);
    }
    public void f_Skip()
    {
        StopCoroutine("i_Intro");
        gameObject.SetActive(false);
    }
    public void f_Replay()
    {
        StopCoroutine("i_Intro");
        StartCoroutine("i_Intro");
    }
}
