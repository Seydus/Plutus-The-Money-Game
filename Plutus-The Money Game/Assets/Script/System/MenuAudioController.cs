using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAudioController : MonoBehaviour
{
	public AudioSource menuMusic;
    public Slider menuMusicSlider;

    
    void Awake()
    {
        menuMusicSlider.value = PlayerPrefs.GetFloat("MenuMusic", 0);
    }

    public void Update()
    {
        if(menuMusicSlider.value == 1)
        {
            menuMusic.mute = true;
            PlayerPrefs.SetFloat("MenuMusic", menuMusicSlider.value);
        }
        else
        {
            menuMusic.mute = false;
            PlayerPrefs.SetFloat("MenuMusic", menuMusicSlider.value);
        }
    } 
}
