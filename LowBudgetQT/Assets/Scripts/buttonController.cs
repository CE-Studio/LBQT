using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour {
    private int count;
    public bool pressed = false;
    private bool lastpressed = false;

    private GameObject plate;

    public GameObject[] affectors;
    private receiver[] connections;

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
    void aniUpdate() {
        plate = transform.GetChild(0).GetChild(0).gameObject;
        pressed = (count > 0);
        if (pressed) {
            plate.transform.localPosition = new Vector3(0f, 0f, -0.044f);
        } else {
            plate.transform.localPosition = new Vector3(0f,0f, 0f);
        }
        if (!(pressed == lastpressed)) {
            lastpressed = pressed;
            foreach (receiver i in connections) {
                i.setmode(pressed);
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "cubes") {
            count += 1;
            aniUpdate();
        } else if (other.tag == "Player") {
            count += 1;
            aniUpdate();
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "cubes") {
            count -= 1;
            aniUpdate();
        } else if (other.tag == "Player") {
            count -= 1;
            aniUpdate();
        }
    }
}
