using UnityEngine;
public class Camera_Follow_Generic : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float distance_z = 6f;
    [SerializeField] float distance_y = 0f;
    [SerializeField] float speed = 0.1f;

    void Update()
    {
        Vector3 lookOnObject = target.position - transform.position;
        transform.forward = lookOnObject.normalized;

        Vector3 targetPosition = target.position - (transform.forward * distance_z);
        targetPosition.y = target.position.y + (distance_y / 2);

        transform.position = Vector3.Lerp(transform.position, targetPosition, speed);
    }
}
