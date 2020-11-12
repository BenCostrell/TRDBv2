using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "TileDataManager", menuName = "ScriptableObjects/TileDataManager")]
public class TileDataManager : ScriptableObject
{
    public TileData[] TileDatas;

    public TileData GetTileData(MapTile.TileType tileType)
    {
        foreach(TileData tileData in TileDatas)
        {
            if (tileData.TileType == tileType) return tileData;
        }
        Debug.Assert(false, "Tile Data for type " + tileType + " not found.");
        return null;
    }
}
