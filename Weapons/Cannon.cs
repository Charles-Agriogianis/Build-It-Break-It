using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Cannon : MonoBehaviour
{
    public GameObject projectile;
    public GameObject cam;
    public Text ammoCounter;

    public AudioSource audioSource;
    public AudioClip shootingSFX;

    float bulletSpeed = 60f;
    static int ammoCount = 5;
    static int startingAmmo;

    public float barDisplay; //current progress
    public Vector2 pos = new Vector2(540,510);
    public Vector2 size = new Vector2(90,20);
    public Texture2D emptyTex;
    public Texture2D fullTex;

    float charge = 0.0f;
    bool shoot = false;
    bool cooldown = false;

    public static int GetAmmoCount() {
        return ammoCount;
    }

    // Start is called before the first frame update
    void Start()
    {
        startingAmmo = ammoCount;
    }

    public static void ResetAmmo() {
        ammoCount = startingAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown && charge > 0.0f) {
            charge -= 0.002f;
        } else if (cooldown && charge <= 0.0f) {
            charge = 0;
            cooldown = false;
        } else if (charge >= 1.0f) {
            shoot = true;
        } else if (Input.GetButton("Fire2")) {
            charge += 0.005f;
        } else if(charge > 0.0f) {
            shoot = true;
        }

        if (shoot) {
            if (ammoCount > 0) {
                Vector3 offset = transform.forward * 1.3f;
                GameObject theBullet = (GameObject) Instantiate(projectile, cam.transform.position + offset, cam.transform.rotation);

                Physics.IgnoreCollision(theBullet.GetComponent<Collider>(), GetComponent<Collider>());
                theBullet.GetComponent<Rigidbody>().velocity = cam.transform.forward * bulletSpeed * charge;
            
                Destroy(theBullet, 5.0f);
                audioSource.PlayOneShot(shootingSFX);
                ammoCount -= 1;
            }
            shoot = false;
            cooldown = true;
        }
        
        if (mode.currentMode != 2) {
            ammoCounter.text = "";
        } else {
            ammoCounter.text = "Cannon: " + ammoCount.ToString() + " / " + startingAmmo;
        }
    }

    void OnGUI() {
        //draw the background:
        if (charge != 0.0f) {
            GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
                GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);
         
                //draw the filled-in part:
                GUI.BeginGroup(new Rect(0,0, size.x * charge, size.y));
                GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
                GUI.EndGroup();
            GUI.EndGroup();
        }
     }
}
