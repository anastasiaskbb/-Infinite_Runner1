using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    Animator animator;
    Rigidbody rigidbody;
    
    public bool right_move, left_move = false;
    public float targetPosition = 0;
    public float speed = 7;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        

        if(left_move)
        {
            
            if(transform.position.x>=targetPosition)
            {
                //rigidbody.AddForce(new Vector3(-1, 0, 0)*Time.fixedDeltaTime, ForceMode.Impulse);
                transform.Translate(new Vector3(-1, 0, 0) * Time.fixedDeltaTime*speed);
            }
            else
            {
                left_move = false;
            }
        }
        else if(right_move)
        {
            
            if (transform.position.x <= targetPosition)
            {
                //rigidbody.AddForce(new Vector3(1, 0, 0) * Time.fixedDeltaTime, ForceMode.Impulse);
                transform.Translate(new Vector3(1, 0, 0) * Time.fixedDeltaTime * speed);
            }
            else
            {
                right_move = false;
            }

        }
    }

    void Update()
    {
        AnimatorController();


        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (transform.position.x > -6)
            {
                targetPosition = transform.position.x - 6;
                left_move = true;

            }
        }

        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.position.x < 6)
            {
                targetPosition = transform.position.x + 6;
                right_move = true;
            }
        }
    }

    void AnimatorController()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("run_left", true);
            animator.SetBool("run_right", false);
        }

        else if(Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("run_right", true);
            animator.SetBool("run_left", false);
        }

        else
        {
            animator.SetBool("run_left", false);
            animator.SetBool("run_right", false);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("run_jump");
        }
    }



}
