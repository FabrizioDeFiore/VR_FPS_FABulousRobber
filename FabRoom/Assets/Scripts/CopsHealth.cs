using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopsHealth : Health
{
    CopsAgent cop;
    protected override void OnStart(){
        cop = GetComponent<CopsAgent>();
    }
    protected override void OnDeath(){
        // Get ref to the state machine script that manage the die 
        CopDeathState deathState = cop.stateMachine.GetState(CopStateId.Death) as CopDeathState;
        // Change state 
        cop.stateMachine.ChangeState(CopStateId.Death);
        
    }
    protected override void OnDamage(){
        
    }
}
