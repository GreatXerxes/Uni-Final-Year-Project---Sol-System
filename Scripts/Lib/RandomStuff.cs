using UnityEngine;
using System.Collections;

// Randomising methods
public class RandomStuff
{

	public static int Randomiser(int num1, int num2)//takes two ints and randomises it twice
    {
        int num3 = Random.Range(num1, num2);
        int num4 = Random.Range(num1, num2);

        if ((num3 - num4) > (num4 - num3))
        {
            return Random.Range(num3, num4);
        }
        else if ((num3 - num4) < (num4 - num3))
        {
            return Random.Range(num4, num3);
        }
        return Random.Range(Random.Range(num1, num2), Random.Range(num1, num2));
    }

    public static float Randomiser(float num1, float num2)//takes two floats and randomises it twice
    {
        float num3 = Random.Range(num1, num2);
        float num4 = Random.Range(num1, num2);

        if ((num3 - num4) > (num4 - num3))
        {
            return Random.Range(num3, num4);
        }
        else if ((num3 - num4) < (num4 - num3))
        {
            return Random.Range(num4, num3);
        }
        return Random.Range(Random.Range(num1, num2), Random.Range(num1, num2));
    }
}
