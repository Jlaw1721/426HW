using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.Mechanics;
using UnityEngine;

public class StarBoostScript : MonoBehaviour
{
    public float rotationAmount = 4.0f;
    public int healthBoostAmount = 5;
    public float speedBoost = 10.0f;
    public float jumpBoost = 10.0f;
    public GameObject player;
    public int boostTime = 7;
    
    private int _previousHealth;
    private float _previousSpeed;
    private float _previousJump;
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0f, rotationAmount, 0f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == player.name)
        {
            _previousHealth = player.GetComponent<Health>().getHealth();
            _previousSpeed = player.GetComponent<PlayerController>().getSpeed();
            _previousJump = player.GetComponent<PlayerController>().getJumpStats();
            
            player.GetComponent<PlayerController>().boostStats(speedBoost, jumpBoost);
            player.GetComponent<Health>().HealthBoost(healthBoostAmount);

            GetComponent<BoxCollider2D>().isTrigger = false;
            GetComponent<SpriteRenderer>().enabled = false;

            StartCoroutine(boostPeriod(boostTime));
        }
    }

    IEnumerator boostPeriod(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        
        player.GetComponent<PlayerController>().boostStats(_previousSpeed, _previousJump);
        player.GetComponent<Health>().HealthBoost(_previousHealth);
    }
}
