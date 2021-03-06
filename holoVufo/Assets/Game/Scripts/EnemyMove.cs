﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class EnemyMove : MonoBehaviour {

    private Transform player;
    private NavMeshAgent nav;
    private Animator anim;
    private EnemyHealth enemyHealth;
    

    // Use this for initialization
    void Start () {
        player = GameManager.instance.Player.transform;
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.instance.GameOver && enemyHealth.IsAlive)
        {
            //print(player.position.x.ToString());
            //nav.SetDestination(player.position);
            nav.enabled = true;
            nav.destination = player.position;
           

        }
        else if(!enemyHealth.IsAlive)
        {
            nav.enabled = false;

        }
        else
        {
            nav.enabled = false;
            anim.Play("Idle");
        }
        
	}
}
