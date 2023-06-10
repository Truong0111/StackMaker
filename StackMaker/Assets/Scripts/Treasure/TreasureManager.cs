using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureManager : MonoBehaviour
{
    public GameObject treasureRid;
    private bool _isOpen;

    #region Singleton
    public static TreasureManager Ins;
    private void Awake()
    {
        Ins = this;
    }
    #endregion

    private void Start()
    {
        initStart();
    }
    private void Update()
    {
        initUpdate();
    }

    #region init
    private void initStart()
    {
        this.enabled = false;
        _isOpen = false;
    }
    private float maxRotateOpen = 0.45f;
    private void initUpdate()
    {
        if (_isOpen)
        {
            if (treasureRid.transform.localRotation.x <= maxRotateOpen) OpenTreasure();
        }
    }
    #endregion

    public void OpenTreasure()
    {
        _isOpen = true;
        this.enabled = true;
        treasureRid.transform.Rotate(0.5f,0,0); //+= rotation.x 0.05f per frame
    }
}
