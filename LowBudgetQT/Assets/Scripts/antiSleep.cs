using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antiSleep : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       rb.WakeUp();
    }
}
