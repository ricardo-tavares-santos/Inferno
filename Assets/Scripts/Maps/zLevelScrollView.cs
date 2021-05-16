using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class zLevelScrollView : MonoBehaviour {
    public ScrollRect scrollRect;
    public GameObject buttonRight;
    public GameObject buttonLeft;
    public bool isRight;
    public bool isLeft;
    public float speedScroll = 5.0f;
    //public float count;
    //float countTemp;
    private void Start()
    {
        //countTemp = count;
        SetUpButton();
    }
    private void Update()
    {
        if (isRight)
        {
            buttonRight.SetActive(false);
            //count = countTemp;
            if (scrollRect.horizontalNormalizedPosition < 1.1f)
            {
                scrollRect.horizontalNormalizedPosition += Time.deltaTime * speedScroll;
            }
            else
            {
                isRight = false;
            }
        }
        else if (isLeft)
        {
            buttonLeft.SetActive(false);
            //count = countTemp;
            if (scrollRect.horizontalNormalizedPosition > -0.1f)
            {
                scrollRect.horizontalNormalizedPosition -= Time.deltaTime * speedScroll;
            }
            else
            {
                isLeft = false;
            }
        }
        //else
        //{
        //    if (count > 0)
        //    {
        //        count -= Time.deltaTime;
        //    }
        //    else { 
        //        if (scrollRect.horizontalNormalizedPosition < 0.5f)
        //        {
        //            buttonRight.SetActive(true);
        //            buttonLeft.SetActive(false);
        //        }else if (scrollRect.horizontalNormalizedPosition > 0.5f)
        //        {
        //            buttonRight.SetActive(false);
        //            buttonLeft.SetActive(true);
        //        }
        //    }
        //}
    }
    public void SetUpButton() { 
        if (scrollRect.horizontalNormalizedPosition < 0.5f)
        {
            buttonRight.SetActive(true);
            buttonLeft.SetActive(false);
        }
        else if (scrollRect.horizontalNormalizedPosition > 0.5f)
        {
            buttonRight.SetActive(false);
            buttonLeft.SetActive(true);
        }
    }
    public void f_MoveScrollRectToRight2()
    {
        scrollRect.horizontalNormalizedPosition = 1;
    }
    public void f_MoveScrollRectToLeft2()
    {
        scrollRect.horizontalNormalizedPosition = 0;
    }
    public void f_MoveScrollRectToRight() {
        isRight = true;
    }
    public void f_MoveScrollRectToLeft()
    {
        isLeft = true;
    }
}
