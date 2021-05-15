using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class otherBackButton : MonoBehaviour
{
    public Canvas helpWindow;
    public Canvas other;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPress() {
        mode.currentMenu = 0;
        helpWindow.gameObject.SetActive(false);
        other.gameObject.SetActive(true);
    }

}
