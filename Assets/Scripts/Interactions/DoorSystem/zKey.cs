using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zKey : MonoBehaviour {
    public zDoor door;
    public GameObject prefab_PS_Disappear;
    public AudioClip InteractionSoundEffect;
    private void Start()
    {
        if (zSoundController.instance != null)
        {
            InteractionSoundEffect = zSoundController.instance.ISE_Key;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            zUIGroupController.instance.f_ShowMessage("Return to the door.");
            door.isLock = false;
            AudioSource.PlayClipAtPoint(InteractionSoundEffect, transform.position);
            Instantiate(prefab_PS_Disappear, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
