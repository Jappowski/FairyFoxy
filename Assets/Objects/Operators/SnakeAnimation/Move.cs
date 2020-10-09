using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] GameObject snake;
    private Animator animator;
    [SerializeField] bool playAnimation_movement;
    [SerializeField] bool playAnimation_attack;
    bool IsMoved = false;
    Vector3 p1;
    Vector3 p2;
    // Start is called before the first frame update
    void Start()
    {
        animator = (Animator)snake.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playAnimation_movement)
        {
            animator.SetTrigger("move");
        }

        if(playAnimation_attack)
        {
            animator.SetTrigger("attack");
        }

      
    }

    //private void IsThisObjectInMove()
    //{
    //    p1 = transform.position;
    //    yield return new WaitForSeconds(1f);
    //    p2 = transform.position;

    //    if (p1.x != p2.x || p1.y != p2.y || p1.z != p2.z)
    //        IsMoved = true;
    //    else
    //        IsMoved = false;
    //}
}
