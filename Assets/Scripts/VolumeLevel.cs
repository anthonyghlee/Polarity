using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeLevel : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Slider slider;
    [SerializeField] AudioMixer mixer;

    void Start()
    {
        slider.value = VolumeSlider.instance.slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        mixer.SetFloat("MasterVolume", slider.value - 80f);
    }
}
