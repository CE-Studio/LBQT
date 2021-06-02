using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushbutton:MonoBehaviour, ineractiveReceiver {

    public bool pressed = false;
    public bool oneshot = false;
    public float cooldownTime = 1.0f;
    private float cooldown = 0.0f;

    private GameObject plate;

    public GameObject[] affectors;
    private receiver[] connections;

    void Start() {
        plate = transform.GetChild(0).gameObject;
        List <receiver> j = new List<receiver>();
        int h = 0;
        foreach (GameObject i in affectors) {
            j.Add(i.GetComponent<receiver>());
            h++;
        }
        connections = j.ToArray();
    }
    
    void Update() {
        if (!oneshot && pressed && (cooldown >= cooldownTime)) {
            pressed = false;
            output();
            plate.transform.localPosition = new Vector3(0f, 0f, 0.08f);
        }
        if (!oneshot) {
            cooldown += Time.deltaTime;
        }
    }

    public void ping() {
        if (!pressed) {
            pressed = true;
            cooldown = 0;
            output();
            plate.transform.localPosition = new Vector3(0f, 0f, 0.06f);
        }
    }

    void output() {
        foreach (receiver i in connections) {
            i.setmode(pressed);
        }
    }
}
