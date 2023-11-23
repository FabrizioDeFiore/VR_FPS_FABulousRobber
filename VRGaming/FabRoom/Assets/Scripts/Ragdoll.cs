using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    Rigidbody[] rigidBodies;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        // Get all the rigidbodies created by the ragdoll for each part of the body and fill the array to get the reference
        rigidBodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        DeactivateRagdoll();
    }

    public void DeactivateRagdoll(){
        // Set all the part of the body to be kinematic to deactivate them 
        foreach(var rigidBody in rigidBodies){
            rigidBody.isKinematic = true;
        }
        animator.enabled = true;
    }
    public void ActivateRagdoll(){
        // Set all the part of the body to NOT be kinematic to activate them 
        foreach(var rigidBody in rigidBodies){
            rigidBody.isKinematic = false;
        }
        // turining animator off because of the ragdoll on
        animator.enabled = false;
    }
}
