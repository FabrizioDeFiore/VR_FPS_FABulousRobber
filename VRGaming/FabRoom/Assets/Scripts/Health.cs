using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    CopsAgent cop;
    public float blinkIntensity;
    public float blinkDuration;
    float blinkTimer;
    SkinnedMeshRenderer skinnedMeshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        cop = GetComponent<CopsAgent>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        currentHealth = maxHealth;
        //Assign the hitbox script to all the part of the ragdoll 
        var rigidBodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigidBody in rigidBodies){
            HitBox hitBox = rigidBody.gameObject.AddComponent<HitBox>();
            hitBox.health = this;
        }
    }

    public void TakeDamage(float amount){
        // Update health with the damage
        currentHealth -= amount;
        // If health is finished kill the character 
        if (currentHealth <= 0.0f){
            Die();
        }
        // Give an illumination effect to the character when he's hitted so i know i didn't miss him
        blinkTimer = blinkDuration;
    }

    public void Die(){
        // Get ref to the state machine script that manage the die 
        CopDeathState deathState = cop.stateMachine.GetState(CopStateId.Death) as CopDeathState;
        // Change state 
        cop.stateMachine.ChangeState(CopStateId.Death);
    }

    private void Update(){
        // Update timer 
        blinkTimer -= Time.deltaTime;
        // Calculate intensity based on the timer for the amount of time specified 
        float lerp = Mathf.Clamp01(blinkTimer / blinkDuration);
        float intensity = (lerp * blinkIntensity) + 1.0f;
        // Apply the intesity effect
        skinnedMeshRenderer.material.color = Color.white * intensity;
    }
    
}
