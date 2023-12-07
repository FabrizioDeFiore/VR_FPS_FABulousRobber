using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSockets : MonoBehaviour
{
    public enum SocketId{
        RightHand
    }
    Dictionary<SocketId, MeshSocket> socketMap = new Dictionary<SocketId, MeshSocket>();
    // Start is called before the first frame update
    void Awake()
    {
        // Get all the sockets attachet to the cop (in case I want to add more)
        MeshSocket[] sockets = GetComponentsInChildren<MeshSocket>();
        foreach (var socket in sockets){
            socketMap[socket.socketId] = socket;
        }
    }

    public void Attach(Transform objectTransform, SocketId socketId){
        // Find the right socket and call his specific function
        socketMap[socketId].Attach(objectTransform);
    }
}
