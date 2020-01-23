using UnityEngine;
using System.Collections;

//TODO - Currently not implemented
public class Mechanised : GameUnit
{
    public Mechanised(float healthNum, float speedNum, float lightDamageNum, float heavyDamageNum, float lightDefNum, float heavyDefNum, int numPerUnitNum, int costNum) : base(healthNum, speedNum, lightDamageNum, heavyDamageNum, lightDefNum, heavyDefNum, numPerUnitNum, costNum, GameUnit.UTYPE.MECHANISED)
   {

    }

}
