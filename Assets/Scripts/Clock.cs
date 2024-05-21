using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public float timeOnLevel;
    public bool playerAlive = true;
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        timeOnLevel = 0f;
        //Subscribing to the Events sent by HitPoints
        HitPoints.OnPlayerDied += PlayerDied;
        HitPoints.OnPlayerRespawned += PlayerRespawn;
    }

    private void PlayerDied(){
        playerAlive = false;
    }

    private void PlayerRespawn(){
        playerAlive = true;
    }

    void DisplayTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);

        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timeString;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAlive){
            timeOnLevel += Time.deltaTime;
        }
        DisplayTime(timeOnLevel);
    }

    
}
