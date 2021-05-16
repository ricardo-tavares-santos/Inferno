using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zBossTornado_Attack1 : MonoBehaviour
{
    public float timeCountDownToDestroy = 5.0f;
    public float speed = 2.5f;
    public Vector3 direction;

    float timeCountDownToDestroy_Temp;
    void Start()
    {
        timeCountDownToDestroy_Temp = timeCountDownToDestroy;
        direction = direction.normalized;
    }
    private void Update()
    {
        transform.Translate(direction * Time.timeScale * Time.deltaTime * speed);
        timeCountDownToDestroy -= Time.deltaTime;
        if (timeCountDownToDestroy < 0.0f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TornadoBounce"))
        {
            tag = "Enemy";
            timeCountDownToDestroy = timeCountDownToDestroy_Temp;
            direction = Vector3.Reflect(direction, (transform.position - collision.transform.position).normalized);
        }
        if (collision.CompareTag("Boss"))
        {
            if (gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }
    }
}
