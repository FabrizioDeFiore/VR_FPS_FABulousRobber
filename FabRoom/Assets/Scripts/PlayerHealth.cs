using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public GameObject GameOverScreen;
    // IMPLEMENT IK FOR PLAYER BODY, THEN RAGDOL, THEN THIS LINE
    //Ragdoll ragdoll;
    protected override void OnStart(){
        // IMPLEMENT IK FOR PLAYER BODY, THEN RAGDOL, THEN THIS LINE
        //ragdoll = GetComponent<Ragdoll>();	
    }
    protected override void OnDeath(){
        // IMPLEMENT IK FOR PLAYER BODY, THEN RAGDOL, THEN THIS LINE
        //ragdoll.activateRagdoll();
        GameOverScreen.SetActive(true);
        Time.timeScale = 0f;
        
        
    }
    protected override void OnDamage(){
        
    }
}
