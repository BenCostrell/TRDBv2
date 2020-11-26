using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit 
{
    public Vector2Int centerCoordinate { get; private set; }
    public BaseUnitData baseUnitData { get; private set; }
    private List<UnitComponent> unitComponents;

    public Unit(BaseUnitData baseUnitData)
    {
        this.baseUnitData = baseUnitData;
        unitComponents = baseUnitData.GetUnitComponents(this);
    }

    public void PlaceOnMap(Vector2Int coordinate)
    {
        centerCoordinate = coordinate;
        Services.EventManager.Fire(new UnitPlacedOnMap(this));
    }

    public void RemoveFromMap()
    {
        centerCoordinate = new Vector2Int(-1, -1);
        Services.EventManager.Fire(new UnitRemovedFromMap(this));
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

public class UnitRemovedFromMap : Event
{
    public readonly Unit unit;

    public UnitRemovedFromMap(Unit unit)
    {
        this.unit = unit;
    }
}