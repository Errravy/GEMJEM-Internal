using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance;
    [SerializeField] private Transform[] snapPosition;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = 9.8f;
    private Animator animator;
    private int snapIndex;
    private bool isGrounded = true;
    Vector3 positionToMove;
    private Rigidbody rb;
    private PlayerControls control;
    private bool shield = false;
    private bool reverse = false;
    private void Awake()
    {
        instance = this;

        control = new();
        control.Player.Enable();
        control.Player.Move.started += ChangeDirection;
        control.Player.Jump.started += Jump;

        snapIndex = 1;
        positionToMove = new Vector3(snapPosition[snapIndex].position.x, transform.position.y, transform.position.z);

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Physics.gravity = Vector3.down * gravity;
    }

    private void OnDisable()
    {
        control.Player.Move.started -= ChangeDirection;
        control.Player.Jump.started -= Jump;
    }


    void Update()
    {
        Move();
        animator.SetBool("isGrounded", isGrounded);
    }

    private void ChangeDirection(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            float direction = control.Player.Move.ReadValue<float>();
            if (reverse) direction *= -1;

            if (direction == 1) snapIndex++;
            else if (direction == -1) snapIndex--;

            if (snapIndex >= 2) snapIndex = 2;
            else if (snapIndex <= 0) snapIndex = 0;
            positionToMove = new Vector3(snapPosition[snapIndex].position.x, transform.position.y, transform.position.z);
        }
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, positionToMove) > 0.1f)
        {
            rb.velocity = new Vector3((positionToMove - transform.position).normalized.x * speed,
                                        rb.velocity.y, rb.velocity.z);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (context.started && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    #region Power Up
    public void Shield()
    {
        shield = true;
    }

    public void Reverse()
    {
        StartCoroutine(ReversePowerUp());
    }


    private IEnumerator ReversePowerUp()
    {
        reverse = true;
        yield return new WaitForSeconds(5f);
        reverse = false;
    }
    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }


    }

    public void HitObstacle(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (shield)
            {
                shield = false;
                return;
            }

            animator.SetTrigger("hit");
            Grounds.instance.speed = 0;
            this.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            if (other.TryGetComponent<IPickUp>(out var pickUp))
            {
                pickUp.PickUp();
            }
        }


    }
}
