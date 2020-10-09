using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxAnimation : MonoBehaviour
{
    [SerializeField] GameObject fox;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = (Animator)fox.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w"))
        {
            animator.SetTrigger("move");
        };
        if (Input.GetKey("s"))
        {
            animator.SetTrigger("move");
        };
        if (Input.GetKey("a"))
            {
            animator.SetTrigger("turnLeft");
        }
        if (Input.GetKey("d"))
        {
            animator.SetTrigger("turnRight");
        };


    }
}
