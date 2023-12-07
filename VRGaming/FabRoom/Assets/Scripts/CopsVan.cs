using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CopsCar : MonoBehaviour
{
    private XRSocketInteractor socket;
    public GameObject doorLeftOpen;
    public GameObject doorLeftClosed;

    public GameObject doorRightOpen;
    public GameObject doorRightClosed;
    private AudioSource doorClose;


    // Start is called before the first frame update
    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
        socket.selectEntered.AddListener(OnSocketEntered);
        doorClose = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnSocketEntered(SelectEnterEventArgs args){
        Invoke("CloseDoors", 2.0f);
    }
    public void CloseDoors(){
        doorLeftOpen.SetActive(false);
        doorRightOpen.SetActive(false);
        doorLeftClosed.SetActive(true);
        doorRightClosed.SetActive(true);
        doorClose.Play();

    }
}
