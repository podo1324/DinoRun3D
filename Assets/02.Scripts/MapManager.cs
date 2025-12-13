using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // ΩÃ±€≈Ê ¿ŒΩ∫≈œΩ∫
    public static MapManager Instance { get; private set; }

    public GameObject[] mapPrefabs;
    public GameObject goalObject;

    private void Awake()
    {
        // ΩÃ±€≈Ê √ ±‚»≠
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // æ¿ ¿¸»Øø°µµ ¿Ø¡ˆ
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // ¡ﬂ∫π ¡¶∞≈
        }
    }

    void Start()
    {
        CreatMap();
        goalObject = GameObject.FindWithTag("Goal");
    }

    private void CreatMap()
    {
        Vector3 mapPosition = Vector3.zero;

        for (int i = 0; i < 5; i++)
        {
            GameObject selectedMap;

            if (i > 0)
            {
                selectedMap = mapPrefabs[Random.Range(1, mapPrefabs.Length)];
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
            }
            else
            {
                selectedMap = mapPrefabs[0];
            }

            GameObject nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity);
            mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2;
        }
    }

    public float GetGoalDistance()
    {
        return gameObject.transform.position.z;
    }
}
