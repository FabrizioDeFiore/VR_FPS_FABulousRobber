using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHand : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public Animator handAnimator;
    // Update is called once per frame
    void Update(){
        // Get for how loong is pressed the button on the controller 
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        // Update hand Animator with value just got 
        handAnimator.SetFloat("Trigger", triggerValue);

        // Get for how loong is pressed the button on the controller 
        float gripValue = gripAnimationAction.action.ReadValue<float>();
        // Update hand Animator with value just got 
        handAnimator.SetFloat("Grip", gripValue);
    }
}
