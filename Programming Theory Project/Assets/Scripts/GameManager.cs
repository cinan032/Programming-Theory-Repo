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

    public Text msg;
    public Text lastWinner;

    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        if (GameInfo.instance != null)
            lastWinner.text = "Last Winner: " + GameInfo.instance.lastRecord.lastWinner;
    }

    void Update()
    {
        if (player.transform.position.x >= 40)
        { 
            win = true;
            Debug.Log("Win!");
        }
        if (win)
        {
            msg.text = "Win!\nPress Space to exit.";
            GameInfo.instance.saveRecord();
        }
        if (gameover) msg.text = "Game Over!\nPress Space to restart.";


        if (win && Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(0);
        if (gameover && Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene(1);
    }
}
