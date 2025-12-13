using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject titlePanel;

    public Slider progressBar;

    public bool isGameStart;
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

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void SetDistanceProgressBar()
    { 
        
    }

    public void GameStart()
    {
        Debug.Log("게임 시작 버튼 누름");
        isGameStart = true;
        Time.timeScale = 1f;
        titlePanel.SetActive(false);
    }

}
