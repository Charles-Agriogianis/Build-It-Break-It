using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : Item
{
    public float density;
    public float hpDensity = 100.0f; 
    public Material break1;
    public Material break2;
    public Material break3;

    private float currHP;
    private bool notDead = true;

    /* The following variables are calculated based on the block's properties during runtime.
    */
    protected float maxHP; // hpDensity * volume
    protected float volume;
    protected float mass; // density * volume

    public void TakeDamage(float damage) {
        currHP -= damage;
        if (currHP <= 0) {
            currHP = 0;
        }

        // Update break decal (how broken the block looks)
        if (currHP < maxHP && currHP > 2 * maxHP / 3) {
            Material[] mats = new Material[2]; // initialize material array of size 2
            mats[0] = GetComponent<MeshRenderer>().materials[0];
            mats[1] = break1;
            GetComponent<MeshRenderer>().materials = mats;
        } else if (currHP < 2 * maxHP / 3 && currHP > maxHP / 3) {
            Material[] mats = new Material[2]; // initialize material array of size 2
            mats[0] = GetComponent<MeshRenderer>().materials[0];
            mats[1] = break2;
            GetComponent<MeshRenderer>().materials = mats;
        } else if (currHP < maxHP / 3 && currHP > 0) {
            Material[] mats = new Material[2]; // initialize material array of size 2
            mats[0] = GetComponent<MeshRenderer>().materials[0];
            mats[1] = break3;
            GetComponent<MeshRenderer>().materials = mats;
        } else if (currHP == 0 && notDead) {
            notDead = false;
            Scoring.blocksLeft--;
            Debug.Log("left: "+ Scoring.blocksLeft);
            Die();
        }
    }

    protected virtual void Die() {
        Destroy(gameObject);
    }

    private void CalculateMass() {
        mass = density * volume;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = mass;
        maxHP = hpDensity * (float) Math.Sqrt((double) volume);
    }

    // Calculation based on volume of a cube. Change for subclasses that are different shapes
    protected abstract void CalculateVolume();

    // Start is called before the first frame update
    protected virtual void Start() {
        CalculateVolume();
        CalculateMass();
        currHP = maxHP;
    }

    protected virtual void Update() {
    }
}
