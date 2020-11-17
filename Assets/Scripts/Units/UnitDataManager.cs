using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitDataManager : MonoBehaviour
{
    public TextAsset UnitDataTextFile;
    public UnitSpriteDataManager UnitSpriteDataManager;
    private Dictionary<string, BaseUnitData> unitDataDict;
    private Dictionary<string, UnitSpriteData> spriteDataDict;

    private enum UnitDataColumns
    {
        Name = 0,
        Description = 1,
        SizeX = 2,
        SizeY = 3,
        Components = 4
    }

    private void Awake()
    {
        spriteDataDict = new Dictionary<string, UnitSpriteData>();
        foreach(UnitSpriteData unitSpriteData in UnitSpriteDataManager.UnitSpriteDatas)
        {
            spriteDataDict.Add(unitSpriteData.UnitName.ToUpper(), unitSpriteData);
        }

        unitDataDict = ParseUnitData(UnitDataTextFile);
    }

    private Dictionary<string, BaseUnitData> ParseUnitData(TextAsset textFile)
    {
        Dictionary<string, BaseUnitData> unitDataDict = new Dictionary<string, BaseUnitData>();

        string textFileString = textFile.text;
        string[] rowStrings = textFileString.Split('\n');
        for (int i = 1; i < rowStrings.Length; i++)
        {
            string rowString = rowStrings[i];
            string[] cellStrings = rowString.Split('\t');

            string name = cellStrings[(int)UnitDataColumns.Name];
            string description = cellStrings[(int)UnitDataColumns.Description];
            int sizeX, sizeY;
            int.TryParse(cellStrings[(int)UnitDataColumns.SizeX], out sizeX);
            Debug.Assert(sizeX != 0, "Improper size X value for " + name);
            int.TryParse(cellStrings[(int)UnitDataColumns.SizeY], out sizeY);
            Debug.Assert(sizeY != 0, "Improper size Y value for " + name);
            Vector2Int size = new Vector2Int(sizeX, sizeY);
            UnitSpriteData unitSpriteData = null;
            if (spriteDataDict.ContainsKey(name.ToUpper()))
            {
                unitSpriteData = spriteDataDict[name.ToUpper()];
            }
            else
            {
                Debug.Assert(false, "Unit sprite data for " + name + " not found");
            }
            Sprite sprite = unitSpriteData.Sprite;
            string[] componentStrings = cellStrings[(int)UnitDataColumns.Components].Split(';');
            List<UnitComponentFactory> unitComponentFactories = new List<UnitComponentFactory>();
            foreach(string componentString in componentStrings)
            {
                if (componentString == "") continue;
                string[] componentStringParts = componentString.Split(',');
                string componentName = componentStringParts[0];
                string[] componentParams = new string[componentStringParts.Length - 1];
                componentStringParts.CopyTo(componentParams, 1);
                UnitComponentFactory unitComponentFactory = new UnitComponentFactory(componentName, 
                    componentParams);
                unitComponentFactories.Add(unitComponentFactory);
            }
            BaseUnitData baseUnitData = new BaseUnitData(name, description, size, sprite, 
                unitComponentFactories);
            unitDataDict.Add(name, baseUnitData);
        }

        return unitDataDict;
    }

    public BaseUnitData GetUnitData(string unitName)
    {
        if (unitDataDict.ContainsKey(unitName))
        {
            return unitDataDict[unitName];
        }
        else
        {
            Debug.Assert(false, "Unit Data for " + unitName + " not found");
            return null;
        }
    }
}
