using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInt : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void setInt(int inp)
    {
        anim.SetInteger("location", inp);
    }
}
