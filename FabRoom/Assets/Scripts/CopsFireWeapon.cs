using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopsFireWeapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;
    public float fireRate = 1f;
    public float fireTimer = 0f;
    private bool isFiring = false;
    public float inaccuracy = 0.0f;
    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void FixedUpdate(){
        // Check if the fire button is being held down
        if (isFiring){
            // Update timer
            fireTimer += Time.fixedDeltaTime;
            // Start firing bullets every second
            if(fireTimer > fireRate){
                Fire();
                fireTimer = 0f;
            }
        }
    }

    public void StartFiring(){
        isFiring = true;
    }

    public void StopFiring(){
        isFiring = false;
    }

    public void Fire(){
        Quaternion bulletRotation = Quaternion.Euler(bullet.transform.localRotation.x , spawnPoint.localRotation.y, spawnPoint.localRotation.z);
        bullet.transform.localRotation = bulletRotation;
        // Create the bullet object
        GameObject spawnedBullet = Instantiate(bullet, spawnPoint.position, bulletRotation  );// spawnPoint.localRotation  
        // Fire it giving trajectory and speed and inaccuracy to semplify the game 
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed; // spawnPoint.forward * fireSpeed     (spawnPoint.forward + (Random.insideUnitSphere * inaccuracy)) * fireSpeed;
        
    }   
}

