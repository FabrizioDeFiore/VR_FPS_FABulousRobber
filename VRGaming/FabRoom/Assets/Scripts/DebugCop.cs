using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DebugCop : MonoBehaviour
{
    public bool velocity;
    public bool desiredVelocity;
    public bool path;
    public NavMeshAgent cop;
    // Start is called before the first frame update
    void Start()
    {
        cop = GetComponent<NavMeshAgent>();
    }
    // Testing class for visualizzation of vel, paths, trajectories etc
    void OnDrawGizmos() {
        if (velocity){
            //Debug.Log("cop.vel from DebugClass: " + cop.velocity);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + cop.velocity);
        }
        if (desiredVelocity){
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + cop.desiredVelocity);
        }
        // draw a line between each corner of the path and a circle to each corner of the path
        if (path){
            Gizmos.color = Color.black;
            var copPath = cop.path;
            Vector3 prevCorner = transform.position;
            foreach(var corner in copPath.corners){
                Gizmos.DrawLine(prevCorner, corner);
                Gizmos.DrawSphere(corner, 0.1f);
                prevCorner = corner;
            }
        }
    }
}
