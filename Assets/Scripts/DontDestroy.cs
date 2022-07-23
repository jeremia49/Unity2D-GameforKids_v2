using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject music;
    public GameObject music1;
    public GameObject music2;
    public GameObject AudioManager;


    void Awake()
    {
        DontDestroyOnLoad(music);
        DontDestroyOnLoad(music1);
        DontDestroyOnLoad(music2);
        DontDestroyOnLoad(AudioManager);
    }

}
