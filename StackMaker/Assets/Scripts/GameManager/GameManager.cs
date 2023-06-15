using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        InitStart();
    }
    private void Update()
    {
        CheckWinAtLevel();
    }
    private void CheckWinAtLevel()
    {
        if (PlayerStack.Ins.IsWin)
        {
            //LoadLevel();
            //ChangeLevel();
            //ChangeCoin(50);
            return;
        }
    }
    private void InitStart()
    {
        if (!PlayerPrefs.HasKey(Const.COIN))
        {
            Pref.Coin = 100;
        }
        if (!PlayerPrefs.HasKey(Const.LEVEL))
        {
            Pref.Level = 1;
        }
    }
    public void ChangeLevel()
    {
        Pref.Level++;
    }

    public void ChangeCoin(int coin)
    {
        Pref.Coin += coin;
    }
}
