using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CaveEntranceController : MonoBehaviour
{
    public Tilemap closedCavern;
    public Tilemap openCavern;
    public Tilemap cavernEntrance;

    void Start()
    {
        closedCavern.gameObject.SetActive(true);
        openCavern.gameObject.SetActive(false);
        cavernEntrance.gameObject.SetActive(false);
    }

    public void OpenCaveEntrance()
    {
        closedCavern.gameObject.SetActive(false);
        openCavern.gameObject.SetActive(true);
        cavernEntrance.gameObject.SetActive(true);
    }
}
