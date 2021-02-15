using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalBonus : MonoBehaviour
{
    public int healthRestore;

    void OnTriggerEnter(Collider other){
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if(playerHealth != null){
            playerHealth.TakeMedic(healthRestore);
            Destroy(gameObject);
        }
    }
}
