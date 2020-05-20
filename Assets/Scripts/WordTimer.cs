using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Maybe mess around with spawning more letters at fixed intervals?

public class WordTimer : MonoBehaviour
{
    public WordManager wordManager;

    public float wordDelay = 1.5f;
    private float nextWordTime = 0f;

    private void Update()
    {
        if (Time.time >= nextWordTime)
        {
            //wordManager.AddWord();
            nextWordTime = Time.time + wordDelay;
            wordDelay *= .95f;
        }
    }
}
