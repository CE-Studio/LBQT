using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove:MonoBehaviour, receiver {
    public CharacterController controller;

    public float speed = 1f;
    private float lookSensitivity = 8f;
    public float xRotation = 0f;

    public GameObject cam;
    public GameObject pointSpot;
    public Animator anim;
    private int toshoot = -1;
    private GameObject port0;
    private GameObject port1;

    public float gravity = -19.62f;
    public float jumpHeight = 1f;
    public LayerMask groundMask;
    private Vector3 velocity;
    bool isGrounded;
    private float jumpTime = 0;

    public bool holding = false;
    public GameObject held;
    private float holdCooldown = 0;

    public CanvasGroup fade;
    private bool fademode = false;
    private float faded = 1f;

    void Start() {
        cam = transform.GetChild(0).transform.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        anim = cam.transform.GetChild(2).transform.gameObject.GetComponent<Animator>();
        pointSpot = cam.transform.GetChild(1).transform.gameObject;
        port0 = GameObject.Find("portal0");
        port1 = GameObject.Find("portal1");
    }

    private void newMoveCalc() {

        RaycastHit hit;

        if (!(velocity.y > 0.1f) && Physics.SphereCast(transform.position, 0.3f, transform.up * -1, out hit, 0.4f, groundMask, QueryTriggerInteraction.Ignore)) {
            jumpTime = 0.2f;
        } else {
            jumpTime -= Time.deltaTime;
        }

        isGrounded = (jumpTime > 0);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            jumpTime = 0;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (transform.position.y < -100f) {
            transform.position = new Vector3(0, 5, 0);
            velocity.y = -2f;
        }

        controller.Move(move * speed * Time.deltaTime);
    }

    void Update() {

        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        if (lookSensitivity != 0) {
            cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
        transform.Rotate(Vector3.up * mouseX);

        if (Input.GetMouseButtonDown(0)) {
            toshoot = 0;
        } else if (Input.GetMouseButtonDown(1)) {
            toshoot = 1;
        }

        if (Input.GetKeyDown("e") && isGrounded) {
            grab();
        }

        updateGrab();
        procfade();
    }

    void FixedUpdate() {

        newMoveCalc();

        if (toshoot > -1) {
            shoot(toshoot);
            toshoot = -1;
        }
    }

    void OnTriggerEnter(Collider other) {

    }

    void shoot(int mode) {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 1000, 0b11101111111111)) {
            anim.Play("shoot", -1, 0);
            if (hit.transform.tag == "portable") {
                if (mode == 0) {
                    port0.transform.position = hit.point;
                    port0.transform.eulerAngles = hit.transform.eulerAngles;
                    //port0.transform.localEulerAngles += new Vector3(90,0,0);
                } else {
                    port1.transform.position = hit.point;
                    port1.transform.eulerAngles = hit.transform.eulerAngles;
                    //port1.transform.localEulerAngles += new Vector3(90,0,0);
                }
            }
        }
    }

    void grab() {
        RaycastHit hit;
        if (holding) {
            if (holdCooldown > 0.5f && (Physics.SphereCast(cam.transform.position, 0.2f, cam.transform.TransformDirection(Vector3.forward), out hit, 1, groundMask, QueryTriggerInteraction.Ignore))) {
                held.transform.position = hit.point;
            }
            holding = false;
            held.GetComponent<Rigidbody>().useGravity = true;
            held.GetComponent<Collider>().isTrigger = false;
        } else if (holdCooldown > 0.5f && (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 3, groundMask, QueryTriggerInteraction.Ignore))) {
            if (hit.collider.gameObject.tag == "cubes") {
                holding = true;
                held = hit.collider.gameObject;
                held.GetComponent<Rigidbody>().useGravity = false;
                held.GetComponent<Collider>().isTrigger = true;
                holdCooldown = 0.0f;
            } else if (hit.collider.gameObject.tag == "interactive") {
                hit.collider.gameObject.GetComponent<ineractiveReceiver>().ping();
            }
        }
    }

    void updateGrab() {
        if (holding) {
            held.transform.position = pointSpot.transform.position;
        }
        holdCooldown += Time.deltaTime;
    }

    public void setmode(bool inp) {
        fademode = inp;
    }

    void procfade() {
        if (fademode && (faded != 1)) {
            faded += (Time.deltaTime / 3f);
            faded = Mathf.Clamp01(faded);
            fade.alpha = faded;
        } else if (!fademode && (faded != 0)) {
            faded -= (Time.deltaTime / 3f);
            faded = Mathf.Clamp01(faded);
            fade.alpha = faded;
        }
    }
}
