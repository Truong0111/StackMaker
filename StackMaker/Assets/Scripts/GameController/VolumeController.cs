using UnityEngine;

public class VolumeController : MonoBehaviour
{
    #region Singleton
    private VolumeController Ins;
    private void Awake()
    {
        Ins = this;
    }
    #endregion

    public void Start()
    {
        LoadVolume();
    }
    private void Update()
    {
        //
    }
    public void SetVolumeOff()
    {
        PlayerPrefs.SetFloat("MusicVolume", 0);
        LoadVolume();
    }
    public void SetVolumeOn()
    {
        PlayerPrefs.SetFloat("MusicVolume", 0.5f);
        LoadVolume();
    }
    public void LoadVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat("MusicVolume");
        AudioListener.volume = volumeValue;
    }
}
