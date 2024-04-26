using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float timeSinceDeath;
    public bool playerAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        timeSinceDeath = 0f;
    }

    private void PlayerDied(){
        Debug.Log("Other function called it! Yay!");
        playerAlive = false;
        timeSinceDeath = 0f;
    }

    public void PlayerRespawned(){
        playerAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAlive){
            timeSinceDeath += Time.deltaTime;
        }
    }
}
