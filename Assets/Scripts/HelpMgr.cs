using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMgr : MonoBehaviour
{
    public GameObject helpPopup;
    public bool isActive = false;

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            helpPopup.SetActive(true);
        }
        else
        {
            helpPopup.SetActive(false);
        }
    }

    public void showPopup()
    {
        SceneMgr.playSound();
        isActive = true;
    }
    public void hidePopup()
    {
        SceneMgr.playSound();
        isActive = false;
    }

}
