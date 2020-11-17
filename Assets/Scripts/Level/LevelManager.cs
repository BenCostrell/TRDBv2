using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    private MapManager mapManager;
    private MapRenderer mapRenderer;
    private UnitRendererManager unitRendererManager;
    private CameraController cameraController;
    private UnitDataManager unitDataManager;
    private UnitManager unitManager;

    // for now, constant map size
    private const int width = 10;
    private const int height = 7;

    private void Awake()
    {
        mapRenderer = GetComponentInChildren<MapRenderer>();
        cameraController = GetComponentInChildren<CameraController>();
        unitRendererManager = GetComponentInChildren<UnitRendererManager>();
        unitDataManager = GetComponentInChildren<UnitDataManager>();
        Services.EventManager = new EventManager();
        unitManager = new UnitManager();
    }

    void Start()
    {
        mapManager = new MapManager();
        mapManager.CreateMap(width, height);
        mapRenderer.RenderMap(mapManager.MapTiles);
        unitRendererManager.Setup();
        Vector2Int playerSpawnPoint = new Vector2Int(0, 0);
        cameraController.MoveCameraToCoord(playerSpawnPoint);
        Unit player = unitManager.SpawnUnit(unitDataManager.GetUnitData("Player"));
        player.PlaceOnMap(playerSpawnPoint);
    }
}
