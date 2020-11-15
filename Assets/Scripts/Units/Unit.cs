using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit 
{
    public Vector2Int centerCoordinate { get; private set; }
    public BaseUnitData baseUnitData { get; private set; }
    private List<UnitComponent> unitComponents;

    public Unit(BaseUnitData baseUnitData, List<UnitComponent> unitComponents)
    {
        this.baseUnitData = baseUnitData;
        this.unitComponents = unitComponents;
    }

    public void PlaceOnMap(Vector2Int coordinate)
    {
        centerCoordinate = coordinate;
        Services.EventManager.Fire(new UnitPlacedOnMap(this));
    }

    public UnitComponent GetUnitComponent<T>()
    {
        foreach (UnitComponent unitComponent in unitComponents)
        {
            if (unitComponent is T)
            {
                return unitComponent;
            }
        }
        return null;
    }

    public void AddUnitComponent(UnitComponent unitComponent)
    {
        unitComponents.Add(unitComponent);
    }
}

public class UnitPlacedOnMap : Event
{
    public readonly Unit unit;

    public UnitPlacedOnMap(Unit unit)
    {
        this.unit = unit;
    }
}
