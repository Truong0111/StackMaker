using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TreasureManager : MonoBehaviour
{
    [SerializeField] private GameObject treasureRid;
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
        InitStart();
    }
    private void Update()
    {
        InitUpdate();
    }
    private void InitStart()
    {
        this.enabled = false;
        _isOpen = false;
    }

    private const float MaxRotateOpen = 0.45f;

    private void InitUpdate()
    {
        if (!_isOpen) return;
        if (treasureRid.transform.localRotation.x <= MaxRotateOpen) OpenTreasure();
    }

    public void OpenTreasure()
    {
        _isOpen = true;
        this.enabled = true;
        treasureRid.transform.Rotate(Vector3.right, 45f * Time.deltaTime);
    }
}
