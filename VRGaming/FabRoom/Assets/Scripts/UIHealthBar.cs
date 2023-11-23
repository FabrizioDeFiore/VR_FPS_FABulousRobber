using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthBar : MonoBehaviour
{
    public Transform target;
    // public Camera cam;
    // void Start(){
    //     cam = GetComponent<Camera>();
    // }
    void LateUpdate(){
        // Attach the healthbar to the enemy position
        transform.position = Camera.main.WorldToScreenPoint(target.position);
        
    }
}
