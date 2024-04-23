using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string Scene;
    public float Health;
    public int Coins;
    public float[] Position;
    public List<Item> Inventory;

    public GameData(string scene, int coins, float[] position, List<Item> items)
    {
        Scene = scene;
        Health = 3;
        Coins = coins;
        Position = position;
        Inventory = items;
    }

    public GameData(string scene, int coins, float[] position)
    {
        Scene = scene;
        Health = 3;
        Coins = coins;
        Position = position;
        Inventory = null;
    }


}
