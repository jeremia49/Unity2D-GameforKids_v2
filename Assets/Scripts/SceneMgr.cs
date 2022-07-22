using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public void to(string To)
    {
        playSound();
        if (To == "Quit")
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadSceneAsync(To);
        }
    }

    public void toHome()
    {
        playSound();
        SceneManager.LoadSceneAsync("MainMenu");
    }

    static public void playSound()
    {
        GameObject.FindObjectOfType<AudioSource>().Play();
    }
}
