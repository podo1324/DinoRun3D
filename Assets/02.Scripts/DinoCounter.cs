using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DinoCounter : MonoBehaviour
{
    public TextMeshPro dinoCountText;
    public Transform dinosParent;   // Raptor들을 관리할 부모 오브젝트

    void Start()
    {
         
    }

    void Update()
    {
        dinoCountText.text = dinosParent.childCount.ToString();
        if (dinosParent.childCount <= 0)    // 현재 raptor들이 0보다 작거나 같게 되면
        {
            this.gameObject.SetActive(false);  // Text 표시를 꺼줍니다.
        }

    }
}
