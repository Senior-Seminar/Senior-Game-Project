using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject player;
    private Animator playerAnimator;
    public GameObject deathScreenPrefab;
    private GameObject deathScreenInstance;
    public MainMenu mainMenu;

    void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
    }

    void Update()
    {
        if (!playerAnimator.GetBool("isAlive"))
        {
            deathScreenInstance = Instantiate(deathScreenPrefab, Vector3.zero, Quaternion.identity);
            Time.timeScale = 0;
            Debug.Log("You Died");
            deathScreenInstance.SetActive(true);
            mainMenu.LoadGame();
        }
    }
    public GameObject gameOverCanvas;

    // This function is called when the player finds the son
    void FoundSon()
    {
        // Check if the player makes contact with a GameObject named "SonPlayer"
        GameObject sonPlayer = GameObject.Find("SonPlayer");



        if (sonPlayer != null && sonPlayer.CompareTag("Player"))
        {
            // Display the game over canvas
            if (gameOverCanvas != null)
            {
                gameOverCanvas.SetActive(true);
            }
            
            // Load the main menu scene
            SceneManager.LoadScene("mainMenu");
        }
    }
}
