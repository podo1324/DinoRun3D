using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float moveSpeedZ; // z축 움직이는 속도 변수
    public float moveSpeedX;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeedZ;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-moveSpeedX * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeedX * Time.deltaTime, 0, 0);
        }

    }
}
