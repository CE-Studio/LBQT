using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persistentSettings:MonoBehaviour {
    public static persistentSettings Instance;

    public bool useRenderTextures = true;

    void Awake() {
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
        }
    }
}
