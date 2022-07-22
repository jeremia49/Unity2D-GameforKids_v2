using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameIndo : MonoBehaviour
{
    public GameObject Source;
    public Vector3[] originalPos;

    void Start()
    {
        
    }

    void Awake()
    {
        Vector3[] originalPos = new Vector3[Source.transform.childCount];

        for (int i = 0; i < Source.transform.childCount; i++)
        {
            originalPos[i] = Source.transform.GetChild(i).position;
        }

        reshuffle(originalPos);

        for (int i = 0; i < Source.transform.childCount; i++)
        {
            Source.transform.GetChild(i).position = originalPos[i];
        }
    }

    void reshuffle(Vector3[] pos)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < pos.Length; t++)
        {
            Vector3 tmp = pos[t];
            int r = Random.Range(t, pos.Length);
            pos[t] = pos[r];
            pos[r] = tmp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
