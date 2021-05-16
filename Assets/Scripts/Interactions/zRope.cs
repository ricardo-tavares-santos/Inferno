using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zRope : MonoBehaviour
{
    public List<Transform> pos;
    public LineRenderer line;
    public GameObject prefab_Rope;
    public GameObject LastRope;
    public Rigidbody2D previous_Rigid;
    public float distanceBetweenDot = 0.15f;
    public float distance;
    public int AmountOfRope;


    void Start()
    {
        distance = Vector2.Distance(transform.position, LastRope.transform.position);

        AmountOfRope = Mathf.RoundToInt(distance / distanceBetweenDot);

        line = GetComponent<LineRenderer>();

        line.useWorldSpace = true;

        line.positionCount = AmountOfRope + 2;

        previous_Rigid = GetComponent<Rigidbody2D>();

        for (int i = 0; i < AmountOfRope; i++)
        {
            GameObject o = Instantiate(prefab_Rope, transform.position - new Vector3(0.0f, distanceBetweenDot, 0.0f) * (i + 1), Quaternion.identity, transform) as GameObject;
            SetupDot(o);
        }
        LastRope.transform.position = transform.position - new Vector3(0.0f, distanceBetweenDot, 0.0f) * (AmountOfRope + 0.5f);
        SetupDot(LastRope);

        line.SetPosition(0, transform.position);
    }
    void SetupDot(GameObject o)
    {
        o.GetComponent<DistanceJoint2D>().connectedBody = previous_Rigid;
        o.GetComponent<DistanceJoint2D>().distance = distanceBetweenDot;
        previous_Rigid = o.GetComponent<Rigidbody2D>();
        pos.Add(o.transform);
    }
    void Update()
    {
        for (int i = 0; i < pos.Count; i++)
        {
            line.SetPosition(i + 1, pos[i].position);
        }
    }
}
