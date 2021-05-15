using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mode : MonoBehaviour
{
    // 0 = Build/break
    // 1 = Build
    // 2 = Break
    public static int currentMode = 0; 
    public static int currentLevel = 0;
    public static int currentMenu = 0;
    public static int savedMode = 0;
    public static List<string> scenes;
    public List<string> localScenes;
    public Canvas first;
    public Canvas second;

    // Start is called before the first frame update
    void Start()
    {
        scenes = localScenes;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMenu == 0) {
            first.gameObject.SetActive(true);
            second.gameObject.SetActive(false);
        } else if (currentMenu == 1) {
            first.gameObject.SetActive(false);
            second.gameObject.SetActive(true);
        }
    }
}
