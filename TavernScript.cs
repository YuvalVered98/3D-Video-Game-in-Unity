using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tavernscript : MonoBehaviour
{
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.playOnAwake = false; // Ensures it doesn't play on awake
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure it's the player triggering the sound
        {
            sound.PlayDelayed(0.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sound.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
