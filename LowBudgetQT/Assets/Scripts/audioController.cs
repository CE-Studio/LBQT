using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour, receiver {
    private AudioSource sound;

    // Start is called before the first frame update
    void Start() {
        sound = GetComponent<AudioSource>();
    }

    public void setmode(bool inp) {
        if (inp) {
            sound.Play();
        }
    }
}
