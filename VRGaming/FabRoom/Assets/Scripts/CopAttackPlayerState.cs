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
            cop.navMeshCop.stoppingDistance = 18.0f;
            cop.weapon.SetFiring(true);

        }

        public void Update(CopsAgent cop){
            cop.navMeshCop.destination = cop.playerTransform.position;
        }

        public void Exit(CopsAgent cop){
            //cop.navMeshCop.stoppingDistance = 0.0f;
        }
}

