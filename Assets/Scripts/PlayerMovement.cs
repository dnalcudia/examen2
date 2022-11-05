using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveDirection;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        PlayerAnimations();
    }

    void Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        rb.velocity =
            new Vector2(moveDirection.x * moveSpeed,
                moveDirection.y * moveSpeed);
    }

    void PlayerAnimations()
    {
        anim.SetFloat("moveX", moveDirection.x);
        anim.SetFloat("moveY", moveDirection.y);
    }
}
