using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rtexDisable:MonoBehaviour {
    void Start() {
        if (!persistentSettings.Instance.useRenderTextures) {
            gameObject.SetActive(false);
        }
    }
}
