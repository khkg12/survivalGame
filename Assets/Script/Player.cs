using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float MoveSpeed
    {
        get => moveSpeed;
        set
        {            
            moveSpeed = value;
        }
    }
    private float moveSpeed = 0.02f;

    public int Atk
    {
        get => atk;
        set
        {
            atk = value;
        }
    }
    private int atk = 10;

    public int Hp
    {
        get => hp;
        set
        {                        
            hp = value;
            GameManager.Instance.hpText.text = $"Hp : {hp}";            
            if (hp <= 0)
            {                
                Die();
            }
        }
    }
    private int hp = 100;
    
    public int JetKaraGage
    {
        get => jetKaraGage;
        set
        {
            jetKaraGage = value;                
            if (jetKaraGage >= 10)
            {
                jetKaraGage = 10;
            }
            GameManager.Instance.jetKaraGageText.text = $"JETKARA GAGE : {jetKaraGage}";
        }
    }
    private int jetKaraGage;

    public GameObject jetKaraBullet;
    Animator playerAni;    
    bool isAttack = false;
    bool isZetKaraAttack = false;
    Collider sword;

    private void Start()
    {
        playerAni = GetComponent<Animator>();
        sword = transform.GetChild(1).gameObject.GetComponent<Collider>();        
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && isAttack == false)
        {            
            StartCoroutine(Attack());
        }

        if (Input.GetMouseButtonDown(1) && isZetKaraAttack == false)
        {
            if(jetKaraGage < 10)
            {

                Debug.Log("제트카라게이지가 부족합니다 현재 게이지" + jetKaraGage);
            }
            else
            {
                jetKaraGage = 0;
                GameManager.Instance.jetKaraGageText.text = $"JETKARA GAGE : {jetKaraGage}";
                StartCoroutine(ZetKaraAttack());                
            }            
        }

    }    


    public IEnumerator Attack()
    {
        isAttack = true;
        sword.enabled = true;
        playerAni.SetTrigger("isAttack");
        yield return new WaitForSeconds(1.8f);
        sword.enabled = false;
        isAttack = false;
    }

    public IEnumerator ZetKaraAttack()
    {
        isZetKaraAttack = true;        
        Instantiate(jetKaraBullet, transform.position, Quaternion.identity); 
        yield return new WaitForSeconds(1f);        
        isZetKaraAttack = false;
    }    

    public void Die()
    {
        SceneManager.LoadScene("DeadScene");
    }
    
    

    private void OnCollisionEnter(Collision collision)
    {
        Monster monster;
        if(collision.gameObject.TryGetComponent<Monster>(out monster))
        {
            Hp -= monster.atk;            
        }
    }
}
