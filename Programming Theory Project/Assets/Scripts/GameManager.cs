using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameover = false;
    bool win = false;
    public bool IsWin { get { return win; } }
    public bool IsGameover { get { return gameover; } set { gameover = value; } }

    GameObject player;


    private void Start()
    {
        player = GameObject.Find("Player");

    }

    void Update()
    {
        if (player.transform.position.x >= 40)
        { 
            win = true;
            Debug.Log("Win!");
        }
    }
}
