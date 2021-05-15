using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSelection : MonoBehaviour
{
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject canon;
    bool noneSelected = true;
    // Start is called before the first frame update
    void Start()
    {
        DisableAllGuns();
        EnableShotgun();
    }

    // Update is called once per frame
    void Update()
    {
        if (mode.currentMode == 2 && timer.gameOver == false) {
            if (noneSelected) {
                EnableShotgun();
                noneSelected = false;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)) {
                DisableAllGuns();
                EnablePistol();
            } else if (Input.GetKeyDown(KeyCode.Alpha1)) {
                DisableAllGuns();
                EnableShotgun();
            } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
                DisableAllGuns();
                EnableCanon();
            }
        } else {
            DisableAllGuns();
        }
    }

    void DisableAllGuns() {
        GetComponent<Pistol>().enabled = false;
        GetComponent<Shotgun>().enabled = false;
        GetComponent<Cannon>().enabled = false;

        pistol.SetActive(false);
        shotgun.SetActive(false);
        canon.SetActive(false);
    }

    void EnablePistol() {
        GetComponent<Pistol>().enabled = true;
        pistol.SetActive(true);
    }

    void EnableShotgun() {
        GetComponent<Shotgun>().enabled = true;
        shotgun.SetActive(true);
    }

    void EnableCanon() {
        GetComponent<Cannon>().enabled = true;
        canon.SetActive(true);
    }
}
