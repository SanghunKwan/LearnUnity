using UnityEngine;

public class TesterEx1 : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] float rotateSpeed = 120;

    Transform tr;
    [SerializeField] Transform weaponTransform;

    private void Awake()
    {
        tr = transform;
    }
    void Update()
    {
        var moveVec = Vector3.forward * Input.GetAxis("Vertical");
        ObjectMove(moveVec, Input.GetAxis("Horizontal"));
    }
    void ObjectMove(Vector3 vec, float buttonFloat)
    {
        tr.Translate(vec * speed * Time.deltaTime);
        tr.Rotate(Vector3.up, buttonFloat * rotateSpeed * Time.deltaTime);
    }
}
