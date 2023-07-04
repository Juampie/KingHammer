using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BombPig : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    private Animator animator;
    private GameObject player;
    private SpriteRenderer spriteRenderer; 
    private int EnemyHealth = 3;
    [SerializeField] float speedThrowing = 5f;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        StartCoroutine(Throw());

    }

    IEnumerator Throw()
    {
        while (true)
        {
            yield return new WaitForSeconds(speedThrowing);
            animator.SetTrigger("Throwing");
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && EnemyHealth > 0) 
        {
            EnemyHealth--;
            StartCoroutine(ChangeColor());
            
        }
        if (EnemyHealth == 0)
        {
            Destroy(gameObject);
        }

    }

    private IEnumerator ChangeColor()
    {
        spriteRenderer.color = new Color32(255, 100, 100, 255);
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = new Color32(255, 255, 255, 255);

    }


    public void SpawnBomb()
    {

        GameObject bomba = Instantiate(bomb,transform.position + new Vector3(0,1,0), Quaternion.identity);
        Rigidbody2D rigidbody = bomba.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(player.transform.position - transform.position, ForceMode2D.Impulse);
        
    }

    private void LookToPlayer()
    {
        if (transform.position.x > player.transform.position.x && spriteRenderer.flipX != false)
        {
            spriteRenderer.flipX = false;
        }
        else if(transform.position.x < player.transform.position.x && spriteRenderer.flipX != true)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void Update()
    {
        LookToPlayer();
    }

}
