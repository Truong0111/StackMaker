using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private GameObject endLevelPanel;

    #region  Singleton
    public static UIManager Ins;
    private void Awake()
    {
        Ins = this;
    }
    #endregion
    private void Start()
    {
        levelText.text = "Level " + Pref.Level;
        coinText.text = Pref.Coin + "";
    }

    private void LateUpdate()
    {
        UpdateCoinText();
        UpdateLevelText();
    }

    private void UpdateLevelText()
    {
        levelText.text = "Level " + Pref.Level;
    }

    private void UpdateCoinText()
    {
        coinText.text = Pref.Coin + "";
    }

    public void ShowEndLevelPanel(bool isShow)
    {
        endLevelPanel.SetActive(isShow);
    }
}
