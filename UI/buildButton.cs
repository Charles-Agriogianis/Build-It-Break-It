using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buildButton : MonoBehaviour
{

    public void OnButtonPress() {
        mode.currentMode = 1;
        mode.savedMode = 1;
        mode.currentMenu = 1;
    }
}
