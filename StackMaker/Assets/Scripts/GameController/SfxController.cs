using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxController : MonoBehaviour
{
    [SerializeField] private AudioSource aus;
    [SerializeField] private AudioClip levelComplete;
    [SerializeField] private AudioClip openChest;
    [SerializeField] private AudioClip popStack;
    [SerializeField] private AudioClip pushStack;

    #region Singleton
    public static SfxController Ins;
    private void Awake()
    {
        Ins = this;
    }
    #endregion

    public void PlayLevelCompleteSfx()
    {
        aus.PlayOneShot(levelComplete);
    }
    public void PlayOpenChestSfx()
    {
        aus.PlayOneShot(openChest);
    }
    public void PlayPopStackSfx()
    {
        aus.PlayOneShot(popStack);
    }
    public void PlayPushStackSfx()
    {
        aus.PlayOneShot(pushStack);
    }
}
