using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    bool crossing = false;
    private float player_zRange = 98.0f;


    void Start()
    {
        this.Speed = 20.0f;        
    }


    void Update()
    {
        if(AvoidOverRange()) crossing = false;
        if (!crossing)
        {
            TurnLeftRight(Input.GetAxis("Horizontal"));
        }

        if (Input.GetKeyDown(KeyCode.Space) || crossing)
        {
            crossing = true;
            GoForward(1);            
            //GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            //if (pooledProjectile != null)
            //{
            //    pooledProjectile.SetActive(true); // activate it
            //    pooledProjectile.transform.position = transform.position; // position it at player
            //}
        }
    }

    public override bool AvoidOverRange()
    {
        if (transform.position.z < -player_zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -player_zRange);
            return true;
        }

        if (transform.position.z > player_zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, player_zRange);
            return true;
        }

        return base.AvoidOverRange();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            GameOver();    
        }
    }

}
