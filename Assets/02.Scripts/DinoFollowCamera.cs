using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoFollowCamera : MonoBehaviour
{
    public Transform target;  // 따라갈 오브젝트 (Dino)
    public Vector3 offset;   //  카메라의 고정된 위치 ( 현재 세팅된 쿼터뷰 카메라 위치 )

    void Start()
    {
        offset = target.position - transform.position;
    }

    void LateUpdate()
    {
        if (target != null) 
        {
            // 카메라의 새로운 위치 계산 (  Dino가 좌우로 움직여도 z축으로만 따라가야함 )
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, target.position.z - offset.z);

            // 카메라 위치 업데이트
            transform.position = newPosition;
        }
    }
}
