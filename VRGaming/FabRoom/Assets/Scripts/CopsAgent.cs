using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CopsAgent : MonoBehaviour
{
    public CopsStateMachine stateMachine;
    public CopStateId initialState;
    public NavMeshAgent navMeshCop;
    public CopsConfig config;
    public Ragdoll ragdoll;
    public Transform playerTransform;
    public CopsWeapons weapon;
    public Animator animator;

    // Start is called before the first frame update
    void Start(){
        ragdoll = GetComponent<Ragdoll>();
        navMeshCop = GetComponent<NavMeshAgent>();
        weapon = GetComponent<CopsWeapons>();
        stateMachine = new CopsStateMachine(this);
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        // Register the states
        stateMachine.RegisterState(new CopChasePlayerState());
        stateMachine.RegisterState(new CopDeathState());
        stateMachine.RegisterState(new CopIdleState());
        stateMachine.RegisterState(new CopAttackPlayerState());
        // Set the machine to the initial state 
        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update(){
        // Update the cop's state machine 
        stateMachine.Update();
    } 
}
