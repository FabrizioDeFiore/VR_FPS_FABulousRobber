using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;  


public class PistolFireBullet : MonoBehaviour
{
    private AudioSource gunShot;
    public GameObject bullet;
    public Transform spawnPoint;
    public Vector3 spawnFlip;
    public float fireSpeed = 20;
    // Start is called before the first frame update
    void Start(){
        // Get interactable component form object and fire when key is pressed
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Fire);
        gunShot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void Fire(ActivateEventArgs arg){

        // Create the bullet object
        GameObject spawnedBullet = Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
        // Flip the rotation of the bullet model
        spawnedBullet.transform.Rotate(spawnFlip);
        // Fire it giving trajectory and speed
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        gunShot.Play();
    }

    
}
