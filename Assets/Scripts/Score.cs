using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void SetScore(int value)
    {
        PlayerPrefs.SetInt("score", value);
    }
    public static int GetScore()
    {
        return PlayerPrefs.GetInt("score");
    }
    public static void AddScore(int value)
    {
        PlayerPrefs.SetInt("score",PlayerPrefs.GetInt("score")+value);
    }
}
