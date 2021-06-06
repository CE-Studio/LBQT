using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger:MonoBehaviour, receiver {
    public string sceneToLoad;

    public void setmode(bool inp) {
        SceneManager.LoadScene(sceneToLoad);
    }
}
