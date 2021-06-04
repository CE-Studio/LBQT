using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorController:MonoBehaviour {
    public bool canRun = true;
    public Animator anim;
    private bool running = false;

    // Start is called before the first frame update
    void Start() {
        anim.SetBool("open", true);
    }

    // Update is called once per frame
    void Update() {
        if (running) {
            anim.SetBool("open", false);
            transform.position = new Vector3(transform.position.x, transform.position.y + (Time.deltaTime / 2.0f), transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (canRun && (other.tag == "Player")) {
            running = true;
        }
    }
}
