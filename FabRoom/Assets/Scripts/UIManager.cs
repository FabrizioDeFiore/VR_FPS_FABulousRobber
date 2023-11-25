using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public GameObject canvas;
    public InputActionProperty closeCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Close the canvas when button si pressed
        // if(closeCanvas.action.WasPressedThisFrame()){
            // canvas.SetActive(!canvas.activeSelf);
        // }

    }
}
