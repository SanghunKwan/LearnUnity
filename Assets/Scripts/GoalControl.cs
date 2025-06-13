using UnityEngine;

public class GoalControl : MonoBehaviour
{
    public string _checkFlag;
    private void OnTriggerStay(Collider other)
    {
        Vector3 dir = transform.position - other.transform.position;
        Rigidbody rgdb3d = other.GetComponent<Rigidbody>();
        if (other.CompareTag(_checkFlag))
        {
            rgdb3d.linearVelocity *= 0.9f;
            rgdb3d.AddForce(dir * rgdb3d.mass * 20);
        }
        else
        {

            rgdb3d.AddForce(-dir * rgdb3d.mass * 80);
        }

    }
    private void OnCollisionStay(Collision collision)
    {
        Vector3 dir = transform.position - collision.transform.position;
        Rigidbody rgdb3d = collision.transform.GetComponent<Rigidbody>();
        rgdb3d.AddForce(-dir * rgdb3d.mass * 80);
    }
}
