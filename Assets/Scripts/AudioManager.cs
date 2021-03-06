﻿using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

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

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        int randomSong = Random.Range(0, 2);
        sounds[randomSong].source.Play();
    }

    // To call this method in other scripts: FindObjectOfType<AudioManager>().Play("Nombredelsonido");
    public void Play(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
        s.source.Stop();
    }

    public void playRandomToMainMenu()
    {
        int randomSong = Random.Range(0, 2);
        sounds[randomSong].source.Play();
    }

    public void setVolumeInGame(float sliderValue)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == "InGameSound");
        s.source.volume = sliderValue;
    }
}
