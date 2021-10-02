using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tempSettings:MonoBehaviour {

    public Toggle togg;
    
    void Update() {
        persistentSettings.Instance.useRenderTextures = togg.isOn;
    }
}
