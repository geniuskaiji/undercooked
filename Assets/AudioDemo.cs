using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioDemo : MonoBehaviour
{
    public AudioClip anotherClip;

    public AudioSource playAudio;

    public UnityEvent audioEvent = new UnityEvent();

    public void Update() {
        if(Input.GetButtonDown("Jump")){
            playAudio.clip = anotherClip;
            playAudio.Play();
        }

        if(Input.GetKeyDown(KeyCode.A)){
            audioEvent.Invoke();
        }
    }
}
