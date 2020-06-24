using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    static int beforeRandReturn;
    public static int NewRandom(int min, int max)
    {
        int returnInt;
        int firstRand = Random.Range(min, max);
        for (; firstRand == beforeRandReturn && (beforeRandReturn >= min && beforeRandReturn <= max);)
        {
            firstRand = Random.Range(0, 1.0f) >= 0.5f ? Random.Range(min, firstRand) : Random.Range(firstRand, max);
        }
        
        returnInt = firstRand;
        beforeRandReturn = returnInt;
        return returnInt;
    }
}
