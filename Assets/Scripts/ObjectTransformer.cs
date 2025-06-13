using UnityEngine;

public class ObjectTransformer : MonoBehaviour
{
    public float speed = 5;
    public float _rotAngle = 120;
    Transform _myTF;

    private void Awake()
    {
        _myTF = transform;
    }
    //오브젝트의 기본 이동 실습
    //void Update()
    //{
    //    //Time.time      : 
    //    //Time.deltaTime : 
    //    //float deltaDistance = speed * Time.deltaTime;//단위 거리 / 프레임 타임 = 프레임 당 이동할 거리
    //    //transform.position += transform.rotation * Vector3.forward * deltaDistance;
    //    MovementObj(speed * speed * Time.deltaTime, Vector3.forward);
    //}

    private void Update()
    {
        //var mz = Input.GetAxisRaw("Vertical"); -1, 0, 1
        float mz = Input.GetAxis("Vertical");
        float mx = Input.GetAxis("Horizontal");
        float ry = Input.GetAxis("Rot-Horiz");

        //Debug.Log(mz);
        Vector3 dir = new Vector3(mx, 0, mz);
        dir = dir.magnitude > 1 ? dir.normalized : dir;
        TransformObj(speed * Time.deltaTime, _rotAngle * Time.deltaTime * ry, dir, Vector3.up);
        //float deltaRotate = _rotAngle * Time.deltaTime * ry;
        //_myTF.rotation *= Quaternion.Euler(0, deltaRotate, 0);
    }
    void TransformObj(float deltaDistance, float deltaRotate, Vector3 dir, Vector3 rotAxis)
    {
        //_myTF.position += _myTF.rotation * dir * deltaDistance;
        _myTF.Translate(dir * deltaDistance);
        //Vector3 rot = rotAxis * deltaRotate;
        //_myTF.rotation *= Quaternion.Euler(rot);
        _myTF.Rotate(rotAxis * deltaRotate);
    }
}
