using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public Canvas winningMessage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Congratulation you win");
        // Pause the game 
        Time.timeScale = 0;
        // Display winning message 
        winningMessage.gameObject.SetActive(true);

    }
}
