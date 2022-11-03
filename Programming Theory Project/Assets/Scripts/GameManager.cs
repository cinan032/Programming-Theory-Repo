using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameover = false;
    bool win = false;
    public bool IsWin { get { return win; } }
    public bool IsGameover { get { return gameover; } set { gameover = value; } }

    public Text Msg;

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
        if (win) Msg.text = "Win!\nPress Space to restart.";
        if (gameover) Msg.text = "Game Over!\nPress Space to restart.";
        if ((win || gameover) && Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
