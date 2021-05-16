using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zCloud : MonoBehaviour {
    public float direction = -1.0f;
    public float speed = 0.1f;
	void Update () {
        transform.Translate(Vector3.right * speed * direction);
	}
}
