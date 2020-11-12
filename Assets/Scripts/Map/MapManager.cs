using UnityEngine;
using System.Collections;

public class MapManager 
{
    public MapTile[,] MapTiles { get; private set; }

    public void CreateMap(int width, int height)
    {
        MapGenerator mapGenerator = new MapGenerator();
        MapTiles = mapGenerator.GenerateMap(width, height);
    }
}
