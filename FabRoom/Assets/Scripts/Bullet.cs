using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other){
        //Debug.Log("Collision w: " + other);
        // Check if the collision is with an object on the "enemies" layer
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemies")){
            // Inflic Damage to enemy
            Destroy(gameObject);
        } else if (other.gameObject.layer == LayerMask.NameToLayer("Environment")){
            Destroy(gameObject);
        } else if (other.gameObject.layer == LayerMask.NameToLayer("Player")){
            // inflict damage to the player 
            Destroy(gameObject);
        }
    }   
}
