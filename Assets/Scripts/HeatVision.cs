using UnityEngine;

public class HeatVision : MonoBehaviour
{
    public float _force = 1;
    public float _lifeTime = 4;
    float cumulativeTime;

    Rigidbody _rgbd3d;

    public void Awake()
    {
        _rgbd3d = GetComponent<Rigidbody>();
        _rgbd3d.AddForce(transform.forward * _force);

        //Destroy(gameObject, _lifeTime);
        cumulativeTime = Time.time;
    }
    public void Update()
    {
        //cumulativeTime += Time.deltaTime;

        //if (cumulativeTime >= _lifeTime)
        //if(Time.time - cumulativeTime >= _lifeTime)
        if (Time.time > cumulativeTime + _lifeTime)
            Destroy(gameObject);
    }
}
