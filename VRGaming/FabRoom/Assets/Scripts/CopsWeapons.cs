using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopsWeapons : MonoBehaviour
{
    public GameObject weapon;
    public GameObject currentWeapon;
    MeshSockets sockets;
    public MeshSocket socket;
    WeaponIk weaponIk;
    Transform currentTarget;

    private void Start(){
        //HitBox hitbox = GetComponent<HitBox>();
        //CopsWeapons weapons = hitbox.health.GetComponent<CopsWeapons>();
        sockets = GetComponent<MeshSockets>();
        socket = GetComponentInChildren<MeshSocket>();
        weaponIk = GetComponent<WeaponIk>();
        // Instantiate the weapon
        GameObject newWeapon = Instantiate(weapon);
        Equip(newWeapon);
    }

    public void Equip(GameObject weapon){
        currentWeapon = weapon;
        // Attach the weapon to the socket by his Id
        sockets.Attach(weapon.transform, MeshSockets.SocketId.RightHand);
        // Parenting the weapon to the cop transform 
        //currentWeapon.transform.SetParent(transform, false);
    }

    public void ActivateWeapon(){
        // Pass the aim transform (where the bullet are instantiated) to the scrip that manage the aiming
        weaponIk.SetAimTransform(currentWeapon.GetComponentInChildren<Transform>());
    }


    public void OnAnimationEvent(string eventName){
        // Check if the string parameter is the one setted up throug the inspector(if is the run animation)
        if (eventName == "rotateWeaponForRun"){
            Debug.Log("OnAnimationEvent1 called");
            // CHange position and rotation of the weapon so that it matches with the animation
            Vector3 newPosition = new Vector3(0.107f, 0.044f, -0.022f);
            Quaternion newRotation = Quaternion.Euler(-3.876f, 99.277f, -102.418f);
            socket.attachPoint.localPosition = newPosition;
            socket.attachPoint.localRotation = newRotation;
        }
        if (eventName == "rotateWeaponForIdle"){
            Debug.Log("OnAnimationEvent2 called");
            // CHange position and rotation of the weapon so that it matches with the animation
            Vector3 newPosition = new Vector3(0.094f, 0.061f, -0.02f);
            Quaternion newRotation = Quaternion.Euler(-35.822f, 33.843f, -49.085f);
            socket.attachPoint.localPosition = newPosition;
            socket.attachPoint.localRotation = newRotation;
        }
        if (eventName == "rotateWeaponForAimingRun"){
            Debug.Log("OnAnimationEvent3 called");
            // CHange position and rotation of the weapon so that it matches with the animation
            Vector3 newPosition = new Vector3(0.139f, -0.003f, -0.008f);
            Quaternion newRotation = Quaternion.Euler(-2.769f, 35.213f, -112.604f);
            socket.attachPoint.localPosition = newPosition;
            socket.attachPoint.localRotation = newRotation;
        }
    
    }

    public void DropWeapon(){
        // Enable physics to weapon so it's been droppped to the ground
        // Chek if we have a current weapon
        if (currentWeapon){
            // Create a parent 
            currentWeapon.transform.SetParent(null);
            // Enable the collider
            currentWeapon.gameObject.GetComponent<BoxCollider>().enabled = true;
            // Add a rigidbody 
            currentWeapon.gameObject.AddComponent<Rigidbody>();
            // Remove current weapon from the cop 
            currentWeapon = null;
        }
    }

    public void SetTarget(Transform target){
        weaponIk.SetTargetTransform(target);
        currentTarget = target;
    }
    


}
