using UnityEngine;
using System.Collections;

public class Building
{
    private string buildName = "";
    private buildingLevel buildLevel;
    private buildingType buildType;

    private int constructProgress;//percentage of completion

    public enum buildingLevel
    {
        LEVEL_0,
        LEVEL_1,
        LEVEL_2,
        LEVEL_3,
        LEVEL_4,
        LEVEL_5
    }

    public enum buildingType//
    {
        SCIENCE,
        PRODUCTION,
        ECONOMIC,
        UNREST
    }

    public Building(string namie, buildingLevel levelie, buildingType typeie)
    {
        buildName = namie;
        buildLevel = levelie;
        buildType = typeie;
    }

    public string BuildName
    {
        get { return buildName; }
        set { buildName = value; }
    }

    public buildingLevel BuildLevel
    {
        get { return buildLevel; }
        set { buildLevel = value; }
    }

    public buildingType BuildType
    {
        get { return buildType; }
        set { buildType = value; }
    }
}
