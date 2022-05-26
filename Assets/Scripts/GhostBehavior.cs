using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehavior : MonoBehaviour
{
    private Vector2 movement;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;

    private bool facingRight = true;

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal2");
        movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (movement.x > 0 && !facingRight)
        {
            Flip();
        }
        
        if (movement.x < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
