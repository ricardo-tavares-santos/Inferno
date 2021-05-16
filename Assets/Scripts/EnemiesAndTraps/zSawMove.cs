using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class zSawMove : MonoBehaviour
{
    public GameObject Saw;
    public GameObject parent;
    List<Transform> childs;
    public int TypeMove = 0; // 0 is straight, 1 is circle
    public float speed = 1.0f;
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
    private void OnEnable()
    {
        switch (TypeMove)
        {
            case 0:
                MoveStraight();
                break;
            case 1:
                MoveCircle();
                break;
            default:
                MoveStraight();
                break;
        }
    }
    void MoveStraight()
    {
        Sequence mySequence = DOTween.Sequence();
        Saw.transform.position = childs[0].position;
        for (int i = 1; i < childs.Count; i++)
        {
            mySequence.Append(Saw.transform.DOMove(childs[i].position, speed));
        }
        for (int i = childs.Count - 2; i >= 0; i--)
        {
            mySequence.Append(Saw.transform.DOMove(childs[i].position, speed));
        }
        mySequence.OnComplete(MoveStraight);
    }
    void MoveCircle()
    {
        Sequence mySequence = DOTween.Sequence();
        Saw.transform.position = childs[0].position;
        for (int i = 1; i < childs.Count; i++)
        {
            mySequence.Append(Saw.transform.DOMove(childs[i].position, speed));
        }
        mySequence.Append(Saw.transform.DOMove(childs[0].position, speed));
        mySequence.OnComplete(MoveCircle);
    }

}
