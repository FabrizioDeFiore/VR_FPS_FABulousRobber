using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CopsLocomotion : MonoBehaviour
{
    NavMeshAgent cop;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        cop = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // If cop has a path update the animator
        if(cop.hasPath){
            // Update animator speed value with cop speed value to animate the enemy depending on his velocity
            animator.SetFloat("Speed", cop.velocity.magnitude);
        // Otherwise go to idle state 
        } else {
            animator.SetFloat("Speed", 0);
        }
        // Testing stuff
        //Debug.Log("speed from animator: " + animator.GetFloat("Speed"));
    }
}
