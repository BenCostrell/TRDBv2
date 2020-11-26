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
        Services.EventManager.Register<UnitRemovedFromMap>(OnUnitRemoved);
    }

    private void OnUnitPlaced(UnitPlacedOnMap e)
    {
        CreateUnitRenderer(e.unit);
    }

    private void OnUnitRemoved(UnitRemovedFromMap e)
    {
        UnitRenderer removedRenderer = null;
        foreach(UnitRenderer unitRenderer in unitRenderers)
        {
            if(unitRenderer.unit == e.unit)
            {
                removedRenderer = unitRenderer;
                break;
            }
        }
        if(removedRenderer != null)
        {
            unitRenderers.Remove(removedRenderer);
            removedRenderer.OnRemoval();
        }
    }

    public void CreateUnitRenderer(Unit unit)
    {
        UnitRenderer unitRenderer = Instantiate(unitRendererPrefab, transform);
        unitRenderer.Setup(unit);
        unitRenderers.Add(unitRenderer);
    }
}
