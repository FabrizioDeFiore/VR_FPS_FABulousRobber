using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;  


public class PistolFireBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;
    // Start is called before the first frame update
    void Start(){
        // Get interactable component form object and fire when key is pressed
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Fire);
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void Fire(ActivateEventArgs arg){
        Quaternion bulletRotation = Quaternion.Euler(spawnPoint.localRotation.x - 90, spawnPoint.localRotation.y, spawnPoint.localRotation.y);
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
