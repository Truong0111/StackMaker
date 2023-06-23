using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        InitStart();
        LoadLevel();
    }

    private void Update()
    {
        if (PlayerStack.Ins.IsWin)
        {
            UIManager.Ins.ShowEndLevelPanel(true);
            
        }
    }

    private void InitStart()
    {
        if (!PlayerPrefs.HasKey(Const.COIN))
        {
            Pref.Coin = 0;
        }
        if (!PlayerPrefs.HasKey(Const.LEVEL))
        {
            Pref.Level = 1;
        }
    }
    public void NextLevel()
    {
        Pref.Level++;
        LoadLevel();
        UIManager.Ins.ShowEndLevelPanel(false);
    }
    private void LoadLevel()
    {
        if (Pref.Level < 1)
        {
            Debug.LogError("Invalid level number!");
            return;
        }

        GameObject newLevelPrefab = null;

#if UNITY_EDITOR
        var newLevelPath = "Assets/Resources/Level/level" + Pref.Level + ".prefab";
        newLevelPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(newLevelPath);
        if (newLevelPrefab == null)
        {
            Debug.LogError("Failed to load level prefab at path: " + newLevelPath);
            return;
        }
#else
    var newLevelName = "level" + Pref.Level;
    newLevelPrefab = Resources.Load<GameObject>("Level/" + newLevelName);
    if (newLevelPrefab == null)
    {
        Debug.LogError("Failed to load level prefab: " + newLevelName);
        return;
    }
#endif

        var oldLevel = GameObject.FindGameObjectWithTag("Level");
        if (oldLevel != null)
        {
            Destroy(oldLevel);
        }

        var newLevel = Instantiate(newLevelPrefab);
        if (newLevel == null)
        {
            Debug.LogError("Failed to instantiate level prefab!");
            return;
        }
    }
}
