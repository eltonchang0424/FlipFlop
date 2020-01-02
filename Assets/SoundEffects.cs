using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffects : MonoBehaviour {

    public static SoundEffects instance;
    public Slider sfx;
    public Slider music;
    public AudioClip[] soundEffects;
    AudioSource[] audioSources;

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

        audioSources = new AudioSource[soundEffects.Length];

        for (int x = 0; x < soundEffects.Length; x++)
        {
            AudioSource aSource = gameObject.AddComponent<AudioSource>();
            audioSources[x] = aSource;
            aSource.clip = soundEffects[x];
            aSource.volume = sfx.value;
        }
        CarryOver.instance.GetComponent<AudioSource>().volume = music.value;

        sfx.value = PlayerPrefs.GetFloat("sfx");
        music.value = PlayerPrefs.GetFloat("music");
	}

	private void Start()
	{

    }

    public void playSound(string sound)
    {
        for (int x = 0; x < soundEffects.Length; x++)
        {
            if (sound.Equals(soundEffects[x].name))
            {
                audioSources[x].Play();
            }

        }
    }

    public void onMusicVolumeChange(float f)
    {
        
        PlayerPrefs.SetFloat("music", music.value);
        CarryOver.instance.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("music");
    }
    public void onSFXVolumeChange(float f)
    {
        PlayerPrefs.SetFloat("sfx", sfx.value);
        playSound("click");
        for (int x = 0; x < soundEffects.Length; x++)
        {
            audioSources[x].volume = PlayerPrefs.GetFloat("sfx");
        }
    }
}
