using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Rotate : MonoBehaviour
{

    public float sensitivity = 150f;
    public Transform rb;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        rb.Rotate(Vector3.up * mouseX);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 15f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
}
