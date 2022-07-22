using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMgr : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isActive = false;
    public GameObject panel;


    void Update()
    {
        if (isActive)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }

    public void showPopUp()
    {
        SceneMgr.playSound();
        isActive = true;
    }
    public void hidePopUp()
    {
        SceneMgr.playSound();
        isActive = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
