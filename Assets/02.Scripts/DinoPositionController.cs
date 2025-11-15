using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DinoPositionController : MonoBehaviour
{

    public Transform raptors;
    public float radius = 1f;
    public float ratio = 0.1f;

    void Update()
    {
        SetDinoPosition();
    }

    private void SetDinoPosition()
    {
        float angleStep = 360f / (raptors.childCount * ratio);

        for (int i = 0; i < raptors.childCount; i++)
        {

            float angle = i * angleStep;

            float angleRad = angle * Mathf.Deg2Rad;

            float x = Mathf.Cos(angleRad) * radius;
            float z = Mathf.Sin(angleRad * radius);

            raptors.GetChild(i).localPosition = new Vector3(x, 0, z);
        }
    }
}