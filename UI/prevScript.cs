using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prevScript : MonoBehaviour
{
    public void OnButtonPress() {
        mode.currentLevel -= 1;

        if (mode.currentLevel < 0) {
            mode.currentLevel = mode.scenes.Count - 1;
        }
    }
}
