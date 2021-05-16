using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class zRockFall : MonoBehaviour {
    public GameObject Rock;
    public Transform Target;
    //public GameObject DestroyArea;
    public Vector3 TempPos;
    public float delay = 0.0f;
    public float speed = 1.0f;
    public float Wait = 0.2f;
	void Awake () {
        Target.gameObject.SetActive(false);
        //DestroyArea.gameObject.SetActive(false);
        TempPos = Rock.transform.position;

	}
    private void OnEnable()
    {
        Rock.transform.position = TempPos;
        StartCoroutine(OnStart(delay));
    }
    IEnumerator OnStart(float delay) {
        yield return new WaitForSeconds(delay);
        StartCoroutine(Attack());
    }
    IEnumerator Attack() {
        Rock.transform.DOMove(Target.transform.position, speed);
        yield return new WaitForSeconds(speed);
        //DestroyArea.SetActive(true);
        yield return new WaitForSeconds(Wait);
        //DestroyArea.SetActive(false);
        Rock.transform.DOMove(TempPos, speed);
        yield return new WaitForSeconds(speed + Wait);
        StartCoroutine(Attack());
    }
}
