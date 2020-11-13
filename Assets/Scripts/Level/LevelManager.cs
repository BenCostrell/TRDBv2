using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    private MapManager mapManager;
    private MapRenderer mapRenderer;
    private CameraController cameraController;

    // for now, constant map size
    private const int width = 10;
    private const int height = 7;

    private void Awake()
    {
        mapRenderer = GetComponentInChildren<MapRenderer>();
        cameraController = GetComponentInChildren<CameraController>();
        Services.EventManager = new EventManager();
    }

    void Start()
    {
        mapManager = new MapManager();
        mapManager.CreateMap(width, height);
        mapRenderer.RenderMap(mapManager.MapTiles);
        cameraController.CenterCamera(width, height);
    }
}
