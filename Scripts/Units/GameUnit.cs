using UnityEngine;
using System.Collections;

public class GameUnit
{
    private float health;

    private float speed;

    private float lightDamage;// Damage to light defence
    private float heavyDamage;// Damage to heavy defence

    private int numPerUnit;//Num of things in the unit e.g 10 tanks in a tank unit
    private int numAliveinUnit;//Num of things alive in the unit e.g 1 out of 10 tanks alive in a tank unit

    private float lightDefense;
    private float heavyDefense;

    private int cost;//how long it takes to create

    private UTYPE type;//unit type

    public GameUnit(float healthNum, float speedNum, float lightDamageNum, float heavyDamageNum, float lightDefNum, float heavyDefNum, int numPerUnitNum, int costNum, UTYPE uType)
    {
        health = healthNum;
        speed = speedNum;
        lightDamage = lightDamageNum;
        heavyDamage = heavyDamageNum;
        lightDefense = lightDefNum;
        heavyDefense = heavyDefNum;
        numPerUnit = numPerUnitNum;
        cost = costNum;
        type = uType;
    }

    public enum UTYPE
    {
        INFANTRY,
        MECHANISED,
        SETTLER
    }

    /**
    *Getters and Setters
    **/
    public float Health
    {
        get { return health;  }
        set { health = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public float LightDamage
    {
        get { return lightDamage; }
        set { lightDamage = value; }
    }

    public float HeavyDamage
    {
        get { return heavyDamage; }
        set { heavyDamage = value; }
    }

    public float LightDefense
    {
        get { return lightDefense; }
        set { lightDefense = value; }
    }

    public float HeavyDefense
    {
        get { return heavyDefense; }
        set { heavyDefense = value; }
    }

    public int NumPerUnit
    {
        get { return numPerUnit; }
        set { numPerUnit = value; }
    }

    public int NumAliveinUnit
    {
        get { return numAliveinUnit; }
        set { numAliveinUnit = value; }
    }

    public int Cost
    {
        get { return cost; }
        set { cost = value; }
    }

    public UTYPE Type
    {
        get { return type; }
        set { type = value; }
    }
}
