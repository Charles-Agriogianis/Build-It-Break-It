using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speedFactor = 0.15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.gameOver) {
            // game is over 
            return;
        }

        if (Input.GetKey(KeyCode.W)) {
            this.transform.Translate(Vector3.forward * speedFactor);
        }

        if (Input.GetKey(KeyCode.A)) {
            this.transform.Translate(Vector3.left * speedFactor);
        }

        if (Input.GetKey(KeyCode.D)) {
            this.transform.Translate(Vector3.right * speedFactor);
        }

        if (Input.GetKey(KeyCode.S)) {
            this.transform.Translate(Vector3.back * speedFactor);
        }

        if (Input.GetKey(KeyCode.Space)) {
            this.transform.Translate(Vector3.up * speedFactor);
        }

        if (Input.GetKey(KeyCode.LeftShift) && this.transform.position.y >= 1.0) {
            this.transform.Translate(Vector3.down * speedFactor);
        }
    }
}
