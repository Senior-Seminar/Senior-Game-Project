using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CavernTorchController : MonoBehaviour
{
    Tilemap PuzzleTiles_TileMap;
    private TileBase[] triggerTiles = new TileBase[2];
    private Light2D[] torch_spotlights = new Light2D[11];

    // Start is called before the first frame update
    void Start()
    {
        //set trigger tiles (that are not buggy)
        GameObject pleasework = GameObject.FindGameObjectWithTag("CavernPuzzleTile");
        PuzzleTiles_TileMap = pleasework.GetComponent<Tilemap>();
        triggerTiles[0] = PuzzleTiles_TileMap.GetTile(new Vector3Int(21,-5,0));
        triggerTiles[1] = PuzzleTiles_TileMap.GetTile(new Vector3Int(24,-19,0));

        //Set torch spotlights
        GameObject[] spotlights = spotlights = GameObject.FindGameObjectsWithTag("Spotlight");
        for(int i = 0; i < torch_spotlights.Length; i++) {
            torch_spotlights[i] = spotlights[i].GetComponent<Light2D>();
        }
   
        // Sort spotlights based on their name
        torch_spotlights = torch_spotlights.OrderBy(torch_spotlights => int.Parse(torch_spotlights.name.Substring("Torch_".Length))).ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        //Get cell player is currently on
        UnityEngine.Vector3 playerPosition = transform.position;
        Vector3Int playerCell = PuzzleTiles_TileMap.WorldToCell(playerPosition);

        //if player is on tigger tile, update appropriate torch spotlights
        TileBase playerTile = PuzzleTiles_TileMap.GetTile(playerCell);
        Vector3Int tolerance = new Vector3Int(1, 1, 0); 
        Vector3Int[] tileCoordinates = new Vector3Int[] { //for tiles that are buggy
            new Vector3Int(25,-27,0),  
            new Vector3Int(30,-46,0), 
            new Vector3Int(43,-42,0), 
            new Vector3Int(47,-36,0), 
            new Vector3Int(68,-38,0) };
        if(playerTile == triggerTiles[0]) {
            UnityEngine.Debug.Log("first tile");
             torch_spotlights[0].pointLightInnerRadius = 1;
             torch_spotlights[0].pointLightOuterRadius = 3;             
        }
        else if(playerTile == triggerTiles[1]) {
            UnityEngine.Debug.Log("second tile");
             torch_spotlights[1].pointLightInnerRadius = 0.5f;
             torch_spotlights[1].pointLightOuterRadius = 1;
             torch_spotlights[2].pointLightInnerRadius = 0.5f;
             torch_spotlights[2].pointLightOuterRadius = 1;
        }
        else if(Vector3Int.Distance(playerCell, tileCoordinates[0]) < tolerance.magnitude) {
            UnityEngine.Debug.Log("third tile");
             torch_spotlights[3].pointLightInnerRadius = 0.5f;
             torch_spotlights[3].pointLightOuterRadius = 1;
             torch_spotlights[4].pointLightInnerRadius = 0.5f;
             torch_spotlights[4].pointLightOuterRadius = 1;
        }
        else if(Vector3Int.Distance(playerCell, tileCoordinates[1]) < tolerance.magnitude) {
            UnityEngine.Debug.Log("fourth");
            torch_spotlights[5].pointLightInnerRadius = 1;
            torch_spotlights[5].pointLightOuterRadius = 3;
        }
        else if(Vector3Int.Distance(playerCell, tileCoordinates[2]) < tolerance.magnitude) {
            UnityEngine.Debug.Log("fifth");
            torch_spotlights[6].pointLightInnerRadius = 1;
            torch_spotlights[6].pointLightOuterRadius = 3;
        }
        else if(Vector3Int.Distance(playerCell, tileCoordinates[3]) < tolerance.magnitude) {
            torch_spotlights[7].pointLightInnerRadius = 1;
            torch_spotlights[7].pointLightOuterRadius = 3;
        }
        else if(Vector3Int.Distance(playerCell, tileCoordinates[4]) < tolerance.magnitude) {
            UnityEngine.Debug.Log("sixth");
            torch_spotlights[8].pointLightInnerRadius = 1;
            torch_spotlights[8].pointLightOuterRadius = 3;
            torch_spotlights[9].pointLightInnerRadius = 0.5f;
            torch_spotlights[9].pointLightOuterRadius = 1;
            torch_spotlights[10].pointLightInnerRadius = 1;
            torch_spotlights[10].pointLightOuterRadius = 3;            
        }
    }
}
