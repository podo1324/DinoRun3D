using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject[] mapPrefabs;
    void Start()
    {
        Vector3 mapPosition = Vector3.zero;

        for (int i = 0; i < 5; i++)
        {
            GameObject selectedMap = mapPrefabs[Random.Range(0, mapPrefabs.Length)];

            if (i > 0)
            {
                mapPosition.z += selectedMap.GetComponent<Map>().GetMapSize() / 2;
            }

            GameObject nowMap = Instantiate(selectedMap, mapPosition, Quaternion.identity);
            mapPosition.z += nowMap.GetComponent<Map>().GetMapSize() / 2;
        }
    }

    
}
