using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Health health;
    private void OnCollisionEnter(Collision collision){
        // Check if colliding with a bullet 
        if (collision.gameObject.CompareTag("Bullet")){
            // Call the TakeDamage function form the health script 
            health.TakeDamage(10);
        }
    }
}
