using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject titleText;
    public GameObject sonText;
    public GameObject sonTextDown;
    public GameObject mainMenuObject;

	public void Start()
	{
		Flicker();
	}

   public void NewGame ()
   {
	   SceneManager.LoadScene("SampleScene");
   }

   public void LoadGame ()
   {
	   SceneManager.LoadScene("SampleScene");
   }

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
            sonText.SetActive(false);
            sonTextDown.SetActive(false);
            yield return new WaitForSeconds(0.2f); 
            titleText.SetActive(true); 
            sonText.SetActive(false);
            sonTextDown.SetActive(false);
            yield return new WaitForSeconds(0.2f); 
        }
    }
}
