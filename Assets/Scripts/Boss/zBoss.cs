using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class zBoss : MonoBehaviour
{
    public static zBoss instance;
    public bool isAttack;
    public int HP = 6;
    public float timeFill1HP = 0.1f;
    public float timeBossDoesntHurt = 1.0f;
    public GameObject parentHP;
    public Transform mCamera;
    public List<Animator> childsHP;

    [HideInInspector]
    public int maxHP;

    public delegate void Hurt(bool value);
    public Hurt hurt;
    public delegate void Dead(bool value);
    public Dead dead;

    private void Awake()
    {
        mCamera = Camera.main.transform;
        maxHP = HP;
        getChildObjects_HPBar();
        MakeInstance();
    }

    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void getChildObjects_HPBar()
    {
        childsHP = new List<Animator>();
        Animator[] childs_temp = parentHP.GetComponentsInChildren<Animator>();
        foreach (Animator o in childs_temp)
        {
            childsHP.Add(o);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (!isAttack)
            {
                StartCoroutine(HP_Lost());
            }
        }
    }

    IEnumerator HP_Lost()
    {
        isAttack = true;
        HP--;
        int count = 0;
        for (int i = childsHP.Count - 1; i >= 0; i--)
        {
            if (!childsHP[i].GetBool("Lost"))
            {
                childsHP[i].SetBool("Lost", true);
                count++;
                if (count == 2)
                {
                    break;
                }
                yield return new WaitForSeconds(0.1f);
            }
        }

        if (HP == 0)
        {
            Debug.Log("Win");
            dead(true);
        }
        else
        {
            //call hurt animation from each of boss class
            Debug.Log("Hurt");
            hurt(true);
            yield return new WaitForSeconds(timeBossDoesntHurt);
            isAttack = false;
        }
    }

    public void CallIEnumratorHPFillUp()
    {
        StartCoroutine(HPFillUp());
    }

    IEnumerator HPFillUp()
    {
        for (int i = 0; i < childsHP.Count; i++)
        {
            childsHP[i].Play("HP_Fill");
            yield return new WaitForSeconds(timeFill1HP);
        }
        yield return new WaitForSeconds(timeFill1HP);
    }
}
