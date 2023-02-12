using UnityEngine;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer audio;
    
    public void OnValueChanged(float value)
    {
        audio.SetFloat("Volume", value);
    }
}
