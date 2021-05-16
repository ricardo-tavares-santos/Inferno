using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScreen : MonoBehaviour {
	public string nextScreen = "HomeScreen";
	public float countTime = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		countTime -= Time.deltaTime;
		if (countTime <= 0f) {
			SceneManager.LoadScene (nextScreen);
		}
	}
}
