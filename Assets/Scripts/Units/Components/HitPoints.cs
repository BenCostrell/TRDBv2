using UnityEngine;
using System.Collections;

public class HitPoints : UnitComponent
{
    private int maxHP;
    private int currentHP;

    public HitPoints(Unit unit, int maxHP) : base(unit)
    {
        this.maxHP = maxHP;
    }

    public void AdjustHP(int adjustment)
    {
        int prevHP = currentHP;
        currentHP = Mathf.Clamp(currentHP + adjustment, 0, maxHP);
        Services.EventManager.Fire(new HitPointsAdjusted(Unit, prevHP, currentHP));
        if (currentHP == 0) Unit.RemoveFromMap();
    }
}

public class HitPointsAdjusted : Event
{
    public readonly int prevHP;
    public readonly int newHP;
    public readonly Unit unit;

    public HitPointsAdjusted(Unit unit, int prevHP, int newHP)
    {
        this.unit = unit;
        this.prevHP = prevHP;
        this.newHP = newHP;
    }
}
