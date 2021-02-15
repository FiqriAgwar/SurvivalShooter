﻿using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent navMesh;

    private void Awake(){
        player = GameObject.FindGameObjectWithTag ("Player").transform;

        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update(){
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0){
            navMesh.SetDestination(player.position);
        }
        else{
           navMesh.enabled = false;
        }
    }
}
