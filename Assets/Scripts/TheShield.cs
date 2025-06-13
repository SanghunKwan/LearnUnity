using UnityEngine;

public class TheShield : MonoBehaviour
{
    public GameObject blockEffect;
    public GameObject passEffect;

    public float delayTime;



    //충돌 시 50% 확률로 막음.
    //막지 못했을 때 나가면서 이펙트.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HeatVision"))
        {
            if (CheckCollisionChance())
            {
                //막음
                GameObject effect = Instantiate(blockEffect, other.transform.position, Quaternion.identity);
                Destroy(effect, delayTime);
                Debug.Log("enter 막음");
                other.attachedRigidbody.linearVelocity = Vector3.zero;
                Destroy(other.gameObject, delayTime);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HeatVision"))
        {
            Physics.Raycast(other.transform.position, -other.attachedRigidbody.linearVelocity, out RaycastHit hit);
            GameObject effect = Instantiate(passEffect, hit.point, Quaternion.identity);
            Destroy(effect, delayTime);
        }
    }


    bool CheckCollisionChance()
    {
        return System.Convert.ToBoolean(Random.Range(0, 2));
    }
}
