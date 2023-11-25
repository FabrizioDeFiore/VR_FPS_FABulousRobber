using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CopChasePlayerState : CopsState
{
    
    
    float timer = 0.0f;
    public CopStateId GetId(){
        return CopStateId.ChasePlayer;
    }
    public void Enter(CopsAgent cop){
        
    }
    public void Update(CopsAgent cop){
        if(!cop.enabled){
            return;
        }
        // Update the timer
        timer -= Time.deltaTime;
        if(!cop.navMeshCop.hasPath){
            // Set the destination of the cop to the player(xr rig position in this case)
            cop.navMeshCop.destination = cop.playerTransform.position;
        }
        // Doing this to have a small delay on recalculating the path 
        if(timer < 0.0f){
            // Get the distance
            //float sqrDistance = (playerTransform.position - cop.destination).sqrMagnitude;
            // Get the direction
            Vector3 direction = (cop.playerTransform.position - cop.navMeshCop.destination);
            direction.y = 0;
            // Doing this to not constantly calculating the path, also when cop arrives to destination
            if(direction.sqrMagnitude > cop.config.maxDistance * cop.config.maxDistance){
            //if (sqrDistance > maxDistance*maxDistance){
                if(cop.navMeshCop.pathStatus != NavMeshPathStatus.PathPartial){
                    // Set the destination of the cop to the player(xr rig position in this case)
                    cop.navMeshCop.destination = cop.playerTransform.position;
                }
                
            }   
            // Reset timer 
            timer = cop.config.maxTime;  
        }
    }
    public void Exit(CopsAgent cop){
        
    }
}
