using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarryOver : MonoBehaviour 
{
    public static CarryOver instance;

    public bool restart;

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

	private void OnEnable()
	{
        SceneManager.sceneLoaded += CheckRestart;
	}

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= CheckRestart;
    }

    void CheckRestart(Scene scene, LoadSceneMode mode)
    {
        SoundEffects.instance.playSound("click");
        SoundEffects.instance.sfx = GameStateManager.instance.sfxSlider;
        SoundEffects.instance.music = GameStateManager.instance.musicSlider;
        SoundEffects.instance.onSFXVolumeChange(0);
        SoundEffects.instance.onMusicVolumeChange(0);

        if (restart)
        {
            GameStateManager.instance.onPlayImmediately();
        }
    }

}
