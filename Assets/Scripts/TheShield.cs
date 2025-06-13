using UnityEngine;

public class TheShield : MonoBehaviour
{
    public GameObject blockEffect;
    public GameObject passEffect;

    public float delayTime;



    //�浹 �� 50% Ȯ���� ����.
    //���� ������ �� �����鼭 ����Ʈ.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HeatVision"))
        {
            if (CheckCollisionChance())
            {
                //����
                GameObject effect = Instantiate(blockEffect, other.transform.position, Quaternion.identity);
                Destroy(effect, delayTime);
                Debug.Log("enter ����");
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
