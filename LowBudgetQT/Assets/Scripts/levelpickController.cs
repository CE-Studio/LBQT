using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelpickController:MonoBehaviour {
    public Sprite[] thumbs;
    public string[] levels;
    public string[] levelNames;
    public Image img;
    public Text label;
    private int sel = -1;

    public void setLevel(int inp) {
        img.sprite = thumbs[inp];
        sel = inp;
        label.text = levelNames[inp];
    }

    public void loadlevel() {
        if (sel > -1) {
            SceneManager.LoadScene(levels[sel]);
        }
    }
}
