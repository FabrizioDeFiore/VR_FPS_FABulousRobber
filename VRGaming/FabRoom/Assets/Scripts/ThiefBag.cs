using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class ThiefBag : MonoBehaviour
{
    public GameObject bagFullOfItems; 
    public GameObject bagFullOfMoney; 
    public GameObject bagEmptyOpened; 
    private XRSocketInteractor bagSocket;
    public GameObject rifle;
    public GameObject bomb;
    //public List<Transform> sockets;
    public List<GameObject> moneys;
    private Quaternion bagRotation = Quaternion.Euler(0, 90, 0);
    private int moneyStolen = 0;
    private GameObject newBag;
    public GameObject rats;
    public Canvas tip2;
    public Canvas tip4;
    public GameObject cop1;
    public GameObject cop2;
    public GameObject cop3;
    public GameObject cop4;
    public GameObject cop5;

    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    public Transform spawnPoint5;




    // Start is called before the first frame update
    void Start(){
        bagSocket = GetComponent<XRSocketInteractor>();
        bagSocket.selectEntered.AddListener(OnSocketEntered);

    }

    // Update is called once per frame
    void Update(){
        
    }
    
    private void OnSocketEntered(SelectEnterEventArgs args){
        // replace it with the empty one
        Invoke("ReplaceBag", 0.5f);
        
    }

    public void ReplaceBag(){
        // Get the position of the bag
        Vector3 bagPosition = bagFullOfItems.transform.position;
        // Disable the bag
        bagFullOfItems.SetActive(false);
        // Instantiate the new bag at the same position and rotation
        newBag = Instantiate(bagEmptyOpened, bagPosition, bagRotation);
        // Drop the items from the bag
        rifle.SetActive(true);
        bomb.SetActive(true);
        tip2.gameObject.SetActive(true);
    }

    public void FillBag(){
        Vector3 bagPosition = newBag.transform.position;
        // Disable the bag and the money
        newBag.SetActive(false);
        foreach (GameObject money in moneys){
            money.SetActive(false);
        }
        // Instantiate the new bag at the same position and rotation
        GameObject filledBag = Instantiate(bagFullOfMoney, bagPosition, bagRotation);
        tip4.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other){
        // If player place a money note on the socket 
        if (other.CompareTag("Money")) {
            // Update counter
            moneyStolen++;
            // If all sockets have a money note attached
            if (moneyStolen == 4){
                Debug.Log("Good job you stole all the money!");
                // Replace the bag woth the one full of money
                Invoke("FillBag", 1f);
                moneyStolen = 0;
                // Spawn the cops outside of the bank
                rats.SetActive(true);
                Invoke("SpawnCops", 8f);
                
            }
        }
    }

    private void OnTriggerExit(Collider other){
        // If a money note is removed from the socket update the counter
        if (other.CompareTag("Money")){
            moneyStolen--;
        }
    }
    
    private void SpawnCops(){
        // Instantiate cops triggered by allarm 
        Instantiate(cop1, spawnPoint1.position, spawnPoint1.rotation);
        Instantiate(cop2, spawnPoint2.position, spawnPoint2.rotation);
        Instantiate(cop3, spawnPoint3.position, spawnPoint3.rotation);
        Instantiate(cop4, spawnPoint4.position, spawnPoint4.rotation);
        Instantiate(cop5, spawnPoint5.position, spawnPoint5.rotation);

    }
        
}


    // private bool AllMoneySocketsAreOccupied(){
    //     // Create a counter for the money stolen
    //     int moneyStolen = 0;
    //     // Increment it by one every time a money note became a child of one of the sockets)
    //     foreach (Transform socket in sockets){
    //         if(MoneySocketIsOccupied(socket)){
    //             moneyStolen++;
    //             Debug.Log("Filled ++");
    //         }
    //     }
    //     // return true if the money stolen are the same of the sockets number in the list
    //     return moneyStolen == sockets.Count;
    // }

    // private bool MoneySocketIsOccupied(Transform socket)
    // {
    //     // Check if the socket has a component with the required tag.
    //     return socket.GetComponentInChildren<Component>().CompareTag(moneyTag);
    // }