using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    float moveSpeed;
    
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)); // 마우스 벡터             
            Debug.Log("카메라 기준 클릭 지점 : "+point);
            Debug.Log("플레이어의 위치 : " + transform.position);
            Debug.DrawLine(transform.position, point - transform.position, UnityEngine.Color.red,1f);

            Vector3 nowPoint = point - transform.position;
            nowPoint.y = 0;
            nowPoint = nowPoint.normalized;
            Debug.Log("방향벡터 : " + nowPoint);
            
            Quaternion qua = Quaternion.LookRotation(nowPoint.normalized);
            transform.LookAt(transform.position + nowPoint);// = qua;
           // Debug.Log(qua);
        }*/      
        LookMousePoint();
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveVec = new Vector3(moveX, 0, moveZ);

        moveSpeed = GameManager.Instance.player.MoveSpeed;
        transform.Translate(moveVec.normalized * moveSpeed);
        
    }

    public void LookMousePoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 메인카메라 위치로부터 마우스포인터의위치를 카메라와의 거리(인수의 z)를 고려해 월드기준 좌표로 변환하고,
                                                                     // 그 좌표를 향하는 Ray를 리턴
        RaycastHit rayHit; // 광선에 맞은 물체의 정보
        if(Physics.Raycast(ray, out rayHit)) // 광선에 맞은 충돌체가 존재하면 true리턴, out은 위의 rayHit을 초기화해줄 필요없이, true일 경우 그 충돌된 물체의 정보를 rayHit이 저장되어서, 그때만 사용하게 해주는 것
        {
            Vector3 dir = new Vector3(rayHit.point.x, transform.position.y, rayHit.point.z) - transform.position; // 위의 dir.y = 0을 애초에 캐릭터의 y값으로 넣어서 수평이되게한것
            transform.forward = dir; // 월드 기준 오브젝트의 앞쪽의 길이가 1인 벡터에, 즉 z축의 방향에 위에서 구한 방향을 넣어준다는 의미            
        }
    }   
}
