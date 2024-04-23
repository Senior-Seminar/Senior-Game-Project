using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.IO;

public class OptionsMenuController : MonoBehaviour
{
    public GameObject optionsMenuPrefab;
    private GameObject optionsMenuInstance;
    private bool isPaused = false;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
                OpenOptionsMenu();
            }
            else
            {
                CloseOptionsMenu();
                ResumeGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    void OpenOptionsMenu()
     {
        optionsMenuInstance = Instantiate(optionsMenuPrefab, Vector3.zero, Quaternion.identity);
        Debug.Log("Opening options menu...");
        optionsMenuInstance.SetActive(true);
    }

    void CloseOptionsMenu()
    {
        if (optionsMenuInstance != null)
        {
            Destroy(optionsMenuInstance);
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SaveGame()
    {
        Debug.Log("Saving Game...");
        string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        //int coins = CoinCounter.instance.currentCoins;
        float[] position = new float[3];
        position[0] = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        position[1] = GameObject.FindGameObjectWithTag("Player").transform.position.y;
        position[2] = GameObject.FindGameObjectWithTag("Player").transform.position.z;
        List<Item> items = new List<Item>();
        GameData gameData;
        Inventory inventory = Inventory.instance;
        if(inventory != null && inventory.items != null)
        {
            items = inventory.items;
            gameData = new GameData(currentScene, 0, position, items);
        }
        
        gameData = new GameData(currentScene, 0, position);
        

        string jsonData =JsonUtility.ToJson(gameData);

        string filePath = "C:/Users/mdami/OneDrive/Desktop/Senior-Game-Project/GameData/saveData.json";
        File.WriteAllText(filePath, jsonData);
        Debug.Log("Saved game to : " + filePath + jsonData);
    }
}
