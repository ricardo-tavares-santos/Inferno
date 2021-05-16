using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class zDoubleRockFall : MonoBehaviour {
    public GameObject Top;
    public GameObject Bot;
    public Transform TopTarget;
    public Transform BotTarget;
    public Vector3 Top_TempPos;
    public Vector3 Bot_TempPos;
    public float speed = 1.0f;
    public float Wait = 0.2f;
    void Awake () {
        TopTarget.gameObject.SetActive(false);
        BotTarget.gameObject.SetActive(false);
        Top_TempPos = Top.transform.position;
        Bot_TempPos = Bot.transform.position;
	}
    private void OnEnable()
    {
        Top.transform.position = Top_TempPos;
        Bot.transform.position = Bot_TempPos;
        StartCoroutine(Attack());
    }
    IEnumerator Attack() {
        Top.transform.DOMove(TopTarget.transform.position, speed);
        Bot.transform.DOMove(BotTarget.transform.position, speed);
        yield return new WaitForSeconds(speed);
        yield return new WaitForSeconds(Wait);
        Top.transform.DOMove(Top_TempPos, speed);
        Bot.transform.DOMove(Bot_TempPos, speed);
        yield return new WaitForSeconds(speed + Wait);
        StartCoroutine(Attack());
    }
}
