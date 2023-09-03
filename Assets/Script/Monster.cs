using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{    
    public int atk;
    public int getGold;
    Animator monsterAni;

    private void Start()
    {
        monsterAni = GetComponent<Animator>();  
    }


    public int Hp
    {
        get => hp;
        set
        {
            hp = value;
            if (hp < 0) StartCoroutine(Die());
        }
    }
    private int hp = 50;

    IEnumerator Die()
    {
        monsterAni.SetTrigger("isDead");
        GameManager.Instance.Gold += getGold;
        GameManager.Instance.Score += 1;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        yield return null;
    }    

    public void Hit()
    {
        monsterAni.SetTrigger("isHit");
    }
}
