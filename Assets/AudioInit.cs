using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInit : MonoBehaviour


{

    public AudioClip ready;
    public AudioClip go;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void readySound()
    {
        if (ready) audio.PlayOneShot(ready);
    }

    public void goSound()
    {
        if (go) audio.PlayOneShot(go);
    }
}