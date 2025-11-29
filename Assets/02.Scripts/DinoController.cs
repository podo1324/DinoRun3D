using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DinoController : MonoBehaviour
{
    public float moveSpeedZ; // z축 움직이는 속도 변수
    public float moveSpeedX;  // x축 움직이는 속도 변수

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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.9f, 3.9f), transform.position.y, transform.position.z);
    }
}
