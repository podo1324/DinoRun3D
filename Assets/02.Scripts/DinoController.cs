using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public static DinoController Instance { get; private set; }

    public float moveSpeedZ;
    public float moveSpeedX;
    public Vector3 sphereCenter;
    public float sphereRadius = 0.5f;
    public DinoPositionController dinoPositionController;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
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
        transform.position += Vector3.forward * Time.deltaTime * moveSpeedZ;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeedX * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-moveSpeedX * Time.deltaTime, 0, 0);
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
                Debug.Log("∞Ò¿Œ!");
                doors.gameObject.GetComponent<BoxCollider>().enabled = false;
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
