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
    public GameObject player;
    private bool boxSlotPointer;
    private bool open;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //sound = GetComponent<AudioSource>();
        GameObject startBox = Instantiate(box, boxSpawnPos.position, Quaternion.identity) as GameObject;
        boxSlot1 = startBox;
        player = GameObject.FindWithTag("Player");
    }

    public void setmode(bool inp)
    {
        if (inp)
        {
            anim.SetBool("drop", inp);
            open = true;
            //sound.Play();
            if (boxSlotPointer)
            {
                if (player.GetComponent<PlayerMove>().held == boxSlot1)
                {
                    player.GetComponent<PlayerMove>().holding = false;
                    player.GetComponent<PlayerMove>().held.GetComponent<Rigidbody>().useGravity = true;
                    player.GetComponent<PlayerMove>().held.GetComponent<Collider>().isTrigger = false;
                }
                boxSlot1.transform.position = boxSpawnPos.position;
                //boxSlot1.SetActive(false);
                StartCoroutine(nameof(DisableCube));
            }
            else
            {
                if (boxSlot2 != null)
                {
                    if (player.GetComponent<PlayerMove>().held == boxSlot2)
                    {
                        player.GetComponent<PlayerMove>().holding = false;
                        player.GetComponent<PlayerMove>().held.GetComponent<Rigidbody>().useGravity = true;
                        player.GetComponent<PlayerMove>().held.GetComponent<Collider>().isTrigger = false;
                    }
                    boxSlot2.transform.position = boxSpawnPos.position;
                    //boxSlot2.SetActive(false);
                    StartCoroutine(nameof(DisableCube));

                }
            }
        }
    }

    private IEnumerator DisableCube()
    {
        yield return new WaitForSeconds(0.1f);
        if (boxSlotPointer)
        {
            boxSlot1.SetActive(false);
        }
        else
        {
            boxSlot2.SetActive(false);
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
