using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawSphere : MonoBehaviour
{
    // Just for testing purpose (I'm checking if the cop is aiming correctly to the target)
    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.05f);

    }
}
