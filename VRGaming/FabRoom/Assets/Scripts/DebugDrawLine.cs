using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDrawLine : MonoBehaviour
{
    private void OnDrawGizmos() {
        // Draw a debug line to see were the gun is pointing
        Debug.DrawLine(transform.position, transform.position + transform.forward * 50);
    }

}
