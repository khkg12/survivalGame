using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class MonsterController : MonoBehaviour
{    
    private Rigidbody target;
    [SerializeField]
    private float moveSpeed;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameManager.Instance.player.GetComponent<Rigidbody>(); // �����տ��� ������Ʈ�� �����ü������Ƿ� gm�� �÷��̾� ������Ʈ �̸������ص�
    }
    
    void Update()
    {                
        MoveToTarget();
    }

    public void MoveToTarget()
    {
        Vector3 dir = new Vector3(target.position.x, rb.position.y, target.position.z) - rb.position;
        transform.forward = dir;
        rb.MovePosition(rb.position + dir.normalized * moveSpeed);
    }

    
}
