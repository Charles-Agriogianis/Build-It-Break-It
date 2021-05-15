using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isTriggered : MonoBehaviour
{
    public static bool contact = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        contact = true;
    }

    private void OnTriggerExit(Collider other) {
        contact = false;
    }
}
