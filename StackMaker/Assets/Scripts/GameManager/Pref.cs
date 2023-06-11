using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pref
{

    public static int Coin
    {
        set => PlayerPrefs.SetInt(Const.COIN, value);
        get => PlayerPrefs.GetInt(Const.COIN);
    }

    public static int Level
    {
        set => PlayerPrefs.SetInt(Const.LEVEL, value);
        get => PlayerPrefs.GetInt(Const.LEVEL);
    }
    public static int CurVolIconId
    {
        set => PlayerPrefs.SetInt(Const.CUR_VOLUME_ICON_ID, value);
        get => PlayerPrefs.GetInt(Const.CUR_VOLUME_ICON_ID);
    }
    public static void SetBool(string key, bool isUnlock)
    {
        int value = isUnlock ? 1 : 0;
        PlayerPrefs.SetInt(key, value);
    }
    public static bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1 ? true : false;
    }
}
