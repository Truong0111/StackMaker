using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        if (!PlayerPrefs.HasKey(Const.COIN))
            Pref.Coin = 99999;
    }
}
