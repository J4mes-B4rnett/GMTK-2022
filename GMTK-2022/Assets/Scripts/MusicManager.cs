using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    private AudioSource audioSource;

    private void Start() {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void Update() {
        if (!audioSource.isPlaying) {
            audioSource.Play();
            audioSource.time = 2.834f;
        }
    }
}