using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zOcclusion2D : MonoBehaviour {

    public GameObject content;

	void Start () {
        content.SetActive(false);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ocllusion2D")) {
            content.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ocllusion2D"))
        {
            content.SetActive(false);
        }
    }
}
