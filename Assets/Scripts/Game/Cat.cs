using System;
using UnityEngine;

public class Cat 
    : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioSource meowSource;
    [SerializeField] private Rigidbody2D body;

    [SerializeField] private Animator animator;
    
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            meowSource.PlayOneShot(meowSource.clip);
        }

        Move();
    }
    
    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.AddForce(Vector2.left * (speed * Time.deltaTime));
            animator.SetBool("Move", true);
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            body.AddForce(Vector2.right * (speed * Time.deltaTime));
            animator.SetBool("Move", true);
            spriteRenderer.flipX = false;
        }
        else
        {
            animator.SetBool("Move", false);
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetTrigger("Grounded");
    }
}
