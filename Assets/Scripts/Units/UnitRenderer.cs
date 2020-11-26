using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRenderer : MonoBehaviour
{
    public Unit unit { get; private set; }
    private SpriteRenderer spriteRenderer;

    public void Setup(Unit unit)
    {
        this.unit = unit;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = unit.baseUnitData.Sprite;
        transform.localPosition = new Vector3(unit.centerCoordinate.x, unit.centerCoordinate.y);
    }

    public void OnRemoval()
    {
        // have some way to determine the way it should be removed
        // whether its a death animation, or an acquisition animation or something
        // not sure how, check components on the unit I guess? 
        // maybe strap on a component to the renderer thats like a RemovalHandler
        // determined by component or field on the Unit

        // for now
        Destroy(gameObject);
    }
}
