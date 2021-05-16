using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zDoor : MonoBehaviour {

    public bool isLock = true;
    public GameObject prefab_PS_Disappear;
    public AudioClip InteractionSoundEffect;
    private void Start()
    {
        if (zSoundController.instance != null)
        {
            InteractionSoundEffect = zSoundController.instance.ISE_Door;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            if (isLock)
            {
                zUIGroupController.instance.f_ShowMessage("Find the Key to open this door!");
            }
            else {
                zUIGroupController.instance.f_ShowMessage("Good Job!!!");
                AudioSource.PlayClipAtPoint(InteractionSoundEffect, transform.position);
                Instantiate(prefab_PS_Disappear, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
