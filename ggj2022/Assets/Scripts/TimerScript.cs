using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerScript : MonoBehaviour
{
    bool timerActive = false;
    float currentTime;
    public Text currentTimeText;
    public Text highScore;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        StartTimer();
        //TimeSpan high = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("HighScore", 0));
        //highScore.text = high.ToString(@"mm\:ss\:ff");
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true) {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:ff");
    }

    //StartTimer Start the timer yes that's all and it's good like this
    public void StartTimer() {
        currentTime = 0;
        timerActive = true;
    }

    //DisplayHigh Display the HighScore yes that's all and it's good like this
    public void DisplayTimer() {
        TimeSpan high = TimeSpan.FromSeconds(currentTime);
        highScore.text = high.ToString(@"mm\:ss\:ff");
    }

    //StopTimer Stop the timer, pass the currentTime to StockTime and reset currentTime it need to be called at the end of the level
    public void StopTimer() {
        timerActive = false;
        StockTime();
    }

    //AbortTimer just stop the timer and reset it if the player leave the level without finishing it
    public void AbortTimer() {
        timerActive = false;
        currentTime = 0;
    }
    //StockTime check if the currentTime is better than the HighScore and if it's true he stock it
    public void StockTime()
    {
        if(currentTime < PlayerPrefs.GetFloat("HighScore") && PlayerPrefs.GetFloat("HighScore") != 0) {
            PlayerPrefs.SetFloat("HighScore", currentTime);
        } else if(PlayerPrefs.GetFloat("HighScore") == 0){
            PlayerPrefs.SetFloat("HighScore", currentTime);
        }
    }
}
