using UnityEngine;

public class TesterWeapon : MonoBehaviour
{
    [SerializeField] float weaponRotateSpeed = 60;
    [SerializeField] float maxAngle;
    [SerializeField] float minAngle;
    float calMaxAngle;
    bool isOver90;

    Transform tr;
    private void Awake()
    {
        tr = transform;
        isOver90 = maxAngle >= 90;
        calMaxAngle = 360 - maxAngle;
    }

    void Update()
    {
        WeaponMove(Input.GetAxisRaw("Rot-Horiz"));
        Debug.Log(tr.eulerAngles.x);
    }
    void WeaponMove(float buttonFloat)
    {

        float beforeAngle = tr.eulerAngles.x;
        tr.Rotate(Vector3.right, buttonFloat * weaponRotateSpeed * Time.deltaTime);
        float currentAngle = tr.eulerAngles.x;

        if (currentAngle > 180)
        {
            if (isOver90)
            {
                //right 방향으로 회전할 때 before보다 current 가 더 크면 체크.
                if (buttonFloat > 0 && beforeAngle > currentAngle)
                    tr.rotation = Quaternion.Euler(calMaxAngle, 0, 0);
            }
            else
            {
                if (currentAngle < calMaxAngle)
                    tr.rotation = Quaternion.Euler(calMaxAngle, 0, 0);
            }
        }
        else
        {
            if (currentAngle > minAngle)
                tr.rotation = Quaternion.Euler(minAngle, 0, 0);
        }
    }
}
