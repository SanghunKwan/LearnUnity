using UnityEngine;

public class ShootManager : MonoBehaviour
{
    public CannonComponent[] cannons;
    public Rigidbody body;

    private void Start()
    {
        Debug.Log(cannons[0]);
        cannons[0].Shoot(body);
    }
}
