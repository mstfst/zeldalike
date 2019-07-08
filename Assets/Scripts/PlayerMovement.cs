using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState {
    walk, 
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidBody;
    private Animator animator;
    private Vector3 change; 
    private PlayerState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("attack")) 
        {

        }
        if (currentState == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
    }

    void UpdateAnimationAndMove() 
    {
        if(change != Vector3.zero) 
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }   
        else 
        {
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter() 
    {
        change.Normalize();
        myRigidBody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }
}
