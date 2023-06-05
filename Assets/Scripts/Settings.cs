using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    // Start is called before the first frame update

    public bool MUTE = false;
    AudioSource[] audioSources;

    private static Settings _instance;
    public static Settings Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Settings is NULL");
            }
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MuteGame()
    {
        MUTE = true;
        audioSources = FindObjectsOfType<AudioSource>();
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].enabled = false;
        }
        MUTE = true;
    }
    public void UnMuteGame()
    {
        MUTE = false;
        audioSources = FindObjectsOfType<AudioSource>();
        for(int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].enabled = true;
        }
       

    }
}
