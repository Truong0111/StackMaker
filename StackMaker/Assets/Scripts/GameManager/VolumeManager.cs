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
    private void StartVolume()
    {
        if(!PlayerPrefs.HasKey(Const.CUR_VOLUME_ICON_ID))
        {
            Pref.CurVolIconId = 1;
            currentImage.sprite = VolumeOn;
            VolumeController.Ins.SetVolumeOn();
        }
        else
        {
            if (Pref.CurVolIconId == 1)
                currentImage.sprite = VolumeOn;
            else currentImage.sprite = VolumeOff;
        }
    }
    public void VolumeChange()
    {
        if (Pref.CurVolIconId == 1)
        {
            currentImage.sprite = VolumeOff;
            Pref.CurVolIconId = 0;
            VolumeController.Ins.SetVolumeOff();
        }
        else
        {
            currentImage.sprite = VolumeOn;
            Pref.CurVolIconId = 1;
            VolumeController.Ins.SetVolumeOn();
        }
    }
}
