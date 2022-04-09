using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static float Round(float number, float minValue = 0.01f)
    {
        return Mathf.Abs(number) > minValue ? number : 0f;
    }
}
