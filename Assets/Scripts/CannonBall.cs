using UnityEngine;


public class CannonBall : MonoBehaviour
{

    private Rigidbody2D rb;
    public Vector2 Power = new(15, 6);

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Power, ForceMode2D.Impulse);
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb.AddForce(new Vector2(0,4),ForceMode2D.Impulse);
        }
        
    }

}







