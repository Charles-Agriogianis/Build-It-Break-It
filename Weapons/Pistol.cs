using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour {
    public GameObject projectile;
    public GameObject cam;
    public Text ammoCounter;

    public AudioSource audioSource;
    public AudioClip shootingSFX;

    float bulletSpeed = 20f;
    static int ammoCount = 20;
    static int startingAmmo;

    public static int GetAmmoCount() {
        return ammoCount;
    }
    
    // Use this for initialization
    void Start () {
        startingAmmo = ammoCount;
    }

    public static void ResetAmmo() {
        ammoCount = startingAmmo;
    }

    // Update is called once per frame
    void Update () {
        if (ammoCount > 0 && Input.GetButtonDown("Fire2")) {
            Vector3 offset = transform.forward * 0.5f;
            GameObject theBullet = (GameObject) Instantiate(projectile, cam.transform.position + offset, cam.transform.rotation);

            Physics.IgnoreCollision(theBullet.GetComponent<Collider>(), GetComponent<Collider>());
            theBullet.GetComponent<Rigidbody>().velocity = cam.transform.forward * bulletSpeed;
            
            Destroy(theBullet, 5.0f);
            ammoCount -= 1;
            audioSource.PlayOneShot(shootingSFX);
        }
        if (mode.currentMode != 2) {
            ammoCounter.text = "";
        } else {
            ammoCounter.text = "Pistol: " + ammoCount.ToString() + " / " + startingAmmo;
        }
    }
}