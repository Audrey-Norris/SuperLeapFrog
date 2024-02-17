using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SocialPlatforms;

public class Powerup : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (other.GetComponent<Movement>() != null) {
                Debug.Log("Player1");
                other.GetComponent<Movement>().speed = other.GetComponent<Movement>().speed * 2;
            }
            if (other.GetComponent<Movement2>() != null) {
                Debug.Log("Player1");
                other.GetComponent<Movement2>().speed = other.GetComponent<Movement2>().speed * 2;
            }
            Destroy(this.gameObject);
        }
    }
}
