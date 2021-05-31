using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour, receiver {
    private Animator anim;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
    }

    public void setmode(bool inp) {
        anim.SetBool("open", inp);
        if (inp) {
            sound.Play();
        }
    }
}
