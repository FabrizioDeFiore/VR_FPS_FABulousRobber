using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopAttackPlayerState :  CopsState
{
        public CopStateId GetId(){
            return CopStateId.AttackPlayer;
        }

        public void Enter(CopsAgent cop){
            cop.weapon.ActivateWeapon();
            cop.weapon.SetTarget(cop.playerTransform);
        }

        public void Update(CopsAgent cop){

        }

        public void Exit(CopsAgent cop){
        
        }
}

