using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] cars;
    public int maxRandomDelay = 3;

    float[] posX = { 24.0f, 14.0f, 4.0f, -5.0f, -15.0f, -25.0f };
    float posZ = -120.0f;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        InvokeRepeating("SpawnCar", 0, Random.Range(1, maxRandomDelay));        
    }

    void SpawnCar() 
    {
        if (gameManager.IsWin || gameManager.IsGameover) return;

        Vector3 spawnPos = new Vector3(posX[Random.Range(0, posX.Length)], 0, posZ);
        int index = Random.Range(0, cars.Length);

        Instantiate(cars[index], spawnPos, cars[index].transform.rotation);  
    }


}
