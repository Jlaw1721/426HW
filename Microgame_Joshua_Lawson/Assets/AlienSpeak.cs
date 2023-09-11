using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpeak : MonoBehaviour
{
    public GameObject alienSpeak;
    public int alienSpeakLength = 3;

    public void OnTriggerEnter2D(Collider2D col)
    {
        alienSpeak.SetActive(true);
        StartCoroutine(alienConversation(alienSpeakLength));
    }

    IEnumerator alienConversation(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        alienSpeak.SetActive(false);
    }
}
