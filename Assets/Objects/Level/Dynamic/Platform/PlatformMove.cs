using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] GameObject platformAnchor;
    [SerializeField] float movementSpeed = 0.1f;

    int targetLayer = 0;

    float Approach(float value1, float value2)
    {
        if (value2 > value1) {return  1f;}
        if (value2 < value1) {return -1f;}

        return 0f;
    }

    float Difference(float value1, float value2) { return (value1 > value2) ? (value1 - value2) : (value2 - value1); }

    void Start()
    {
        targetLayer = LayerMask.NameToLayer("Entities");
    }
    
    bool CheckLayer(Collider target)
    {
        if (target.gameObject.layer == targetLayer)
        {
            return true;
        }

        return false;
    }

    void Update()
    {
        float target_x = transform.position.x;
        float target_y = transform.position.y;
        float target_z = transform.position.z;

        bool snapped_x = false;
        bool snapped_y = false;
        bool snapped_z = false;

        if (Difference(transform.position.x, platformAnchor.transform.position.x) <= movementSpeed)
        {
            target_x = platformAnchor.transform.position.x;
            snapped_x = true;
        }

        if (Difference(transform.position.y, platformAnchor.transform.position.y) <= movementSpeed)
        {
            target_y = platformAnchor.transform.position.y;
            snapped_y = true;
        }

        if (Difference(transform.position.z, platformAnchor.transform.position.z) <= movementSpeed)
        {
            target_z = platformAnchor.transform.position.z;
            snapped_z = true;
        }


        float move_x = Approach(transform.position.x, platformAnchor.transform.position.x) * movementSpeed;
        float move_y = Approach(transform.position.y, platformAnchor.transform.position.y) * movementSpeed;
        float move_z = Approach(transform.position.z, platformAnchor.transform.position.z) * movementSpeed;

        if (!snapped_x) { target_x = transform.position.x + move_x; }
        if (!snapped_y) { target_y = transform.position.y + move_y; }
        if (!snapped_z) { target_z = transform.position.z + move_z; }
        

        transform.position = new Vector3(target_x, target_y, target_z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CheckLayer(other))
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (CheckLayer(other))
        {
            other.transform.parent = null;
        }
    }
}
