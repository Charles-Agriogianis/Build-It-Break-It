using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCube : Block
{
    protected override void CalculateVolume() {
        Vector3 size = GetComponent<MeshFilter>().mesh.bounds.size;
        Vector3 scale = transform.localScale;
        size.x *= scale.x;
        size.y *= scale.y;
        size.z *= scale.z;
        volume = size.x * size.y * size.z;
    }
}
