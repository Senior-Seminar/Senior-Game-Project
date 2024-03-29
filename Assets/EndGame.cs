using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject endGameMenu;
    public CharacterDamageable damageable;
    // Start is called before the first frame update
    void Start()
    {
        if (damageable == null)
        {
            Debug.LogError("CharacterDamageable is not assigned to EndGame script.");
        }
        else
        {
            endGameMenu.SetActive(false);
        }
    }

    public void PlayerDeath()
    {
        if (damageable != null && damageable.Health <= 0)
        {
            StartCoroutine(ShowEndGameMenuAfterDelay(3f));
        }
    }

    IEnumerator ShowEndGameMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        endGameMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
