using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalController : MonoBehaviour
{

    public Transform player;
    public Transform tracker;
    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        (tracker.position, tracker.rotation) = (player.position, player.rotation);
        (camera.localPosition, camera.localRotation) = (tracker.localPosition, tracker.localRotation);
    }
}
