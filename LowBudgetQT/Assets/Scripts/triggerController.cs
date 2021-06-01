using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerController : MonoBehaviour {

    public bool mode = true;
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

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            foreach (receiver i in connections) {
                i.setmode(mode);
            }
        }
    }
}
