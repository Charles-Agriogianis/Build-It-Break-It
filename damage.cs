using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour {
    Vector3 zeroVector = new Vector3(0.0f,0.0f,0.0f);
    int cannonMultiplier = 10;
    int pistolMultiplier = 2;
    int shotgunMultiplier = 1;
    Block blockScript;

    void Start() {
        blockScript = this.GetComponent<Block>();
    }

    void OnCollisionEnter (Collision other) {
        if (other.gameObject.GetComponent<Rigidbody>() == null) {
            return;
        }
        
        var rb = other.gameObject.GetComponent<Rigidbody>();
        var velocity = rb.velocity;
        var velocityMultiplier = (int)Vector3.Distance(zeroVector, velocity);
        
        if (other.gameObject.tag == "Cannonball") {
            Debug.Log("damage = " + cannonMultiplier * velocityMultiplier);
            blockScript.TakeDamage(cannonMultiplier * velocityMultiplier);
        }
        
        if (other.gameObject.tag == "PistolBullet") {
            Debug.Log("damage = " + pistolMultiplier * velocityMultiplier);
            blockScript.TakeDamage(pistolMultiplier* velocityMultiplier);
        }
        
        if (other.gameObject.tag == "ShotgunPellet") {
            Debug.Log("damage = " + shotgunMultiplier * velocityMultiplier);
            blockScript.TakeDamage(shotgunMultiplier * velocityMultiplier);
        }
    }
}