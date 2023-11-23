using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopsStateMachine
{
    public CopsState[] states;
    public CopsAgent cop;
    public CopStateId currentState;
    public CopsStateMachine(CopsAgent cop){
        this.cop = cop;
        // Get the number of states from the enum
        int numStates = System.Enum.GetNames(typeof(CopStateId)).Length;
        // Create new state for each one 
        states = new CopsState[numStates];
    }

    public void RegisterState(CopsState state){
        // Get the position to store the state 
        int index = (int)state.GetId();
        states[index] = state;
    }

    public CopsState GetState(CopStateId stateId){
        // Get the id of the state 
        int index = (int)stateId;
        return states[index];
    }

    public void Update(){
        // Update the state of the cop with the current state 
        GetState(currentState)?.Update(cop);
    }

    public void ChangeState(CopStateId newState){
        // Leave the current state 
        GetState(currentState)?.Exit(cop);
        // Update with new state 
        currentState = newState;
        // Enter the new state 
        GetState(currentState)?.Enter(cop);

    }
}
