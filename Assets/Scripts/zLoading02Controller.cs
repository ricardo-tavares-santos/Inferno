using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class zLoading02Controller : MonoBehaviour {
    AsyncOperation async;
    public Slider slider; 
	void Start () {
        AdsController.instance.HideBanner();
        StartCoroutine(loadscene());
	}
    IEnumerator loadscene() {
        async = SceneManager.LoadSceneAsync(zMapController.instance.GetIDCircle().ToString() + "_" + zMapController.instance.GetIDLevel().ToString());
        yield return new WaitForSeconds(1.0f);
    }
	void Update () {
        slider.value = async.progress;
	}
}
