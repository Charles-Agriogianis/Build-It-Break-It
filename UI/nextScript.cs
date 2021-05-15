using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nextScript : MonoBehaviour
{
    public void OnButtonPress() {
        mode.currentLevel += 1;

        if (mode.currentLevel >= mode.scenes.Count) {
            mode.currentLevel = 0;
        }
    }
}
