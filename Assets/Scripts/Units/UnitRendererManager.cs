using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRendererManager : MonoBehaviour
{
    private UnitRenderer unitRendererPrefab;
    private List<UnitRenderer> unitRenderers = new List<UnitRenderer>();

    private void Awake()
    {
        unitRendererPrefab = Resources.Load<UnitRenderer>("Prefabs/UnitRenderer");
    }

    public void Setup()
    {
        Services.EventManager.Register<UnitPlacedOnMap>(OnUnitPlaced);
    }

    private void OnUnitPlaced(UnitPlacedOnMap e)
    {
        CreateUnitRenderer(e.unit);
    }

    public void CreateUnitRenderer(Unit unit)
    {
        UnitRenderer unitRenderer = Instantiate(unitRendererPrefab, transform);
        unitRenderer.Setup(unit);
        unitRenderers.Add(unitRenderer);
    }
}
