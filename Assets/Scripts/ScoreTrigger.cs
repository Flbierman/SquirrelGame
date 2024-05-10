// Creates a trigger for a gameobject. When the player contacts the object it adds points to score. Delay built in so player cannot collect points on demand

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class ScoreTrigger : MonoBehaviour
{
    public int pointsToAdd = 100; // Points added when road is crossed
    private ScoreKeeper scoreKeeper; // Public reference to the ScoreKeeper component
    public float delay = 1.0f; // Time interval between earning points
    public bool recurring = false;
    private bool canScore = true;

    


    private void Start(){
        //This pattern will initialize our connections without needing to do it manually
        GameObject uiCanvas = GameObject.Find("UICanvas");
        if (uiCanvas != null){
            scoreKeeper = uiCanvas.GetComponentInChildren<ScoreKeeper>();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canScore) // Checks if player character has "Player" tag
        {
            if (scoreKeeper != null)
            {
                scoreKeeper.AddScore(pointsToAdd); // Add points to score
                StartCoroutine(DelayNextScore());
            }
            else
            {
                Debug.LogError("ScoreKeeper reference not set on ScoreTrigger.");
            }
            if (!recurring){
                Destroy(gameObject);
            }
        }
    }

    IEnumerator DelayNextScore()
    {
        canScore = false;
        yield return new WaitForSeconds(delay);
        canScore = true;
    }
}