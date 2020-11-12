using UnityEngine;
using System.Collections;

public class MapGenerator 
{
    public MapTile[,] GenerateMap(int width, int height)
    {
        MapTile[,] mapTiles = new MapTile[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                MapTile mapTile = new MapTile();
                mapTile.Type = MapTile.TileType.Grass;
                mapTiles[x, y] = mapTile;
            }
        }
        return mapTiles;
    }
}
