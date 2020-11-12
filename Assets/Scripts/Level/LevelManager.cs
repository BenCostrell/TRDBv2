using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    private MapManager mapManager;
    private MapRenderer mapRenderer;

    // for now, constant map size
    private const int width = 8;
    private const int height = 6;

    private void Awake()
    {
        mapRenderer = GetComponentInChildren<MapRenderer>();
    }

    void Start()
    {
        mapManager = new MapManager();
        mapManager.CreateMap(width, height);
        mapRenderer.RenderMap(mapManager.MapTiles);
    }
}
