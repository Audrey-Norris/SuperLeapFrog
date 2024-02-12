using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointChecker : MonoBehaviour
{
    public TMP_Text playerText;
    public int score =0;
    public bool isScored = false;

    void OnTriggerEnter(Collider other)
    {
        // Check if Player 2 is grounded when colliding with a surface.
        if (other.CompareTag("Checker"))
        {
            score+=1;
            playerText.text = score.ToString();
            isScored = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if Player 2 is grounded when colliding with a surface.
        if (other.CompareTag("Checker"))
        {
            isScored = false;
        }
    }
}
