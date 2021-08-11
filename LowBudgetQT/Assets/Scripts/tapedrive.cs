using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapedrive:MonoBehaviour {
    public Transform spool0;
    public Transform spool1;
    private float timer = 0;
    private int amp = 1;
    private int state = 0;

    // Start is called before the first frame update
    void Start() {
        spool0.Rotate(new Vector3(0, 0, 40));
    }

    // Update is called once per frame
    void Update() {
        switch (state) {
            case 0:
                if (timer > 0) {
                    timer -= Time.deltaTime;
                } else {
                    timer = Random.Range(0, 10);
                    state += 1;
                    if (Random.Range(0, 10) > 5) {
                        amp = 1;
                    } else {
                        amp = -1;
                    }
                }
                break;
            case 1:
                if (timer > 0) {
                    timer -= Time.deltaTime;
                    spool0.Rotate(new Vector3(0, 0, Time.deltaTime * (360 * 2) * amp));
                    spool1.Rotate(new Vector3(0, 0, Time.deltaTime * (360 * 2) * amp));
                } else {
                    timer = Random.Range(0, 10);
                    state += 1;
                    if (Random.Range(0, 10) > 5) {
                        amp = 1;
                    } else {
                        amp = -1;
                    }
                }
                break;
            case 2:
                if (timer > 0) {
                    timer -= Time.deltaTime;
                    spool0.Rotate(new Vector3(0, 0, Time.deltaTime * (360 * 0.5f) * amp));
                    spool1.Rotate(new Vector3(0, 0, Time.deltaTime * (360 * 0.5f) * amp));
                } else {
                    timer = Random.Range(0, 10);
                    state = 0;
                }
                break;

        }
    }
}
