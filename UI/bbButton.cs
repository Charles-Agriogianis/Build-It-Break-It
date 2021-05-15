using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bbButton : MonoBehaviour
{

    public void OnButtonPress() {
        mode.currentMode = 0;
        mode.savedMode = 0;
        mode.currentMenu = 1;
    }
}
