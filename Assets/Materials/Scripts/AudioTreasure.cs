using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTreasure : MonoBehaviour
{
    public AudioSource MusicSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MusicSource.Play();
        }
    }
}
