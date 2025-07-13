using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private AudioSource _audiosource;

    private AudioClip _Buttan;
    // Start is called before the first frame update
    void Start()
    {
        _audiosource = GetComponent<AudioSource>();
        _audiosource.Play();
    }

    private void StopBGM()
    {
        _audiosource.Stop();
    }

    public void ChangeBGM(AudioClip newClip)
    {
        _audiosource.clip = newClip;
        _audiosource.Play();
    }
}
