using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRenderer : MonoBehaviour
{
    private Unit unit;
    private SpriteRenderer spriteRenderer;

    public void Setup(Unit unit)
    {
        this.unit = unit;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = unit.baseUnitData.Sprite;
        transform.localPosition = new Vector3(unit.centerCoordinate.x, unit.centerCoordinate.y);
    }
}
