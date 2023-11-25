using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;  


public class RifleFireBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;
    public float fireRate = 1f;
    public float fireTimer = 0f;
    private bool isFiring = false;
    // Start is called before the first frame update
    void Start(){
        // Get interactable component form object and fire when key is pressed
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        //grabbable.activated.AddListener(Fire);
        // Add listeners for interaction events
        grabbable.activated.AddListener(StartFiring);
        grabbable.deactivated.AddListener(StopFiring);
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

    private void StartFiring(ActivateEventArgs arg){
        isFiring = true;
    }

    private void StopFiring(DeactivateEventArgs arg){
        isFiring = false;
    }

    public void Fire(){
        Quaternion bulletRotation = Quaternion.Euler(bullet.transform.localRotation.x , spawnPoint.localRotation.y, spawnPoint.localRotation.z);
        bullet.transform.localRotation = bulletRotation;
        // Create the bullet object
        GameObject spawnedBullet = Instantiate(bullet, spawnPoint.position, bulletRotation  );// spawnPoint.localRotation
        // Fire it giving trajectory and speed
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        // From the spawn point position
        //spawnedBullet.transform.position = spawnPoint.position;
        // Quaternion bulletRotation = Quaternion.Euler(90, 0, 0);
        // spawnedBullet.transform.localRotation = bulletRotation;  
    }   
}
