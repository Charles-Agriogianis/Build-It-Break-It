using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSphere : Block
{
    // Calculation based on volume of a cube. Change for subclasses that are different shapes
    protected override void CalculateVolume() {
        Vector3 size = GetComponent<MeshFilter>().mesh.bounds.size;
        Vector3 scale = transform.localScale;
        size.x *= scale.x; // diameter 1
        size.y *= scale.y; // diameter 2
        size.z *= scale.z; // diameter 3
        volume = 3.14f * 4 / 3 * size.x / 2 * size.y / 2 * size.z / 2; // (4/3 pi * radius_1 * radius_2 * radius_3)
    }
}
