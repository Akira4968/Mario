using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject DeadPanel;
    public static GameManager instance;
    [SerializeField] Text score;
    [SerializeField] Text deadScore;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        PausePanel.SetActive(false);
        DeadPanel.SetActive(false);
        Time.timeScale = 1;
        Score.SetScore(0);
    }

    
    // Update is called once per frame
    void Update()
    {
        score.text = $"Score: {(Score.GetScore()).ToString("0")}";
    }
    public void Continue()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false );
    }
    public void Pause()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Dead()
    {
        DeadPanel.SetActive(true);
        deadScore.text = $"Your Score: {(Score.GetScore()).ToString("0")}";
    }
    public void Play()
    {
        SceneManager.LoadScene("Level");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Level()
    {
        SceneManager.LoadScene("Level");
    }
    
}
