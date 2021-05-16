using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class zLoading01Controller : MonoBehaviour {
    AsyncOperation async;
    public Slider slider; 
	void Start () {
        StartCoroutine(loadscene());
	}
    IEnumerator loadscene() {
        async = SceneManager.LoadSceneAsync("ChooseMaps");
        yield return new WaitForSeconds(1.0f);
    }
	void Update () {
        slider.value = async.progress;
	}
}
