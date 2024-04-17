using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour {

    public GameObject titleText;
    public GameObject mainMenuObject;
    private string filePath;
    private GameData savedGameData;
   

	public void Start()
	{
		Flicker();
        filePath = "C:/Users/mdami/OneDrive/Desktop/Senior-Game-Project/GameData/saveData.json";
	}

   public void NewGame ()
   {
	   SceneManager.LoadScene("AreaOne(2)");
   }

   public void LoadGame()
    {
        if (File.Exists(filePath))
        {
            Debug.Log("Loading Saved Game From: " + filePath);
            string jsonData = File.ReadAllText(filePath);
            savedGameData = JsonUtility.FromJson<GameData>(jsonData);

            if (savedGameData != null)
            {
                // Subscribe to the sceneLoaded event
                SceneManager.sceneLoaded += OnSceneLoaded;

                // Load the scene
                SceneManager.LoadScene(savedGameData.Scene);
            }
            else
            {
                Debug.Log("No saved game data found");
            }
        }
        else
        {
            Debug.Log("No saved game found");
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("CurrentScene = " + scene.name);

        SceneManager.sceneLoaded -= OnSceneLoaded;

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Vector3 savedPosition = new Vector3(savedGameData.Position[0],
            savedGameData.Position[1], savedGameData.Position[2]);
            player.transform.position = savedPosition;
        }
        else
        {
            Debug.Log("Player object not found in scene");
        }
         CoinCounter coinCounter = CoinCounter.instance;
        if (coinCounter != null)
        {
            coinCounter.currentCoins = savedGameData.Coins;
        }
        else
        {
            Debug.Log("CoinCounter instance not found.");
        }
    }

/*   public void LoadGame ()
   {
       
	   string filePath = "C:/Users/mdami/OneDrive/Desktop/Senior-Game-Project/GameData/saveData.json";
       if(File.Exists(filePath))
       {
           Debug.Log("Loading Saved Game From: " + filePath);
           string jsonData = File.ReadAllText(filePath);
           GameData savedGameData = JsonUtility.FromJson<GameData>(jsonData);

           if(savedGameData != null)
           {
               SceneManager.sceneLoaded += OnSceneLoaded;
               SceneManager.LoadScene(savedGameData.Scene);

               Debug.Log("CurrentScene = " + SceneManager.GetActiveScene().name);
               player = GameObject.FindGameObjectWithTag("Player");
               if(player != null)
               {
                   Vector3 savedPosition = new Vector3(savedGameData.Position[0], savedGameData.Position[1], savedGameData.Position[2]);
                   player.transform.position = savedPosition;

               }
               else
               {
                   Debug.Log("Player object not found in scene");
               }

               CoinCounter coinCounter = CoinCounter.instance;
               if(coinCounter != null)
               {
                   coinCounter.currentCoins = savedGameData.Coins;
               }
               else
               {
                   Debug.Log("CoinCounter instance not found.");
               }
           }
           else
           {
               Debug.Log("No saved game data found");
           }
       }
       else
       {
           Debug.Log("No saved game found");
       }
   }
   */
   public void Quit ()
   {
	   Application.Quit();
	   Debug.Log("QUIT!");
   }

   public void Flicker()
    {
        StartCoroutine(FlickerCoroutine());
    }

    IEnumerator FlickerCoroutine()
    {
        while (mainMenuObject.activeSelf)
        {
            titleText.SetActive(false); 
            yield return new WaitForSeconds(0.2f); 
            titleText.SetActive(true); 
            yield return new WaitForSeconds(0.2f); 
        }
    }
}
