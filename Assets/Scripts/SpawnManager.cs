using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] fogTypes;
    private float zRange1 = 1000;
    private float zRange2 = 1900;
    private PlayerController playerCtrl;
    
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnRandomFog", 0, 10);
    }

    void SpawnRandomFog()
    {
        float randomZPos = Random.Range(zRange1, zRange2);
        int fogTypesIndex = Random.Range(0, fogTypes.Length);
        Vector3 randPos = new Vector3(-100, 350, randomZPos);
        if (!playerCtrl.isGameOver)
            Instantiate(fogTypes[fogTypesIndex], randPos, fogTypes[fogTypesIndex].transform.rotation);
    }
}
