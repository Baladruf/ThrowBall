using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extender {

	public static Vector3 WithY(this Vector3 self, float value)
    {
        return new Vector3(self.x, value, self.z);
    }

    public static T GetRandomElement<T>(this T[] self)
    {
        if(self.Length == 0)
        {
            throw new System.Exception("Error get element in tab empty");
        }
        return self[Random.Range(0, self.Length)];
    }
}
