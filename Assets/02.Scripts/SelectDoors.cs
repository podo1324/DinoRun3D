using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // textMeshPro

public class SelectDoors : MonoBehaviour
{
    enum DoorType
    { 
        Plus,
        Minus,
        Times,
        Division
    }
    public SpriteRenderer rightDoorSpriteRD;
    public SpriteRenderer leftDoorSpriteRD;
    public TextMeshPro rightDoorText;
    public TextMeshPro leftDoorText;

    [SerializeField]
    private DoorType rightDoorType;
    public int rightDoorNumber;
    [SerializeField]
    private DoorType leftDoorType;
    public int leftDoorNumber;

    public Color goodColor;
    public Color badColor;

    public void SettingDoor()
    {
        if (rightDoorType.Equals(DoorType.Plus))
        {
            rightDoorSpriteRD.color = goodColor;
            rightDoorText.text = "+" + rightDoorNumber;
        }
        else if (rightDoorType.Equals(DoorType.Minus))
        {
            rightDoorSpriteRD.color = badColor;
            rightDoorText.text = "-" + rightDoorNumber;
        }
        if (leftDoorType.Equals(DoorType.Plus))
        {
            leftDoorSpriteRD.color = goodColor;
            leftDoorText.text = "+" + leftDoorNumber;
        }
        else if (leftDoorType.Equals(DoorType.Minus))
        {
            leftDoorSpriteRD.color = badColor;
            leftDoorText.text = "-" + leftDoorNumber;
        }
        if (rightDoorType.Equals(DoorType.Times))
        {
            rightDoorSpriteRD.color = goodColor;
            rightDoorText.text = "x" + rightDoorNumber;
        }
        else if (rightDoorType.Equals(DoorType.Division))
        {
            rightDoorSpriteRD.color = badColor;
            rightDoorText.text = "/" + rightDoorNumber;
        }
        if (leftDoorType.Equals(DoorType.Times))
        {
            leftDoorSpriteRD.color = goodColor;
            leftDoorText.text = "x" + leftDoorNumber;
        }
        else if (leftDoorType.Equals(DoorType.Division))
        {
            leftDoorSpriteRD.color = badColor;
            leftDoorText.text = "/" + leftDoorNumber;
        }
    }
    void Start()
    {
        SettingDoor();
    }

    void Update()
    {
        
    }
}
