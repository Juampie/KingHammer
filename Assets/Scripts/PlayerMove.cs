using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private float JumpPower = 3f;
    [SerializeField] private float MoveSpeed = 2f;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private bool isGrounded = true;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {

            Jump();
        }

        Move();


    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        foreach (ContactPoint2D i in collision.contacts)
        {
            if (i.normal.y > 0.8)
            {
                animator.SetBool("Jumping", false);
                isGrounded = true;
                break;
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            animator.SetBool("Jumping", true);
            
        }
    }



    private void Jump()
    {
        rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        animator.SetBool("Jumping", true);
        isGrounded = false;
        
    }

    private void Move()
    {

        float horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("HorizontalMove", Mathf.Abs(horizontalMove));
        if (horizontalMove > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalMove < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }

        transform.position += new Vector3(horizontalMove * MoveSpeed, 0f, 0f) * Time.deltaTime;



    }

}