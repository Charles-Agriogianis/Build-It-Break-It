using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveCube : Block
{
    public float radius = 5.0f;
    public float power = 1000.0f;

    public AudioSource explosionSound;

    protected override void CalculateVolume() {
        Vector3 size = GetComponent<MeshFilter>().mesh.bounds.size;
        Vector3 scale = transform.localScale;
        size.x *= scale.x;
        size.y *= scale.y;
        size.z *= scale.z;
        volume = size.x * size.y * size.z;
    }

    protected override void Die() {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        foreach (Collider hit in colliders) {
            Rigidbody body = hit.GetComponent<Rigidbody>();

            if (body != null) {
                body.AddExplosionForce(power, explosionPos, radius, 3.0F);
                Block temp = body.gameObject.GetComponent<Block>();
                if (temp != null) {
                    temp.TakeDamage(power / 25.0f);
                }
            }
        }

        Destroy(gameObject);
    }
}
