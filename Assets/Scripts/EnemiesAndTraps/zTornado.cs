using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zTornado : MonoBehaviour {

    public float timeCountDown = 1.0f;

    float direction;

	void Start () {
        direction = transform.localScale.x / Mathf.Abs(transform.localScale.x);
        StartCoroutine(KillItSelf());
	}
    IEnumerator KillItSelf() {
        yield return new WaitForSeconds(timeCountDown);
        Destroy(gameObject);
    }
    private void Update()
    {
        transform.Translate(Vector3.right * 0.4f * direction);
    }

}
