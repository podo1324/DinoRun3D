using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DinoCounter : MonoBehaviour
{
    public TextMeshPro dinoCountText;
    public Transform raptors;
    
    void Update()
    {
        dinoCountText.text = raptors.childCount.ToString();
    }

}
