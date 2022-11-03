using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    bool crossing = false;
    private float player_zRange = 98.0f;
    Animator animator;
    public ParticleSystem particle;

    bool gameStart = false;

    void Start()
    {
        this.Speed = 20.0f;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!gameStart)
        {
            if (transform.position.x < -35) transform.Translate(Vector3.forward * Time.deltaTime * (this.Speed/2));
            else gameStart = true;
            return;
        }
        //animator.SetFloat("Speed_f", 0f);
        if (AvoidOverRange()) crossing = false;
        if (!crossing)
        {
            float hor = Input.GetAxis("Horizontal");
            if (hor != 0) animator.SetFloat("Speed_f", 1.0f);
            else animator.SetFloat("Speed_f", 0.0f);
            TurnLeftRight(hor);
           
        }

        if (Input.GetKeyDown(KeyCode.Space) || crossing)
        {
            crossing = true;
            GoForward(1);
            animator.SetFloat("Speed_f", 3.0f);
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
            crossing = false;
            animator.SetFloat("Speed_f", 0.0f);
            particle.Play();
            GameOver();    
        }
    }

}
