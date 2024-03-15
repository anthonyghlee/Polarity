using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    public static VolumeSlider instance;
    
    [SerializeField] private Slider slider;
    [SerializeField] AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 65f;
    }

    // Update is called once per frame
    void Update()
    {
        mixer.SetFloat("MasterVolume", slider.value - 80f);
    }
}
