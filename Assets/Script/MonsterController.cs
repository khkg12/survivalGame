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
        target = GameManager.Instance.player.GetComponent<Rigidbody>(); // 프리팹에선 오브젝트를 가져올수없으므로 gm에 플레이어 오브젝트 미리저장해둠
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
