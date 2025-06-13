using UnityEngine;

public class ProjectileObject : MonoBehaviour
{
    public Rigidbody rb;
    public Renderer rd;
    ShootManager sm;

    public void SetProjectile(in Vector3 force, Material mat, ShootManager manager)
    {
        rd.material = mat;
        rb.AddForce(force);
        sm = manager;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HeatVision"))
        {
            other.attachedRigidbody.linearVelocity = Vector3.zero;
            Destroy(other.gameObject, 0.3f);
            Destroy(gameObject, 0.3f);
            sm.CallEffect(transform.position);
        }
    }
}
