using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zBossTornado_Attack2 : MonoBehaviour
{
    public float timeCountDownToDestroy = 5.0f;
    public float speed = 2.5f;
    public Vector3 direction;
    Transform target;
    float timeCountDownToDestroy_Temp;
    void Start()
    {
        target = zPlayer.instance.transform;
        timeCountDownToDestroy_Temp = timeCountDownToDestroy;
        direction = direction.normalized;
    }
    private void Update()
    {
        direction = target.position - transform.position;
        transform.Translate(direction.normalized * Time.timeScale * Time.deltaTime * speed);
        timeCountDownToDestroy -= Time.deltaTime;
        if (timeCountDownToDestroy < 0.0f)
        {
            Destroy(gameObject);
        }
    }
    void RotateDirection() { 
        //direction 
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
