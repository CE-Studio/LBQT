using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayTrigger:MonoBehaviour, receiver {
    public bool inputState = false;
    public float delay = 0.0f;

    private float delayTime = 0.0f;

    public GameObject[] affectors;
    private receiver[] connections;

    private bool toggle = false;

    public void setmode(bool inp) {
        inputState = inp;
    }

    // Start is called before the first frame update
    void Start() {
        List<receiver> j = new List<receiver>();
        int h = 0;
        foreach (GameObject i in affectors) {
            j.Add(i.GetComponent<receiver>());
            h++;
        }
        connections = j.ToArray();
    }

    // Update is called once per frame
    void Update() {
        if (toggle && (delayTime >= delay)) {
            toggle = false;
            foreach (receiver i in connections) {
                i.setmode(true);
            }
        } else if (!toggle && (delayTime < delay)) {
            toggle = true;
            foreach (receiver i in connections) {
                i.setmode(false);
            }
        }
        if (inputState) {
            delayTime += Time.deltaTime;
        } else {
            delayTime = 0;
        }
    }
}
