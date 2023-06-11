using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private Image currentImage;
    [SerializeField] private Sprite VolumeOn;
    [SerializeField] private Sprite VolumeOff;

    private void Start()
    {
        StartVolume();
    }
    #region Instance
    private VolumeController volumeController;
    #endregion
    private void StartVolume()
    {
        if(!PlayerPrefs.HasKey(Const.CUR_VOLUME_ICON_ID))
        {
            PlayerPrefs.SetInt(Const.CUR_VOLUME_ICON_ID, 1);
            currentImage.sprite = VolumeOn;
            volumeController.SetVolumeOn();
        }
        else
        {
            if (PlayerPrefs.GetInt(Const.CUR_VOLUME_ICON_ID) == 1)
                currentImage.sprite = VolumeOn;
            else currentImage.sprite = VolumeOff;
        }
    }
    public void VolumeChange()
    {
        if (PlayerPrefs.GetInt(Const.CUR_VOLUME_ICON_ID) == 1)
        {
            currentImage.sprite = VolumeOff;
            PlayerPrefs.SetInt(Const.CUR_VOLUME_ICON_ID, 0);
            volumeController.SetVolumeOff();
        }
        else
        {
            currentImage.sprite = VolumeOn;
            PlayerPrefs.SetInt(Const.CUR_VOLUME_ICON_ID, 1);
            volumeController.SetVolumeOn();
        }
    }
}
