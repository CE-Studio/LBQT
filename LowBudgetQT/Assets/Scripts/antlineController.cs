using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antlineController : MonoBehaviour, receiver {
    private Animator anim;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
    }

    public void setmode(bool inp) {
        anim.SetBool("on", inp);
    }
}