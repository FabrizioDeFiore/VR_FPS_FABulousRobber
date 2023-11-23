using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class SafeRoomDoor : MonoBehaviour
{
    public GameObject door; 
    public GameObject bomb;
    private XRSocketInteractor bombSocket;
    // Start is called before the first frame update
    void Start()
    {
        bombSocket = GetComponent<XRSocketInteractor>();
        bombSocket.selectEntered.AddListener(OnSocketEntered);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSocketEntered(SelectEnterEventArgs args){
        Invoke("OpenDoor", 3.0f);
    }
    public void OpenDoor(){
        door.transform.rotation = Quaternion.Euler(0, 60, 0);
        bomb.SetActive(false);
    }
}
