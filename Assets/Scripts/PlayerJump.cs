using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce;
    [SerializeField] GamePlay.BallController ballController;
    Animator animator;
    Rigidbody physic;

    void Start()
    {
        physic = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (gameObject.name == "Player 1" && ballController.throwDirection == Direction.Right)
            {
                physic.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                animator.SetTrigger("isJump");
            }

            else if (gameObject.name == "Player 2" && ballController.throwDirection == Direction.Left)
            {
                physic.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                animator.SetTrigger("isJump");
            }
        }
    }
}
