using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dispenserController : MonoBehaviour, receiver
{
    private Animator anim;
    //private AudioSource sound;
    public GameObject box;
    public Transform boxSpawnPos;
    private GameObject boxSlot1;
    private GameObject boxSlot2;
    private bool boxSlotPointer;
    private bool open;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //sound = GetComponent<AudioSource>();
        GameObject startBox = Instantiate(box, boxSpawnPos.position, Quaternion.identity) as GameObject;
        boxSlot1 = startBox;
    }

    public void setmode(bool inp)
    {
        anim.SetBool("drop", inp);
        if (inp)
        {
            open = true;
            //sound.Play();
            if (boxSlotPointer)
            {
                boxSlot1.transform.position = boxSpawnPos.position;
                boxSlot1.SetActive(false);
            }
            else
            {
                if (boxSlot2 != null)
                {
                    boxSlot2.transform.position = boxSpawnPos.position;
                    boxSlot2.SetActive(false);
                }
            }
        }
    }

    public void ResetDropAnim()
    {
        open = false;
        anim.SetBool("drop", false);
        if (boxSlot2 == null)
        {
            GameObject newBox = Instantiate(box, boxSpawnPos.position, Quaternion.identity) as GameObject;
            boxSlot2 = newBox;
        }
        boxSlot1.SetActive(true);
        boxSlot2.SetActive(true);
        boxSlotPointer = !boxSlotPointer;
    }

    public void EnsureBoxRespawn()
    {
        if (open)
        {
            ResetDropAnim();
        }
    }
}
