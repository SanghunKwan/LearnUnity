using System.Threading.Tasks;
using UnityEngine;

public class TheWall : MonoBehaviour
{
    public GameObject _prefabHit;
    public GameObject _prefabDeath;
    public int _durationCount = 8;
    int hitCount;
    const float _destoryTime = 0.5f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HeatVision"))
        {
            GameObject go = Instantiate(_prefabHit, other.transform.position, Quaternion.identity);
            other.attachedRigidbody.linearVelocity = Vector3.zero;
            Destroy(other.gameObject, 0.3f);
            Destroy(go, _destoryTime);
            hitCount++;

            if (hitCount >= _durationCount)
            {
                GameObject deathEffect = Instantiate(_prefabDeath, transform.position, Quaternion.identity);
                Clear();
                Destroy(deathEffect, _destoryTime);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = Instantiate(_prefabHit, collision.transform.position, Quaternion.identity);
        Destroy(collision.gameObject, 0.3f);
        Destroy(go, _destoryTime);
        hitCount++;

        if (hitCount >= _durationCount)
        {
            GameObject deathEffect = Instantiate(_prefabDeath, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            Destroy(deathEffect, _destoryTime);



        }
    }
    async void Clear()
    {
        hitCount = 0;
        gameObject.SetActive(false);
        await Task.Delay(3000);

        gameObject.SetActive(true);
    }
}
