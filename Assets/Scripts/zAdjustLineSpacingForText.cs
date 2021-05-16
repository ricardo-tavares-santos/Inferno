using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zAdjustLineSpacingForText : MonoBehaviour {
    Text text;
    public float lineSpacing = 1.0f;
	void Start () {
        text = GetComponent<Text>();
        text.lineSpacing = lineSpacing;
	}
	
}
