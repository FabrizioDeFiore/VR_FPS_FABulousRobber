using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;  


public class RifleFireBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public Vector3 spawnFlip;
    public float fireSpeed = 20;
    public float fireRate = 1f;
    public float fireTimer = 0f;
    private bool isFiring = false;
    private AudioSource gunShot;
    // Start is called before the first frame update
    void Start(){
        // Get interactable component form object and fire when key is pressed
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        //grabbable.activated.AddListener(Fire);
        // Add listeners for interaction events
        grabbable.activated.AddListener(StartFiring);
        grabbable.deactivated.AddListener(StopFiring);
        gunShot = GetComponent<AudioSource>();

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
        // Create the bullet object
        GameObject spawnedBullet = Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
        // Flip the rotation of the bullet model
        spawnedBullet.transform.Rotate(spawnFlip);
        // Fire it giving trajectory and speed
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        gunShot.Play();
    }
}
