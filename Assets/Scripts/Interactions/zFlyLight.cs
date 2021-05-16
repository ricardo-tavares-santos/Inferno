using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class zFlyLight : MonoBehaviour
{

    public GameObject flylight;
    public GameObject parent;
    List<Transform> childs;
    public float minRandomRange = 2.0f;
    public float maxRandomRange = 5.0f;
    public float speed = 1.0f;
    public float time;
    public int FirstPos;
    public int SecondPos = 1;
    public int ThirdPos = 2;
    void Awake()
    {
        getChildObjects();
    }
    void getChildObjects()
    {
        childs = new List<Transform>();
        Transform[] childs_temp = parent.GetComponentsInChildren<Transform>();
        foreach (Transform o in childs_temp)
        {
            if (o != parent.transform)
            {
                childs.Add(o);
            }
        }
        parent.SetActive(false);
    }
    private void Update()
    {
        Move();
    }
    void Move()
    {
        time += Time.deltaTime * speed;

        flylight.transform.position = ConvertToCurvePos(time, childs[FirstPos].position, childs[SecondPos].position, childs[ThirdPos].position);
        if (time > 1.0f)
        {
            time = 0.0f;
            FirstPos = checkLimitPos(FirstPos);
            SecondPos = checkLimitPos(SecondPos);
            ThirdPos = checkLimitPos(ThirdPos);
        }
    }
    int checkLimitPos(int pos)
    {
        pos += 2;
        if (pos == childs.Count)
        {
            pos = 0;
        }
        else if (pos > childs.Count)
        {
            pos = 1;
        }
        return pos;
    }
    Vector3 ConvertToCurvePos(float t, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        //(1-t)^2 * P0 + 2(1-t)tP1 + t^2*P2
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p1;
        p += 2 * t * u * p2;
        p += tt * p3;
        return p;
    }
    Vector3 randomNewPos()
    {
        return new Vector3(Random.Range(minRandomRange, maxRandomRange), Random.Range(minRandomRange, maxRandomRange), Random.Range(minRandomRange, maxRandomRange));
    }
}
