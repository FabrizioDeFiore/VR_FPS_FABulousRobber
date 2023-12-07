using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HumanBone{
    public HumanBodyBones bone;
    public float weight = 1.0f;
}

public class WeaponIk : MonoBehaviour
{
    public GameObject cop;
    public CopsWeapons copsWeapons;
    public Transform targetTransform;
    public Transform aimTransform;
    public CopsFireWeapon fireWeapon;
    public int iterations = 10;
    [Range(0,1)]
    public float weight = 1.0f;
    public HumanBone[] humanBones;
    Transform[] boneTransforms;
    public float angleLimit = 90.0f;
    public float distanceLimit = 1.5f;
    public Vector3 targetOffset;

    // Start is called before the first frame update
    void Start(){
        Animator animator = GetComponent<Animator>();
        boneTransforms = new Transform[humanBones.Length];
        // Assign all the bones
        for (int i = 0; i < boneTransforms.Length; i++){
            boneTransforms[i] = animator.GetBoneTransform(humanBones[1].bone);
        }
    }

    Vector3 GetTargetPosition(){
        // Get directions
        Vector3 targetDirection = (targetTransform.position + targetOffset) - aimTransform.position;
        Vector3 aimDirection = aimTransform.forward;
        // Blend back towards the forward axis of the character when limits exceeded
        float blendOut = 0.0f;
        // Calculate the angle 
        float targetAngle = Vector3.Angle(targetDirection, aimDirection);
        // If exceeding the limit
        if(targetAngle > angleLimit){
            // Increase blend amount
            blendOut += (targetAngle - angleLimit) / 50.0f;
        }
        // Get distance to the character 
        float targetDistance = targetDirection.magnitude;
        // If player is too close 
        if (targetDistance < distanceLimit){
            // Blend out 
            blendOut += distanceLimit * targetDistance;
        }
        // Calculate the final adjusted direction by blending between the ideal target direcrtion and the default forward direction of the aim axis 
        Vector3 direction = Vector3.Slerp(targetDirection, aimDirection, blendOut);
        // Calculate final position
        return aimTransform.position + direction;


    }

    // Update is called once per frame
    void LateUpdate(){
        if (aimTransform == null){
            return;
        }
        if (targetTransform == null){
            return;
        }
        // Get target position
        Vector3 targetPosition = GetTargetPosition();
        // Call the funtion multiple time to improve accuracy 
        for (int i = 0; i < iterations; i++){
            // Get each of the bones
            for (int b = 0; b < boneTransforms.Length; b++){
                Transform bone = boneTransforms[b];
                // Calculate the final weight fot each of them 
                float boneWeight = humanBones[b].weight * weight;
                // Aim 
                AimAtTarget(bone, targetPosition, boneWeight);
            }
        }
    }


    private void AimAtTarget(Transform bone, Vector3 targetPosition, float weight){
        // Rotate the bone to the target by calculating the angle between the aim direction and the target direction
        Vector3 aimDirection = aimTransform.forward;
        Vector3 targetDirection = targetPosition - aimTransform.position;
        // Calculate delta rotation 
        Quaternion aimTowards = Quaternion.FromToRotation(aimDirection, targetDirection);
        // Calculate the influence of the weight to the rotation
        Quaternion blendedRotation = Quaternion.Slerp(Quaternion.identity, aimTowards, weight);
        // Apply the rotation 
        bone.rotation = blendedRotation * bone.rotation;
    }

    public void SetTargetTransform(Transform target){
        targetTransform = target;
    }
    public void SetAimTransform(Transform aim){
        aimTransform = aim;
    }
    // public void GetFireScript(CopsFireWeapon copsFire){
    //     fireWeapon = copsFire;
    // }
}
