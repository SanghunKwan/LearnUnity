using UnityEngine;

public class InputObjectController : MonoBehaviour
{
    public float speed = 5;
    public float _rotAngle = 120;
    Transform _myTF;
    Camera _mainCam;
    Vector3 _goalPosition;
    Quaternion _targetRotation;


    private void Awake()
    {
        _myTF = transform;
        _goalPosition = _myTF.position;
        _targetRotation = _myTF.rotation;
    }
    private void Start()
    {
        GameObject go = GameObject.Find("Main Camera");
        _mainCam = go.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetMouseButtonDown(0); // 0: 좌클릭 1 :우클릭 2: 가운데
        //Input.GetButtonDown("Fire1"); // Fire1: 좌클릭 Fire2 :우클릭 Fire3: 가운데

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit rHit;

            if (Physics.Raycast(ray, out rHit))
            {
                _goalPosition = rHit.point;
                Debug.Log(_goalPosition);
                //_myTF.LookAt(_goalPosition);
                //Debug.Log(rHit.point);
            }
            //Debug.Log("클릭했음");
        }
        float deltaSpeed = speed * Time.deltaTime;
        if (Vector3.Distance(_myTF.position, _goalPosition) >= deltaSpeed)
        {
            _myTF.Translate(Vector3.forward * deltaSpeed);
            _targetRotation = Quaternion.LookRotation(_goalPosition - _myTF.position);
            _myTF.rotation = Quaternion.RotateTowards(_myTF.rotation, _targetRotation, 0.6f);
        }
        else
        {
            _myTF.position = _goalPosition;
        }
        //if (Vector3.Distance(_goalPosition, _myTF.position) < deltaSpeed)
        //    _myTF.position = _goalPosition;
        //else
        //    _myTF.position += (_goalPosition - _myTF.position).normalized * deltaSpeed;
    }
}
