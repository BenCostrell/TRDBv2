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

    public UnitComponent GetUnitComponent()
    {
        switch (componentName)
        {
            // return the proper component with parameters plugged in
            default:
                return null;
        }
    }
}
