using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zVines : MonoBehaviour {

    LineRenderer line;
    public Transform Bottom;

	void Start () {
        line = GetComponent<LineRenderer>();
	}
	
	void Update () {
        line.SetPosition(0, Bottom.position);
        line.SetPosition(1, transform.position);
	}
}
