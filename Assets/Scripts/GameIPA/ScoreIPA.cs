using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreIPA : MonoBehaviour
{

    public float score;
    public TMP_Text scoreText;
    public GameObject Source;
    public GameObject panel;

    public void openPopUp()
    {
        calculateScore();
        panel.SetActive(true);
    }

    private void calculateScore()
    {
        int totalSoal = Source.transform.childCount;
        int totalBenar = 0;
        foreach (Transform child in Source.transform)
        {
            GameObject obj = child.gameObject;
            int ind = obj.GetComponent<ObjectID>().indicator;

            RaycastHit hit;
            Physics.Raycast(obj.transform.position, transform.TransformDirection(Vector3.back), out hit, Mathf.Infinity);
            if (hit.collider != null)
            {
                int jawabanInd = hit.collider.transform.gameObject.GetComponent<ObjectID>().indicator;
                if (ind == jawabanInd)
                {
                    totalBenar++;

                }

            }
        }

        score = (totalBenar * 1f / totalSoal * 1f) * 100f;
        scoreText.text = "Skor : " + score.ToString();

    }

    public void closePopUp()
    {
        
        panel.SetActive(false);
    }




}
