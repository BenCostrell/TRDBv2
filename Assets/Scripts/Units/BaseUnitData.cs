using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseUnitData 
{
    public readonly string Name;
    public readonly string Description;
    public readonly Vector2Int Size;
    public readonly Sprite Sprite;
    private readonly List<UnitComponentFactory> UnitComponentFactories;

    public BaseUnitData(string name, string description, Vector2Int size, Sprite sprite, 
        List<UnitComponentFactory> unitComponentFactories)
    {
        Name = name;
        Description = description;
        Size = size;
        Sprite = sprite;
        UnitComponentFactories = unitComponentFactories;
    }

    public List<UnitComponent> GetUnitComponents()
    {
        List<UnitComponent> unitComponents = new List<UnitComponent>();
        foreach(UnitComponentFactory unitComponentFactory in UnitComponentFactories)
        {
            UnitComponent unitComponent = unitComponentFactory.GetUnitComponent();
            unitComponents.Add(unitComponent);
        }
        return unitComponents;
    }
}
