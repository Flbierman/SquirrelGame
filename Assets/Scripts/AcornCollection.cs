using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AcornCollection : MonoBehaviour
{
    private int Acorn = 0;

    public TextMeshProUGUI acronText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Acorn")
        {
            Acorn++;
            acronText.text = "Acorn: " + Acorn.ToString();
            Debug.Log(Acorn);
            Destroy(other.gameObject);
        }
    }
}


