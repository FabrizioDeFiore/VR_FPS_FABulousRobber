using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSocket : MonoBehaviour
{
    public MeshSockets.SocketId socketId;
    public HumanBodyBones bone;
    public Vector3 offset;
    public Vector3 rotation;

    public Transform attachPoint;
    // Start is called before the first frame update
    void Awake()
    {
        // Get transform position of the children (offset object)
        //attachPoint = transform.GetChild(0);
        Animator animator = GetComponentInParent<Animator>();
        // Create a new attach point 
        attachPoint = new GameObject("socket" + socketId).transform;
        // Set is as parent
        attachPoint.SetParent(animator.GetBoneTransform(bone));
        // Update rotation and offset from the inspector
        attachPoint.localPosition = offset;
        attachPoint.localRotation = Quaternion.Euler(rotation);
    }

    // Update is called once per frame
    public void Attach(Transform objectTransform){
        // Set the transform parent to the attach point
        objectTransform.SetParent(attachPoint, false);
    }
}
