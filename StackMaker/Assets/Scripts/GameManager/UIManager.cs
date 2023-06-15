using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI LevelText;
    [SerializeField] private TextMeshProUGUI CoinText;
    private void Start()
    {
        LevelText.text = "Level " + Pref.Level;
        CoinText.text = Pref.Coin + "";
    }

    public void UpdateLevelText()
    {
        LevelText.text = "Level " + Pref.Level;
    }

    public void UpdateCoinText()
    {
        CoinText.text = Pref.Coin + "";
    }

}
