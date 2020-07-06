using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DrawColorManager
{
    public static bool IsDrawColor(DrawColorStatus color)
    {
        if (color == DrawColorStatus.None)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static Color GetColorCode(DrawColorStatus color)
    {
        switch (color)
        {   
                case DrawColorStatus.white:
                    return Color.white;
                case DrawColorStatus.gray:
                    return new Color(0.5f, 0.5f, 0.5f); // 色はRGBで設定することもできる
                // return Color.gray; 
                case DrawColorStatus.black:
                    return Color.black;
                default:
                    return Color.red; // ここに来たらエラーです
            
            


        }
    }
}
