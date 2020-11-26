using UnityEngine;
using System.Collections;

public abstract class UnitComponent
{
    protected readonly Unit Unit;

    public UnitComponent(Unit unit)
    {
        Unit = unit;
    }
}
