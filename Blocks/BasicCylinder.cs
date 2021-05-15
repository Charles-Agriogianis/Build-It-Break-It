using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCylinder : Block
{
    protected override void CalculateVolume() {
        Vector3 size = GetComponent<MeshFilter>().mesh.bounds.size;
        Vector3 scale = transform.localScale;
        size.x *= scale.x; // diameter 1
        size.y *= scale.y; // height
        size.z *= scale.z; // diameter 2
        volume = 3.14f * size.x / 2 * size.y * size.z / 2; // (pi * radius_1 * radius_2 * height)
    }
}
