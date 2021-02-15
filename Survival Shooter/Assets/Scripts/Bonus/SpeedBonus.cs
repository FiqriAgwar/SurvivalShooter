using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus : MonoBehaviour
{
    public int speedGain;
    public float speedTime;

    void OnTriggerEnter(Collider other){
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

        if(playerMovement != null){
            playerMovement.Boost(speedGain, speedTime);
            Destroy(gameObject);
        }
    }
}
