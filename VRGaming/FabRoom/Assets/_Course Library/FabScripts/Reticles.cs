using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Reticles : MonoBehaviour
{
    public float spinSpeed = 100.0f; // Speed at which the reticle spins
    public float scaleSpeed = 1.0f;  // Speed at which the reticle scales

    private void Update()
    {
        // Rotate the reticle around its up axis (y-axis)
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);

        // Scale the reticle up and down using a sine wave
        float scaleFactor = Mathf.Sin(Time.time * scaleSpeed) * 0.2f + 1.0f; // Adjust the 0.2f for the desired scaling range
        transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }
}
