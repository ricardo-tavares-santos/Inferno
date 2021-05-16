using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zLookPlayerArea : MonoBehaviour
{
    public Transform Head;
    bool PlayerIsON;
    public float ModifyRotatationX = -90.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!PlayerIsON)
            {
                PlayerIsON = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (PlayerIsON)
            {
                PlayerIsON = false;
            }
        }
    }
    private void Update()
    {
        if (PlayerIsON)
        {
            Vector3 dir = zPlayer.instance.transform.position - Head.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Head.transform.rotation = Quaternion.AngleAxis(angle + ModifyRotatationX, Vector3.forward);
        }
    }
}
