using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAudioController : MonoBehaviour
{
    public AudioSource gameMusic;
    public float sliderValue;
    public void Awake()
    {
	    sliderValue = PlayerPrefs.GetFloat("MenuMusic", 0);
    }

    public void Update()
    {
        if(sliderValue == 1)
        {
            gameMusic.mute = true;
        }
        else
        {
            gameMusic.mute = false;
        }
    }
}
