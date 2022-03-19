using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffle
{
    public static void ShuffleObject(GameObject[] gameObjectArray)
    {
        for (int i = gameObjectArray.Length - 1; i > 0; i--)
        {
            int random = Random.Range(0, i);

            GameObject temp = gameObjectArray[i];
            gameObjectArray[i] = gameObjectArray[random];
            gameObjectArray[random] = temp;
        }
    }
}
