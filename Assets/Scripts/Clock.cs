using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public float timeSinceDeath;
    public bool playerAlive = true;
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceDeath = 0f;
        //Subscribing to the Events sent by HitPoints
        HitPoints.OnPlayerDied += PlayerDied;
        HitPoints.OnPlayerRespawned += PlayerRespawn;
    }

    private void PlayerDied(){
        playerAlive = false;
        timeSinceDeath = 0f;
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
            timeSinceDeath += Time.deltaTime;
        }
        DisplayTime(timeSinceDeath);
    }

    
}
