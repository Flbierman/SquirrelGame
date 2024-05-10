// This script tracks the amount of acorns the player has collected and updates the acorn counter in the UI

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AcornCollection : MonoBehaviour
{
    private int Acorn = 0; // Stores the amount of acorns the player has collected

    public TextMeshProUGUI acronText;

    public int Acorns { get { return Acorn; } } // Access the number of acorns

    public void UseAcorns(int amount)
    {
        Acorn -= amount; // Decrease acorn amount
        acronText.text = "Acorns: " + Acorn.ToString(); // Update UI text
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Acorn") // Checks if the object is tagged as Acorn
        {
            Acorn++;
            acronText.text = "Acorns: " + Acorn.ToString(); // Updates UI text
            Destroy(other.gameObject); // Acorn object disappears after player makes contact with it
        }
    }
}


