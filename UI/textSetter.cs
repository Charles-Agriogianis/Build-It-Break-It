using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textSetter : MonoBehaviour
{
    public Text score;
    public Text title;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        title.text = mode.scenes[mode.currentLevel].ToString();
    }
}
