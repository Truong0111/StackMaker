using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    [SerializeField] private GameObject VolumeBtn;
    private bool _isShow;

    private void Start()
    {
        VolumeBtn.SetActive(false);
        _isShow = false;
    }

    public void ShowSetting()
    {
        if (!_isShow)
        {
            VolumeBtn.SetActive(true);
            _isShow = true;
        }
        else
        {
            VolumeBtn.SetActive(false);
            _isShow = false;
        }
    }
}
