using UnityEngine.Audio;
using UnityEngine;
using System;

public class audioManager : MonoBehaviour
{

    public sound[] sounds;

    public static audioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;

            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Background Music");
    }

    public void Play(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        s.audioSource.Play();
    }

    public void Stop(string name)
    {
        sound s = Array.Find(sounds, sound => sound.name == name);
        s.audioSource.Stop();
    }


}
