using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Menu : MonoBehaviour
{
    public Text Score;
    // Start is called before the first frame update
    void Start()
    {
        TimeSpan high = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("HighScore", 0));
        Score.text = high.ToString(@"mm\:ss\:ff");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StopGame()
    {
        Application.Quit();
    }

    public void ResetScore()
    {
        PlayerPrefs.SetFloat("HighScore", 0);
        TimeSpan high = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("HighScore", 0));
        Score.text = high.ToString(@"mm\:ss\:ff");
    }
}
