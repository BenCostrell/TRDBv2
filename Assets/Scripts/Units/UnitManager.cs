using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager
{
    private List<Unit> units = new List<Unit>();

    public Unit SpawnUnit(BaseUnitData unitData, List<UnitComponent> unitComponents)
    {
        Unit unit = new Unit(unitData, unitComponents);
        units.Add(unit);
        return unit;
    }

    public void DestroyUnit(Unit unit)
    {
        units.Remove(unit);
    }
}
