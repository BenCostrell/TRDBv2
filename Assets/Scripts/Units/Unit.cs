using UnityEngine;
using System.Collections;

public class Unit 
{
    public Vector2Int centerCoordinate { get; private set; }
    public BaseUnitData baseUnitData { get; private set; }

    public Unit(BaseUnitData baseUnitData)
    {
        this.baseUnitData = baseUnitData;
    }

    public void PlaceOnMap(Vector2Int coordinate)
    {
        centerCoordinate = coordinate;
        Services.EventManager.Fire(new UnitPlacedOnMap(this));
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
