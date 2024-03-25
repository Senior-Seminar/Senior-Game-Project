using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class CavernTorchController : MonoBehaviour
{
    Tilemap PuzzleTiles_TileMap;
    private TileBase triggerTile;
    private Light2D Torch_7;
    GameObject[] spotlights;

    // Start is called before the first frame update
    void Start()
    {
        //set Trigger Tile
        GameObject pleasework = GameObject.FindGameObjectWithTag("CavernPuzzleTile");
        PuzzleTiles_TileMap = pleasework.GetComponent<Tilemap>();
        Vector3Int triggerTilePosition = new Vector3Int(24,-19,0);
        triggerTile = PuzzleTiles_TileMap.GetTile(triggerTilePosition);

        //Set Torch_7 spotlight
        spotlights = GameObject.FindGameObjectsWithTag("Spotlight");
        Torch_7 = spotlights[0].GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Get Cell player is currently on
        Vector3 playerPosition = transform.position;
        Vector3Int playerCell = PuzzleTiles_TileMap.WorldToCell(playerPosition);

        //if player is on Trigger Tile, update Torch_7 spotlight
        if(PuzzleTiles_TileMap.GetTile(playerCell) == triggerTile) {
            //Debug.Log("its working!");
            Torch_7.pointLightInnerRadius = 0.5f;
            Torch_7.pointLightOuterRadius = 1;
        }
    }
}
