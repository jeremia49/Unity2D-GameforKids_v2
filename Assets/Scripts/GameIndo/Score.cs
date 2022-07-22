using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text tmpro;
    public float score;
    public GameObject Target;

    public void openPopUp()
    {
        calculateScore();
        panel.SetActive(true);

    }

    private void calculateScore()
    {
        int totalSoal = Target.transform.childCount; 
        int totalBenar = 0;
        foreach (Transform child in Target.transform)
        {
            GameObject obj = child.gameObject;
            int id = obj.GetComponent<ObjectID>().ID;

            RaycastHit hit;
            Physics.Raycast(obj.transform.position, transform.TransformDirection(Vector3.back), out hit, Mathf.Infinity);            
            if (hit.collider != null)
            {
                int jawabanID = hit.collider.transform.gameObject.GetComponent<ObjectID>().ID;
                if (id == jawabanID)
                {
                    totalBenar++;
                    hit.collider.transform.gameObject.GetComponent<Image>().color = new Color(166f / 255, 255f / 255, 94f / 255, 1); 

                }
                else
                {
                    hit.collider.transform.gameObject.GetComponent<Image>().color = new Color(255f / 255, 93f / 255, 93f / 255, 1);
                }

            }
        }

        score = (totalBenar * 1f / totalSoal * 1f) * 100f;
        tmpro.text = "Skor : " + score.ToString();

    }

    public void closePopUp()
    {
        foreach (Transform child in Target.transform)
        {
            GameObject obj = child.gameObject;

            RaycastHit hit;
            Physics.Raycast(obj.transform.position, transform.TransformDirection(Vector3.back), out hit, Mathf.Infinity);

            if (hit.collider != null)
            {
                hit.collider.transform.gameObject.GetComponent<Image>().color = new Color(255f/255, 232f / 255, 232f / 255, 1);
            }
        }
        panel.SetActive(false);
    }



}
