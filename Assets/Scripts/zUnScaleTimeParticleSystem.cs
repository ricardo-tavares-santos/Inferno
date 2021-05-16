using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zUnScaleTimeParticleSystem : MonoBehaviour {
    ParticleSystem explosion;
	// Use this for initialization
	void Start () {
        explosion = GetComponent<ParticleSystem>();
	}
	
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale < 0.01f)
        {
            explosion.Simulate(Time.unscaledDeltaTime, true, false);
            //particleSystem.Simulate(Time.unscaledDeltaTime, true, false);
        }
    }
}
