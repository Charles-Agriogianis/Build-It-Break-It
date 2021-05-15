using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiController : MonoBehaviour
{
    public Canvas end;

    // Start is called before the first frame update
    void Start()
    {
    }


    public static void ResetGame() {
        Scoring.blocksLeft = 7;
        timer.Reset();
        mode.currentMode = mode.savedMode;
        buildHeightCheck.buildHeightReached = false;
        Pistol.ResetAmmo();
        Cannon.ResetAmmo();
        Shotgun.ResetAmmo();
    }


    // Update is called once per frame
    void Update()
    {
        if (timer.gameOver) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            end.gameObject.SetActive(true);
        } else {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            end.gameObject.SetActive(false);
        }
    }
}
