using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    Animator animator;
    Rigidbody rigidbody;
    bool wannaJump = false;
    int Moneys = 0;

    public Text score;

    public GameObject Panel;

    public float targetPosition = 0;
    public float speed = 400;
    
    void Start()
    {

        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(new Vector3(0, Physics.gravity.y * 4, 0), ForceMode.Acceleration);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddForce(-transform.right * speed * Time.fixedDeltaTime, ForceMode.Impulse);
            
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddForce(transform.right * speed * Time.fixedDeltaTime, ForceMode.Impulse);
        }

        if(wannaJump && isGrounded())
        {

            rigidbody.AddForce(new Vector3(0, 20, 0), ForceMode.Impulse);
            wannaJump = false;
        }
    }

    void Update()
    {
        AnimatorController();

        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Vector3.down* 1.1f,Color.red);

        if (isGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                wannaJump = true;
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


    bool isGrounded()
    {
        return Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Vector3.down, 1.1f);

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Money"))
        {
            Destroy(col.gameObject);
            Moneys++;

            score.text = Moneys.ToString();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag(" Obstacle"))
        {
            Panel.SetActive(true);

            life.lifeHero = false;

            gameObject.SetActive(false);
        }
    }
}
