using UnityEngine;

public class VolumeController : MonoBehaviour
{
    #region Singleton
    public static VolumeController Ins;
    private void Awake()
    {
        Ins = this;
    }
    #endregion

    public void Start()
    {
        LoadVolume();
    }
    public void SetVolumeOff()
    {
        Pref.MusicVolume = 0;
        LoadVolume();
    }
    public void SetVolumeOn()
    {
        Pref.MusicVolume = 0.5f;
        LoadVolume();
    }
    public void LoadVolume()
    {
        float volumeValue = Pref.MusicVolume;
        AudioListener.volume = volumeValue;
    }
}
