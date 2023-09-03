using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetKaraBullet : MonoBehaviour
{
    Transform playerTransform;
    private void Start()
    {
        transform.rotation = playerTransform.rotation;
    }
    void Update()
    {        
        transform.Translate(Vector3.forward * 0.05f);
        Invoke("Disappear", 5f);
    }

    public void Disappear()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Monster monster;
        if(other.gameObject.TryGetComponent<Monster>(out monster))
        {
            Debug.Log("�浹�� ������");
            monster.Hit();
            monster.Hp -= GameManager.Instance.player.Atk * 3; // 3���� ������
        }
    }

    private void OnEnable()
    {
        playerTransform = GameManager.Instance.player.transform;
    }
}
