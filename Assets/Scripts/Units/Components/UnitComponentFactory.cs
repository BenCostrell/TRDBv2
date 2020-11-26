using UnityEngine;
using System.Collections;
using System.Collections.Generic;

    public class UnitComponentFactory
{
    private readonly string componentName;
    private readonly string[] componentParameterStrings;

    public UnitComponentFactory(string componentName, string[] componentParameterStrings)
    {
        this.componentName = componentName;
        this.componentParameterStrings = componentParameterStrings;
    }

    public UnitComponent GetUnitComponent(Unit unit)
    {
        switch (componentName.Trim().ToUpper())
        {
            case "HITPOINTS":
                int maxHP;
                int.TryParse(componentParameterStrings[0], out maxHP);
                return new HitPoints(unit, maxHP);
            default:
                return null;
        }
    }
}
