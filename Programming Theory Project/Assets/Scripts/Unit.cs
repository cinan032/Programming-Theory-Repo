using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour // INHERITANCE
{
    public GameObject gameManager;
    private float speed = 40.0f;
    private float zRange = 120.0f;
    private float xRange = 40.0f;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
       
    public float Speed { get { return speed; } set { speed = value; } } // ENCAPSULATION

    public void GoForward(float input)
    {
        if (gameManager.GetComponent<GameManager>().IsWin || gameManager.GetComponent<GameManager>().IsGameover) return;
        transform.Translate(Vector3.forward * Time.deltaTime * speed * input);
    }

    public virtual void TurnLeftRight(float input) // POLYMORPHISM
    {
        if (gameManager.GetComponent<GameManager>().IsWin || gameManager.GetComponent<GameManager>().IsGameover) return;
        transform.Translate(Vector3.right * Time.deltaTime * speed * input);
    }
    public virtual bool AvoidOverRange() // POLYMORPHISM
    {
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
            return true;
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
            return true;
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            return true;
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            return true;
        }

        return false;
    }

    public void GameOver()
    {
        gameManager.GetComponent<GameManager>().IsGameover = true;
        Debug.Log("Game Over!");
    }
}
