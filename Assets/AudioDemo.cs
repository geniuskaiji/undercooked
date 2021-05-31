using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // Method 2

public class AudioDemo : MonoBehaviour
{
    // Method 1
    public AudioClip clip;
    public AudioClip anotherClip; // source clip
    public AudioSource playAudio; // plays the audio

    // Method 2, uses events
    public UnityEvent audioEvent = new UnityEvent();

    public void Update() {
        // Method 1
        if(Input.GetButtonDown("Jump")){
            playAudio.clip = anotherClip;
            playAudio.Play();
        }

        // Method 2
        if(Input.GetKeyDown(KeyCode.A)){

            audioEvent.Invoke();
        }
    }
}
