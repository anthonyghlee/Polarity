using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        mixer.SetFloat("Background", slider.value - 80f);
    }
}
