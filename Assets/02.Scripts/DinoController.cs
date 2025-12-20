using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DinoController : MonoBehaviour
{
    public static DinoController instance;
    public float zMoveSpeed;
    public float xMoveSpeed;
    // 구체의 중심이 될 위치
    public Vector3 sphereCenter;
    // 구체의 반지름
    public float sphereRadius = 0.5f;
    public DinoPositionController dinoPositionController;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {
        if (GameManager.instance.isGameStart)
        {
            DinoMove();
            DoorCheck();
        }
    }

    private void DinoMove()
    {
        transform.position += Vector3.forward * Time.deltaTime * zMoveSpeed;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(xMoveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-xMoveSpeed * Time.deltaTime, 0, 0);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.9f, 3.9f), transform.position.y, transform.position.z);
    }

    private void DoorCheck()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + sphereCenter, sphereRadius);

        foreach (Collider doors in hitColliders)
        {
            if (doors.CompareTag("Goal"))
            {
                PlayerPrefs.SetInt("Stage", PlayerPrefs.GetInt("Stage") + 1);
                doors.gameObject.GetComponent<BoxCollider>().enabled = false;
                SceneManager.LoadScene(0);
            }
            else
            {
                int doorNumber = doors.gameObject.GetComponent<SelectDoors>().GetDoorNumber(transform.position.x);
                DoorType doorType = doors.gameObject.GetComponent<SelectDoors>().GetDoorType(transform.position.x);
                doors.gameObject.GetComponent<BoxCollider>().enabled = false;
                dinoPositionController.SetDoorcalc(doorType, doorNumber);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + sphereCenter, sphereRadius);
    }
}
