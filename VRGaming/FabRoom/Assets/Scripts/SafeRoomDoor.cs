using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class SafeRoomDoor : MonoBehaviour
{
    public GameObject door; 
    public GameObject bomb;
    private XRSocketInteractor bombSocket;
    public GameObject cop1;
    public GameObject cop2;
    public GameObject cop3;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public AudioSource bombExplosion;
    public AudioSource alarm;
    public AudioSource timer;




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
        // Open door 
        Invoke("OpenDoor", 3.0f);
        timer.Play();
        

    }
    public void OpenDoor(){
        door.transform.rotation = Quaternion.Euler(0, 60, 0);
        bomb.SetActive(false);
        bombExplosion.Play();
        // Instantiate cops triggered by allarm 
        Invoke("SpawnCops", 1.0f);
    }
    private void SpawnCops(){
        Instantiate(cop1, spawnPoint1.position, spawnPoint1.rotation);
        Instantiate(cop2, spawnPoint2.position, spawnPoint2.rotation);
        Instantiate(cop3, spawnPoint3.position, spawnPoint3.rotation);
        alarm.Play();
    }

    
}
