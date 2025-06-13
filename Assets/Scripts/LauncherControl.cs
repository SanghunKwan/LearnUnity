using UnityEngine;

public class LauncherControl : MonoBehaviour
{
    public GameObject _prefabVisionObj;
    public Transform _leftPos;
    public Transform _rightPos;
    public float _delayTime = 1f;
    float beforeTime;

    private void Awake()
    {
        beforeTime = Time.time - _delayTime;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && beforeTime + _delayTime <= Time.time)
        {
            Instantiate(_prefabVisionObj, _leftPos.position, _leftPos.rotation);
            Instantiate(_prefabVisionObj, _rightPos.position, _rightPos.rotation);
            beforeTime = Time.time;
        }

    }
}
