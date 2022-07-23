using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioSource clickMusic;
    public static AudioSource backgroundMusic;
    public static AudioSource gameMusic;

    void Awake()
    {
        clickMusic = GameObject.Find("clickMusic").GetComponent<AudioSource>();
        backgroundMusic = GameObject.Find("backgroundMusic").GetComponent<AudioSource>();
        gameMusic = GameObject.Find("gameMusic").GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "game-indo":
            case "game-ipa":
                backgroundMusic.Pause();
                gameMusic.Play();
                break;
            case "materi-indo":
            case "materi-ipa":
                backgroundMusic.Pause();
                gameMusic.Pause();
                break;
            default:
                gameMusic.Pause();
                if (backgroundMusic.isPlaying)
                {
                    return;
                }                
                backgroundMusic.Play();
                break;
        }


    }


    public static void playClick()
    {
        clickMusic.Play();
    }

    public static void playBackground()
    {
        backgroundMusic.Play();
    }

    public static void playGame()
    {
        gameMusic.Play();
    }
}
