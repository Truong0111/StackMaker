using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private Image currentImage;
    [SerializeField] private Sprite volumeOn;
    [SerializeField] private Sprite volumeOff;

    private void Start()
    {
        StartVolume();
        LoadVolume();
    }
    private void StartVolume()
    {
        if(!PlayerPrefs.HasKey(Const.CUR_VOLUME_ICON_ID))
        {
            Pref.CurVolIconId = 1;
            currentImage.sprite = volumeOn;
            SetVolumeOn();
        }
        else
        {
            currentImage.sprite = Pref.CurVolIconId == 1 ? volumeOn : volumeOff;
        }
    }
    public void VolumeChange()
    {
        if (Pref.CurVolIconId == 1)
        {
            currentImage.sprite = volumeOff;
            Pref.CurVolIconId = 0;
            SetVolumeOff();
        }
        else
        {
            currentImage.sprite = volumeOn;
            Pref.CurVolIconId = 1;
            SetVolumeOn();
        }
    }
    private void SetVolumeOff()
    {
        Pref.MusicVolume = 0;
        LoadVolume();
    }
    private void SetVolumeOn()
    {
        Pref.MusicVolume = 0.5f;
        LoadVolume();
    }
    private void LoadVolume()
    {
        var volumeValue = Pref.MusicVolume;
        AudioListener.volume = volumeValue;
    }
}
