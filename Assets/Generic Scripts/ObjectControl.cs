using UnityEngine;

public class ObjectControl : MonoBehaviour
{
    [Range(1f, 100f)] [SerializeField] float movementSpeed = 1f;
    [SerializeField] float rotationSpeed = 1f;



    void Update()
    {
        var y = Input.GetAxis("Horizontal") * rotationSpeed;
        var z = Input.GetAxis("Vertical") * 0.1f * movementSpeed;

        transform.Rotate(0, y, 0);
        transform.Translate(0, 0, z);
    }
}
