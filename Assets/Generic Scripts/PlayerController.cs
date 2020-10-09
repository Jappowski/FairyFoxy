using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(1f, 100f)] [SerializeField] float movementSpeed = 1f;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] Rigidbody rb;
    [SerializeField] float jumpHeight;

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f * rotationSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f * movementSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

    }
}