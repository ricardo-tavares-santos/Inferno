using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zBossWolf_Bullet : MonoBehaviour
{
    public Vector3 direction = Vector3.up;
    public float destroyTime = 1.0f;
    public float timeWaitForPSEnd = 1.0f; // It will equal lifetime of each particle systems emit
    public float speed = 10.0f;

    private void Start()
    {
        StartCoroutine(destroy());
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime * Time.timeScale);
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(destroyTime);
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponentInChildren<ParticleSystem>().enableEmission = false;
        yield return new WaitForSeconds(timeWaitForPSEnd);
        Destroy(gameObject);
    }

    IEnumerator destroyWhenCollision()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponentInChildren<ParticleSystem>().enableEmission = false;
        yield return new WaitForSeconds(timeWaitForPSEnd);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            StartCoroutine(destroyWhenCollision());
        }
    }
}
