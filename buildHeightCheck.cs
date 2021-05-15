using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class buildHeightCheck : MonoBehaviour
{
    public static bool buildHeightReached = false;
    bool stillActive = false;
    DateTime dt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stillActive && DateTime.Now > dt.AddSeconds(5)) {
            buildHeightReached = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ignoreForHeight") {
            return;
        }
        dt = System.DateTime.Now;
        stillActive = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ignoreForHeight") {
            return;
        }
        if (DateTime.Now > dt.AddSeconds(5)) {
            buildHeightReached = true;
        } else {
            stillActive = false;
        }
    }
}
