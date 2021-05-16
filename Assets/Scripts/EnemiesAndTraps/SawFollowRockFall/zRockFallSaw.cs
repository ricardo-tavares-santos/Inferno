using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class zRockFallSaw : MonoBehaviour
{

    public GameObject Rock;
    public Transform Target;
    public Vector3 StartPos;
    public float delay = 0.0f;
    public float speed = 1.0f;
    public float Wait = 0.2f;
    void Start()
    {
        Target.gameObject.SetActive(false);
        StartPos = Rock.transform.position;
        StartCoroutine(OnStart(delay));
    }

    IEnumerator OnStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        Rock.transform.DOMove(Target.transform.position, speed);
        yield return new WaitForSeconds(speed + Wait);
        Rock.transform.DOMove(StartPos, speed);
        yield return new WaitForSeconds(speed + Wait);
        StartCoroutine(Attack());
    }
}
