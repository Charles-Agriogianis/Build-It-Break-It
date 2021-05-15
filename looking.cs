using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class looking : MonoBehaviour
{
    public Transform character;
    public List<GameObject> blocks;
    public List<int> amount;
    public GameObject placeHolder;
    public Text blocksLeft;

    // Sound stuff
    public AudioSource audioSource;

    Vector3 mouseLook;
    GameObject block;
    int selected = 0;

    // Highlighting objects
    RaycastHit objectHit;
    RaycastHit objectHitTemp; // store last highlighted object, so we can unhighlight it if the raycast doesnt hit it again
    bool tempExists = false;

    // Grabbing objects
    public float grabDist = 2.0f;
    public float grabRange = 4.0f;
    private bool grabbing = false;
    private float currX = 0;
    private float currY = 0;
    private float currZ = 0;
    RaycastHit heldObject;
    Material old;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (timer.gameOver) {
            // game is over 
            placeHolder.SetActive(false);
            blocksLeft.text = "";
            return;
        } else {
            placeHolder.SetActive(true);
        }

        Vector3 change = new Vector3(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"), 0.0f);
        mouseLook += change;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(mouseLook.x, character.up);

        if (mode.currentMode != 1 && mode.currentMode != 0) {
            placeHolder.SetActive(false);
            blocksLeft.text = "";
            return;
        } else {
            placeHolder.SetActive(true);
        }

        block = blocks[selected];

        if (Input.GetKeyDown(KeyCode.R)) {
            selected = (selected + 1) % blocks.Count;
            currX = 0;
            currY = 0;
            currZ = 0;
        }

        grabDist += Input.GetAxis("Mouse ScrollWheel");

        if (grabDist > grabRange) {
            grabDist = grabRange;
        }
        if (grabDist < 2.0f) {
            grabDist = 2.0f;
        }
        float useDist = grabDist;

        // Move currently held object
        if (grabbing) {
            // Check if object being held was destroyed
            if (objectHit.transform == null) {
                grabbing = false;
                tempExists = false;
                return;
            }

            heldObject.rigidbody.velocity = Vector3.zero;
            heldObject.rigidbody.angularVelocity = Vector3.zero;

            if (objectHit.distance < grabDist - 1) {
                useDist = objectHit.distance;
            }
            heldObject.transform.position = this.transform.position + this.transform.forward * useDist;
            float x = 0;
            float y = 0;
            float z = 0;

            if (Input.GetKey(KeyCode.Z)) {
                x = 2.0f;
            }

            if (Input.GetKey(KeyCode.X)) {
                y = 2.0f;
            }

            if (Input.GetKey(KeyCode.C)) {
                z = 2.0f;
            }

            heldObject.transform.Rotate(x, y, z);

            // Reset angular velocity 
            if (Input.GetKey(KeyCode.Q)) {
                heldObject.rigidbody.velocity = Vector3.zero;
                heldObject.rigidbody.angularVelocity = Vector3.zero;
            } 
        }
        // Highlight interactable object if hit
        else {
            Physics.Raycast(this.transform.position, this.transform.TransformDirection(Vector3.forward), out objectHit, grabRange);
            
            // if object is not the same as the one hit last frame
            if (!tempExists || objectHit.collider != objectHitTemp.collider) {
                // remove highlight from old object
                if (tempExists) {
                    objectHitTemp.collider.GetComponent<Renderer>().material = old;
                }

                // if new object is interactable, copy material and apply outline shader
                if (objectHit.transform != null && objectHit.collider.tag == "Interactable") {
                    //Debug.Log("updating highlight");
                    old = objectHit.collider.GetComponent<Renderer>().material;
                    Material outlined = new Material(old);
                    outlined.shader = Shader.Find("Outlined/Custom");
                    objectHit.collider.GetComponent<Renderer>().material = outlined;

                    objectHitTemp = objectHit;
                    tempExists = true;
                } else {
                    tempExists = false;
                }
            }
        }


        if (Input.GetMouseButtonDown(0)) {
            if (objectHit.transform != null) {
                // If already grabbing, release currently held object
                if (grabbing) {
                    grabbing = false;
                }
                // Otherwise, try to pick up object
                else {
                    // Check if object is Interactable
                    if (objectHit.collider.tag == "Interactable") {
                        heldObject = objectHit;
                        grabbing = true;
                    }
                }
            }
        }


        // block placeholder
        if (!grabbing) {
            placeHolder.GetComponent<MeshRenderer>().enabled = true;
            placeHolder.transform.position = this.transform.position + this.transform.forward * useDist;
            placeHolder.transform.rotation = this.transform.rotation;
            placeHolder.transform.localScale = block.transform.localScale;
            placeHolder.GetComponent<MeshRenderer>().material = block.GetComponent<MeshRenderer>().sharedMaterial;
            Color temp = placeHolder.GetComponent<MeshRenderer>().material.color;
            temp.a = 0.4f;

            if (Input.GetKey(KeyCode.Z)) {
                currX += 2.0f;
            }

            if (Input.GetKey(KeyCode.X)) {
                currY += 2.0f;
            }

            if (Input.GetKey(KeyCode.C)) {
                currZ += 2.0f;
            }

            placeHolder.transform.Rotate(currX, currY, currZ);

            if (!isTriggered.contact) {
                if (Input.GetKeyDown(KeyCode.E) && amount[selected] > 0 && isWithinBuildBounds()) {
                    Instantiate(block, this.transform.position + this.transform.forward * useDist, this.transform.rotation);
                    amount[selected] -= 1;
                    audioSource.Play();

                    Scoring.blocksLeft++;
                    Debug.Log("left: "+ Scoring.blocksLeft);
                }
            } else {
                temp.r += 0.9f;
            }

            placeHolder.GetComponent<MeshRenderer>().material.color = temp;
            blocksLeft.text = "X " + amount[selected].ToString();
        } else {
            placeHolder.GetComponent<MeshRenderer>().enabled = false;
            blocksLeft.text = " ";
        }
    }

    //restrain block spawning to inside building area
    bool isWithinBuildBounds() {
        if (character.position.z < 20 || character.position.z > 60 ) {
            return false;
        }
        if (character.position.x < -5 || character.position.x > 50 ) {
            return false;
        }
        return true;
    }
}
