using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour {
    public GameObject projectile;
    public GameObject cam;
    public Text ammoCounter;

    public AudioSource audioSource;
    public AudioClip shootingSFX;

    float bulletSpeed = 20f;
    static int ammoCount = 50;
    static int startingAmmo;
    //int weaponEquipped = 1;

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
        if (ammoCount > 4 && Input.GetButtonDown ("Fire2")) {

            for (int i = 0; i < 5; i++) {
                Vector3 randomVec = new Vector3 (Random.Range(-0.4f, 0.4f), Random.Range(-0.4f, 0.4f), Random.Range(-0.4f, 0.4f));
                Vector3 offset = transform.forward * 1.3f;
                GameObject theBullet = (GameObject) Instantiate(projectile, cam.transform.position + randomVec + offset, cam.transform.rotation);

                Physics.IgnoreCollision(theBullet.GetComponent<Collider>(), GetComponent<Collider>());
                theBullet.GetComponent<Rigidbody>().velocity = cam.transform.forward * bulletSpeed;
                Destroy(theBullet, 5.0f);
                ammoCount -= 1;
            }
            audioSource.volume = 0.25f;
            audioSource.PlayOneShot(shootingSFX);
        }
        
        if (mode.currentMode != 2) {
            ammoCounter.text = "";
        } else {
            ammoCounter.text = "Shotgun: " + ammoCount.ToString() + " / " + startingAmmo;
        }
    }
}