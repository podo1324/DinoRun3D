using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoFollowCamera : MonoBehaviour
{
    public Transform target; // 따라갈 오브젝트 (Dino)
    public Vector3 offset; // 카메라의 고정된 위치 ( 현재 세팅된 쿼터뷰 카메라 위치 )
    void Start()
    {
        offset = target.position - transform.position;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, target.position.z - offset.z);

            transform.position = newPosition;
        }
    }
}
