using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Character Movement Behaviour
/// </summary>
public class CharacterMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    CharacterController controller;
    [SerializeField]
    Animator animator;
    [SerializeField]
    GameObject doubleJumpParticle;

    [Header("Parameters")]
    [SerializeField]
    float jumpForce = 7f;
    [SerializeField]
    float walkSpeed = 5;
    [SerializeField]
    float runSpeed = 8;
    [SerializeField]
    float groundDistance = 1;
    [SerializeField]
    LayerMask groundLayer;

    [Header("Values")]
    [SerializeField]
    Vector3 velocity;
    [SerializeField]
    bool isGrounded;
    public bool canDoubleJump;

    /// <summary>
    /// Called Before the First Frame Update
    /// </summary>
    void Start()
    {
        // Get Component References
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        velocity = Vector3.zero;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /// <summary>
    /// Called Once per Frame
    /// </summary>
    void Update()
    {
        UpdateMovement();
        UpdateAnimator();
    }

    /// <summary>
    /// Update Movement Physics
    /// </summary>
    void UpdateMovement() 
    {
        float speed = GetMovementSpeed();

        // Vertical and Horizontal Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * verticalInput + transform.right * horizontalInput;
        move *= speed;

        // Jump Movement
        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = jumpForce;
            animator.SetTrigger("Jump");
        }

        if (Input.GetButtonDown("Jump") && !isGrounded && canDoubleJump) {
            velocity.y = jumpForce;
            animator.SetTrigger("DoubleJump");

            canDoubleJump = false;
            
            Instantiate(doubleJumpParticle, transform.position, Quaternion.identity);
        }

        // Add Gravity
        velocity.y += Physics.gravity.y * Time.deltaTime;

        // Clamp Gravity Value to Allow Smooth Falling
        if (isGrounded) {
            velocity.y = Mathf.Clamp(velocity.y, -1, Mathf.Infinity);
        }

        controller.Move((velocity + move) * Time.deltaTime);

        isGrounded = Physics.Raycast(transform.position + Vector3.up, Vector3.down, groundDistance);

        // Move Camera
        if (Mathf.Abs(Input.GetAxis("Mouse X")) > 0) {
            transform.Rotate(0, Input.GetAxis("Mouse X") * 200 * Time.deltaTime, 0);
        }
    }

    /// <summary>
    /// Update Animations Based on Movement
    /// </summary>
    void UpdateAnimator()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0) {
            if (Input.GetButton("Fire3")) {
                animator.SetFloat("VerticalSpeed", Input.GetAxis("Vertical"));
            } else {
                animator.SetFloat("VerticalSpeed", Input.GetAxis("Vertical") / 2);
            }
        } else {
            animator.SetFloat("VerticalSpeed", 0f);
        }

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0) {
            if (Input.GetButton("Fire3")) {
                animator.SetFloat("HorizontalSpeed", Input.GetAxis("Horizontal"));
            } else {
                animator.SetFloat("HorizontalSpeed", Input.GetAxis("Horizontal") / 2);
            }
        } else {
            animator.SetFloat("HorizontalSpeed", 0f);
        }

        animator.SetBool("IsGrounded", isGrounded);
    }

    /// <summary>
    /// Get Movement Speed Based on Input
    /// </summary>
    /// <returns> Movement Speed </returns>
    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3")) {
            return runSpeed;
        } else {
            return walkSpeed;
        }
    }
}
