using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antlineController : MonoBehaviour, receiver {
    private LineRenderer line;
    public Transform endpoint;

    // Start is called before the first frame update
    void Start() {
        line = GetComponent<LineRenderer>();
        line.SetPosition(0, transform.position);
        line.SetPosition(1, endpoint.position);
        line.material.color = Color.cyan;
    }

    public void setmode(bool inp) {
        if (inp) {
            line.material.color = new Color(1, 0.6f, 0, 1);
        } else {
            line.material.color = Color.cyan;
        }
    }
}