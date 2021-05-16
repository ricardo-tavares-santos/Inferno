using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zHypnosicBullet : MonoBehaviour {
    public Vector3 direction = Vector3.up;
    public float destroyTime = 1.0f;
    public float timeWaitForPSEnd = 1.0f; // It will equal lifetime of each particle systems emit
    public float speed = 10.0f;

    private void Start()
    {
        StartCoroutine(destroy());
    }

    void Update () {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    IEnumerator destroy() {
        yield return new WaitForSeconds(destroyTime);
        GetComponent<CircleCollider2D>().enabled = false;
        var emission = GetComponentInChildren<ParticleSystem>();
        var emit = emission.emission;
        emit.enabled = false;
        yield return new WaitForSeconds(timeWaitForPSEnd);
        Destroy(gameObject);
    }
}
