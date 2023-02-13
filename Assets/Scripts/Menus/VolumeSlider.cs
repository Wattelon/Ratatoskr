using UnityEngine;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    
    public void OnValueChanged(float value)
    {
        mixer.SetFloat("Volume", value);
    }
}
