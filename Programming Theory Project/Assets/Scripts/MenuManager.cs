using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text nameField;
    public Text lastWinnerText;

    void Start()
    {
        if (GameInfo.instance != null)
            lastWinnerText.text = "Last Winner: " + GameInfo.instance.lastRecord.lastWinner;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            GameInfo.instance.player = nameField.text;
            SceneManager.LoadScene(1);
        }
    }
}


