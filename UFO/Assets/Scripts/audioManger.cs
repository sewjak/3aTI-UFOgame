using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class audioManger : MonoBehaviour
{

    public sound[] music, SFX;
    public AudioSource musicSource, SFXsource;

    public static audioManger instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic (string name)
    {
        sound s = Array.Find(music, x => x.name == name);
        if (s==null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicSource.clip = s.audioClip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        sound s = Array.Find(SFX, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            SFXsource.PlayOneShot(s.audioClip);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
