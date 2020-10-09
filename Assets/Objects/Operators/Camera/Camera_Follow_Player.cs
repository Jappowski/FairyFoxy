using UnityEngine;
public class Camera_Follow_Player : MonoBehaviour
{
    /*** Script Source: https://www.youtube.com/watch?v=qHdZ6JtKahk ***/

    public GameObject player;
    [Range(1f, 50f)][SerializeField] float distance_z = 15f;
    [Range(1f, 50f)][SerializeField] float distance_y = 9f;
    [Range(0f,  1f)][SerializeField] float smoothing  = 0.7f;
    [Range(1f, 50f)][SerializeField] float speed = 30f;

    Vector3 targetPosition;

    Vector3 CalculatePlayerBack()
    {
        return player.transform.position - new Vector3((player.transform.forward.x * distance_z), (player.transform.forward.y - 1.0f), (player.transform.forward.z * distance_z)); ;
    }

    void Start()
    {
        transform.position = CalculatePlayerBack();
    }

    void Update()
    {
        Vector3 position_playerBack = CalculatePlayerBack();

        targetPosition   = Vector3.MoveTowards(transform.position, position_playerBack, (speed * Time.deltaTime));
        targetPosition.y = player.transform.position.y + (distance_y / 2);

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        
        transform.LookAt(player.transform);
    }
}
