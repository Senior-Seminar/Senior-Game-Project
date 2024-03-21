using UnityEngine;
using UnityEngine.SceneManagement;

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
}
