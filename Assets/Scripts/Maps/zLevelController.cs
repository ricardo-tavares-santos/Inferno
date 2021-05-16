using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zLevelController : MonoBehaviour {
    public static zLevelController instance;
    public int amountOfLevel = 15;
    public Sprite Star1;
    public Sprite Star2;
    public Sprite Star3;
    public Sprite btn_ON;
    public Sprite btn_ON_Boss;
    public Sprite btn_OFF;
    public Sprite[] circle_ON;
    public Sprite circle_OFF;
	void Awake () {
        MakeInstance();
	}
    void MakeInstance() {
        if (instance == null)
        {
            instance = this;
        }
    }
}
