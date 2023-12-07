using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class PlayerHealth : Health
{
    //VolumeProfile postProcessing;
    public GameObject GameOverScreen;
    private AudioSource gameOverSound;
    // IMPLEMENT IK FOR PLAYER BODY, THEN RAGDOL, THEN THIS LINE
    //Ragdoll ragdoll;
    protected override void OnStart(){
        gameOverSound = GetComponent<AudioSource>();
        //postProcessing = FindObjectOfType<Volume>().profile;
        // IMPLEMENT IK FOR PLAYER BODY, THEN RAGDOL, THEN THIS LINE
        //ragdoll = GetComponent<Ragdoll>();	
    }
    protected override void OnDeath(){
        // IMPLEMENT IK FOR PLAYER BODY, THEN RAGDOL, THEN THIS LINE
        //ragdoll.activateRagdoll();
        GameOverScreen.SetActive(true);
        gameOverSound.Play();
        Time.timeScale = 0f;
        
        
    }
    protected override void OnDamage(){
        // Vignette vignette ;
        // if(postProcessing.TryGet(out vignette)){
        //     Debug.Log("AHIA");
        //     float percent = 1.0f - (currentHealth/maxHealth);
        //     vignette.intensity.value = percent * 0.5f;
        // }
    }
}
