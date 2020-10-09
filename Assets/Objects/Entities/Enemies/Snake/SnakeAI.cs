using UnityEngine;

public class SnakeAI : MonoBehaviour
{
    private Animator animator;
    [SerializeField] bool playAnimation_movement;
    [SerializeField] bool playAnimation_attack;


    [SerializeField] float playerDetectionRadius;

    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;

    public GameObject player;
    float starting_y;

    enum State { wander, edge, noticePlayer, chaseWait, chase };
    State currentState;


    //|Direction randomness variables
    int directionTimer = 0;
    int directionTimer_bound = 0;
    int directionTimer_range_min = 30;
    int directionTimer_range_max = 100;

    int direction = 0;

    //|Edge State
    int edgeTimer = 0;
    int edgeTimer_max = 60;

    //|Player Notice State
    Vector3 playerLocation;

    float jumpHeight = 10f;

    int noticeTimer = 0;
    int noticeTimer_max = 6;

    //|Chase Wait
    int chaseWaitTimer = 0;
    int chaseWaitTimer_max = 20;

    //|Chase
    int chaseTimer = 0;
    int chaseTimer_max = 100;

    void rotate()
    {
        float rotation_x = direction * (Time.deltaTime * 150.0f * rotationSpeed);

        if (direction != 0)
        {
            transform.Rotate(0f, rotation_x, 0f);
        }
    }

    void directionRandomization(bool trigger)
    {
        if ((directionTimer < directionTimer_bound) && !trigger)
        {
            directionTimer++;
        }
        else
        {
            direction = Random.Range(-1, 2);

            directionTimer_bound = Random.Range(directionTimer_range_min, directionTimer_range_max + 1);
            directionTimer = 0;
        }
    }

    void moveForward()
    {
        var movement = Time.deltaTime * movementSpeed;

        transform.Translate(0, 0, movement);
    }

    void lookAt(Vector3 target, int damping)
    {
        target.y = 0;
        var rotation = Quaternion.LookRotation(target);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }

    void chase(Vector3 target, float chaseSpeed)
    {
        lookAt(target, 1);

        Vector3 raycastTarget = (transform.TransformDirection(Vector3.down) * 10) + (transform.TransformDirection(Vector3.forward) * 20);
        Debug.DrawRay(transform.position, raycastTarget, Color.green);

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.x, starting_y, target.z), chaseSpeed);
    }

    bool groundCheck()
    {
        RaycastHit hit;
        Vector3 raycastTarget = (transform.TransformDirection(Vector3.down) * 10) + (transform.TransformDirection(Vector3.forward) * 20);
        Debug.DrawRay(transform.position, raycastTarget, Color.red);

        if (Physics.Raycast(transform.position, raycastTarget, out hit))
        {
            return true;
        }

        return false;
    }

    bool playerDetect()
    {
        Collider[] playerCollider = Physics.OverlapSphere(transform.position, playerDetectionRadius, LayerMask.GetMask("Player"));

        if (playerCollider.Length >= 1)
        {
            return true;
        }

        return false;
    }

    void Start()
    {
        starting_y = transform.position.y;
        currentState = State.wander;
        animator = (Animator)GetComponent<Animator>();
    }

    void Update()
    {
        if (playAnimation_movement)
        {
            animator.SetTrigger("move");
        }

        if (playAnimation_attack)
        {
            animator.SetTrigger("attack");
        }

        playAnimation_movement = false;


        switch (currentState)
        {
            case State.wander:
                directionRandomization(false);
                rotate();

                if (groundCheck())
                {
                    moveForward();
                    playAnimation_movement = true;
                }
                else
                {
                    directionRandomization(true);
                    currentState = State.edge;
                }

                if (playerDetect())
                {
                    currentState = State.noticePlayer;
                }
                break;

            case State.edge:
                if (edgeTimer < edgeTimer_max)
                {
                    edgeTimer++;
                    rotate();
                }
                else
                {
                    edgeTimer = 0;
                    currentState = State.wander;
                }
                break;

            case State.noticePlayer:
                if (noticeTimer < noticeTimer_max)
                {
                    noticeTimer++;

                    playerLocation = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                    transform.Translate(Vector3.up * jumpHeight * Time.deltaTime, Space.World);
                }
                else
                {
                    noticeTimer = 0;

                    currentState = State.chaseWait;
                }
                break;

            case State.chaseWait:
                if (chaseWaitTimer < chaseWaitTimer_max)
                {
                    chaseWaitTimer++;
                    lookAt(playerLocation, 1);
                }
                else
                {
                    chaseWaitTimer = 0;

                    currentState = State.chase;
                }
                break;

            case State.chase:
                bool groundCheck_down = groundCheck();

                if (chaseTimer < chaseTimer_max)
                {
                    chaseTimer++;

                    if (groundCheck_down)
                    {
                        chase(playerLocation, 0.1f);
                    }
                }

                if ((chaseTimer >= chaseTimer_max) || !groundCheck_down)
                {
                    chaseTimer = 0;
                    currentState = State.wander;
                }
                break;


        }
    }
}
