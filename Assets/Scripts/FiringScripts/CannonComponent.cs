using UnityEngine;

public class CannonComponent : MonoBehaviour
{
    //random 발사각, 발사 속도
    [SerializeField] Transform spawnPoint;

    public void Shoot(Rigidbody shootObject)
    {
        shootObject.transform.position = spawnPoint.position;
        shootObject.AddForce(GetDirection() * GetMagnitude());
    }
    Vector3 GetDirection()
    {
        return (spawnPoint.up + Random.Range(-1, 2) * Vector3.up).normalized;
    }
    float GetMagnitude()
    {
        return Random.Range(10f, 13f) * 50;

        //return 650;
    }
}
