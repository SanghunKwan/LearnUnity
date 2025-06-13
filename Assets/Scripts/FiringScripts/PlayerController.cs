using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform leftArm;
    public Transform rightArm;


    private void Update()
    {
        leftArm.Rotate(new Vector3(0, Input.GetAxis("Rot-Horiz"), 0));
        rightArm.Rotate(new Vector3(0, Input.GetAxis("Rot-Horiz2"), 0));


    }
}
