using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopDeathState : CopsState
{
        public CopStateId GetId(){
            return CopStateId.Death;
        }

        public void Enter(CopsAgent cop){
            cop.ragdoll.ActivateRagdoll();
            cop.weapon.DropWeapon();
        }

        public void Update(CopsAgent cop){

        }

        public void Exit(CopsAgent cop){
        
        }
}
