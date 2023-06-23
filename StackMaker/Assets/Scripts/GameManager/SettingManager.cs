using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SettingManager : MonoBehaviour
{
    [SerializeField] private GameObject volumeBtn;
    private bool _isShow;

    private void Start()
    {
        volumeBtn.SetActive(false);
        _isShow = false;
    }

    public void ShowSetting()
    {
        if (!_isShow)
        {
            volumeBtn.SetActive(true);
            _isShow = true;
        }
        else
        {
            volumeBtn.SetActive(false);
            _isShow = false;
        }
    }
}
