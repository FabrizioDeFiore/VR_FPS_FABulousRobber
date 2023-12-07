using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public Canvas winningMessage;
    private AudioSource gameWinSound;
    // Start is called before the first frame update
    void Start()
    {
        gameWinSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Congratulation you win");
            gameWinSound.Play();
            // Pause the game 
            Time.timeScale = 0;
            // Display winning message 
            winningMessage.gameObject.SetActive(true);
        }
    }
}
