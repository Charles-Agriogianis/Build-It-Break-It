using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class breakButton : MonoBehaviour
{

    public void OnButtonPress() {
        mode.currentMode = 2;
        mode.savedMode = 2;
        mode.currentMenu = 1;
    }
}
