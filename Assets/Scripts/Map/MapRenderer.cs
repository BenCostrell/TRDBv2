using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapRenderer : MonoBehaviour
{
    private Tilemap tilemap;
    public TileDataManager TileDataManager;

    void Awake()
    {
        tilemap = GetComponentInChildren<Tilemap>();
    }

    public void RenderMap(MapTile [,] mapTiles)
    {
        Dictionary<MapTile.TileType, Tile> tileDataDict = new Dictionary<MapTile.TileType, Tile>();
        for (int x = 0; x < mapTiles.GetLength(0); x++)
        {
            for (int y = 0; y < mapTiles.GetLength(1); y++)
            {
                MapTile mapTile = mapTiles[x, y];
                if (!tileDataDict.ContainsKey(mapTile.Type))
                {
                    TileData tileData = TileDataManager.GetTileData(mapTile.Type);
                    tileDataDict.Add(mapTile.Type, tileData.Tile);
                }
                Tile tile = tileDataDict[mapTile.Type];
                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }
    
}
