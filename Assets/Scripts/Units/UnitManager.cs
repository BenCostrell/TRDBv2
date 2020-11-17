using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager
{
    private List<Unit> units = new List<Unit>();

    public Unit SpawnUnit(BaseUnitData unitData)
    {
        Unit unit = new Unit(unitData);
        units.Add(unit);
        return unit;
    }

    public void DestroyUnit(Unit unit)
    {
        units.Remove(unit);
    }
}
