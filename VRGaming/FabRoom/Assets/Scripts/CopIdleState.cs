using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopIdleState : CopsState
{
        public CopStateId GetId(){
            return CopStateId.Idle;
        }

        public void Enter(CopsAgent cop){ 

        }

        public void Update(CopsAgent cop){
            // Get player direction
            Vector3 playerDirection = cop.playerTransform.position - cop.transform.position;
            // Chek if it's to far away
            if (playerDirection.magnitude > cop.config.maxSightDistance){
                return;
            }
            
            // Get cop direction and calculate the dot product between the player and the cop directions
            Vector3 copDirection = cop.transform.forward;
            playerDirection.Normalize();
            float dotProduct = Vector3.Dot(playerDirection, copDirection);
            // Check if player is in the range of the cop and chase him
            if (dotProduct > 0.0f){
                cop.stateMachine.ChangeState(CopStateId.ChasePlayer);
            }



        }

        public void Exit(CopsAgent cop){
        
        }
}
