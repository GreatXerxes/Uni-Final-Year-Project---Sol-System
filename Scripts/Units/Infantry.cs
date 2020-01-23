using UnityEngine;
using System.Collections;


//TODO - Currently not implemented
public class Infantry : GameUnit
{
    private float health = 100.0f;

    private float speed = 10f;

    private float lightDamage = 25f;
    private float heavyDamage = 5f;

    private int numPerUnit = 1000;

   public Infantry(float healthNum, float speedNum, float lightDamageNum, float heavyDamageNum, float lightDefNum, float heavyDefNum, int numPerUnitNum, int costNum) : base(healthNum, speedNum, lightDamageNum, heavyDamageNum, lightDefNum, heavyDefNum, numPerUnitNum, costNum, GameUnit.UTYPE.INFANTRY)
   {

   }
}
