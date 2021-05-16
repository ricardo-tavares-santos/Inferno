using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class zLoading03Controller : MonoBehaviour {
    AsyncOperation async;
    public Slider slider; 
	void Start () {
        AdsController.instance.HideBanner();
        StartCoroutine(loadscene());
	}
    IEnumerator loadscene() {
        string sceneName = "Boss_" + zMapController.instance.GetIDCircle().ToString() + "_" + zMapController.instance.GetIDLevel().ToString();
        Debug.Log(sceneName);

        async = SceneManager.LoadSceneAsync(sceneName);
        yield return new WaitForSeconds(1.0f);
    }
	void Update () {
        slider.value = async.progress;
	}
}
