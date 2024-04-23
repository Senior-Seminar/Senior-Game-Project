using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject canvas;
    public GameObject finishedDialog;
    public GameObject unfinishedDialog;

    public void Start()
    {
        finishedDialog.SetActive(false);
        unfinishedDialog.SetActive(false);
    }


   private void OnTriggerEnter2D(Collider2D other)
   {
        if (other.CompareTag("Player"))
        {
            CoinCounter coinCounter = FindObjectOfType<CoinCounter>();
            canvas.SetActive(true);
            if (coinCounter.GetCoins() >= 10)
            {
                finishedDialog.SetActive(true);
            }
            else
            {
                unfinishedDialog.SetActive(true);
            }
        }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
        if (other.CompareTag("Player"))
        {
            CoinCounter coinCounter = FindObjectOfType<CoinCounter>();
            CaveEntranceController caveController = FindObjectOfType<CaveEntranceController>();
            if (coinCounter.GetCoins() >= 10)
            {
                coinCounter.IncreaseCoins(-10);
                caveController.OpenCaveEntrance();
            }
            canvas.SetActive(false);
            finishedDialog.SetActive(false);
            unfinishedDialog.SetActive(false);
        }
   }
}