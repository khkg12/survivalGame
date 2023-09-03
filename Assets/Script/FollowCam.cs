using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        tr.position = new Vector3(target.position.x, tr.position.y, target.position.z - 2);        
        tr.LookAt(target);
    }
}
