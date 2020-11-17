using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "UnitSpriteDataManager", menuName = "ScriptableObjects/UnitSpriteDataManager")]
public class UnitSpriteDataManager : ScriptableObject
{
    public UnitSpriteData[] UnitSpriteDatas;

    //public UnitSpriteData GetUnitSpriteData(string unitName)
    //{
    //    foreach (UnitSpriteData unitSpriteData in UnitSpriteDatas)
    //    {
    //        if (unitSpriteData.UnitName == unitName) return unitSpriteData;
    //    }
    //    Debug.Assert(false, "Unit Sprite Data for type " + unitName + " not found.");
    //    return null;
    //}
}
