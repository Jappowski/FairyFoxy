using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Range( 0f, 1f)][SerializeField] float jump_single_force = 0.6f;
    [Range( 0f, 1f)][SerializeField] float jump_single_multiplier = 0.9f;
    [Range( 0f, 1f)][SerializeField] float jump_double_force = 0.7f;
    [Range( 0f, 1f)][SerializeField] float jump_double_multiplier = 0.9f;
    [Range(-2f, 0f)][SerializeField] float jump_double_knockback = -1f;
    [Range( 0f, 1f)][SerializeField] float jump_double_knockback_multiplier = 0.7f;

    [Range(1f, 100f)][SerializeField] float rotationSpeed = 1f;
    [Range(1f, 100f)][SerializeField] float movementSpeed = 1f;

    [Range(1f, 10f)][SerializeField] float groundCheckDistance = 1.5f;
    [Range(1f, 10f)][SerializeField] float groundCheckDistance_slopes = 3f;

    float gravity = -0.1f;

    float speed_y;
    float speed_jump;
    float speed_jump_knockback;

    int jump_refresh = 0;
    int jump_refresh_max = 2;
    int jump_timer = 0;

    int ground_timer = 0;

    LayerMask layerMask_slopes;

    private void Start()
    {
    
        layerMask_slopes = LayerMask.GetMask("Slopes");
    }

    void Jump(bool jumpTrigger)
    {
        bool grounded = IsGrounded(speed_y);

        Debug.Log(jump_refresh);

        if (jumpTrigger)
        {
            if (grounded)
            {
                if (jump_refresh >= jump_refresh_max)
                {
                    speed_jump = jump_single_force;
                    jump_refresh--;
                    ground_timer = 0;
                }
            }
            else if ((jump_refresh == 1) && (jump_timer >= 10))
            {
                speed_jump = jump_double_force;
                speed_jump_knockback = jump_double_knockback;
                jump_refresh--;
            }
        }

        jump_timer = speed_jump > 0 ? jump_timer + 1 : 0;

        speed_jump *= ((jump_refresh == 1) ? jump_single_multiplier : jump_double_multiplier);
        speed_jump = CutDecimals(speed_jump);

        speed_jump_knockback *= jump_double_knockback_multiplier;
        speed_jump_knockback  = CutDecimals(speed_jump_knockback);
    }

    float CutDecimals(float value) {return (value == Mathf.Clamp(value, 0f, 0.0001f) ? 0 : value);}
    float Movement_Z() {return Input.GetAxis("Vertical") * 0.1f * movementSpeed;}
    float Rotation_Y() {return Input.GetAxis("Horizontal") * rotationSpeed;}
    bool IsGrounded(float speed_y) 
    {
        if (Physics.Raycast(transform.position, Vector3.down, speed_y + groundCheckDistance))
        {
            return true;
        }

        if (Movement_Z() >= 0)
        {
            if (Physics.Raycast(transform.position, Vector3.down, speed_y + groundCheckDistance_slopes, layerMask_slopes))
            {
                return true;
            }
        }
        else
        {
            if (Physics.Raycast(transform.position, Vector3.down, speed_y + 1f, layerMask_slopes))
            {
                return true;
            }
        }

        return false;
    }

    void Update()
    {
        Jump(Input.GetButtonDown("Jump"));

        if (IsGrounded(speed_y))
        {
            ground_timer++;
            
        }
        else
        {
            ground_timer = 0;
        }

        if (ground_timer >= 10)
        {
            jump_refresh = jump_refresh_max;
        }

        speed_y = speed_jump + (IsGrounded(speed_y) ? 0 : gravity);
        transform.Translate(0, speed_y, Movement_Z() + speed_jump_knockback);
        transform.Rotate(0, Rotation_Y(), 0);


     
    }
}