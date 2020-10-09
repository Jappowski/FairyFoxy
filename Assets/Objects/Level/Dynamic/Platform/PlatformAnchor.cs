using UnityEngine;

public class PlatformAnchor : MonoBehaviour
{
    //|Declare locations to which the anchor will teleport to.

    [SerializeField] Vector3[] targetLocations;

    [SerializeField] int waitTimer = 360;
    int waitTimer_current = 0;
    int targetLocation_current = 0;

    void Update()
    {
        waitTimer_current++;

        if (waitTimer_current >= waitTimer)
        {
            //|Toggle the possition in array and wrap it.
            targetLocation_current++;

            if (targetLocation_current > (targetLocations.Length - 1))
            {
                targetLocation_current = 0;
            }

            waitTimer_current = 0;
        }

        transform.position = targetLocations[targetLocation_current];
    }
}
