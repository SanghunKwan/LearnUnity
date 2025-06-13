using UnityEngine;

public class GameBoxController : MonoBehaviour
{
    float _gravity;
    float _gScale = 1;

    private void Awake()
    {
        _gravity = Physics.gravity.magnitude;
    }

    private void Update()
    {
        float rx = Input.GetAxis("Horizontal");
        float rz = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(rx, -1, rz);

        Physics.gravity = dir * (_gravity * _gScale);


    }


}
