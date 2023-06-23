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

    public void PlaySfx(AudioClip clip)
    {
        aus.PlayOneShot(clip);
    }
    public void PlaySfx(SfxType sfxType)
    {
        AudioClip clip = sfxType switch
        {
            SfxType.LevelComplete => levelComplete,
            SfxType.OpenChest => openChest,
            SfxType.PopStack => popStack,
            SfxType.PushStack => pushStack,
            _ => null
        };

        if (clip != null)
        {
            aus.PlayOneShot(clip);
        }
    }
}
public enum SfxType
{
    LevelComplete,
    OpenChest,
    PopStack,
    PushStack
}
