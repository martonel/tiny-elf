using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
 
    public int levelNumber = 1;
    public bool[] stars;
    public bool[] items;

    public GameData(Data data)
    {
        levelNumber = data.levelNumber;
        stars = data.stars;
        items = data.items;
    }

}
