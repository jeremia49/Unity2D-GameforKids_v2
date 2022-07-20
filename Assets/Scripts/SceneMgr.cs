using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    public void to(string To)
    {
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
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
