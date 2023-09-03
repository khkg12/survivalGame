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
            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)); // ���콺 ����             
            Debug.Log("ī�޶� ���� Ŭ�� ���� : "+point);
            Debug.Log("�÷��̾��� ��ġ : " + transform.position);
            Debug.DrawLine(transform.position, point - transform.position, UnityEngine.Color.red,1f);

            Vector3 nowPoint = point - transform.position;
            nowPoint.y = 0;
            nowPoint = nowPoint.normalized;
            Debug.Log("���⺤�� : " + nowPoint);
            
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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ����ī�޶� ��ġ�κ��� ���콺����������ġ�� ī�޶���� �Ÿ�(�μ��� z)�� ����� ������� ��ǥ�� ��ȯ�ϰ�,
                                                                     // �� ��ǥ�� ���ϴ� Ray�� ����
        RaycastHit rayHit; // ������ ���� ��ü�� ����
        if(Physics.Raycast(ray, out rayHit)) // ������ ���� �浹ü�� �����ϸ� true����, out�� ���� rayHit�� �ʱ�ȭ���� �ʿ����, true�� ��� �� �浹�� ��ü�� ������ rayHit�� ����Ǿ, �׶��� ����ϰ� ���ִ� ��
        {
            Vector3 dir = new Vector3(rayHit.point.x, transform.position.y, rayHit.point.z) - transform.position; // ���� dir.y = 0�� ���ʿ� ĳ������ y������ �־ �����̵ǰ��Ѱ�
            transform.forward = dir; // ���� ���� ������Ʈ�� ������ ���̰� 1�� ���Ϳ�, �� z���� ���⿡ ������ ���� ������ �־��شٴ� �ǹ�            
        }
    }   
}
