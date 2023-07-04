using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Bomb : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float boomTime = 3f;
    [SerializeField] private float ExplosionForse = 5f;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Boom());
    }
    IEnumerator Boom()
    {
        yield return new WaitForSeconds(boomTime);
        animator.SetTrigger("Boom");
        var rb = GetComponent<Rigidbody2D>();
        transform.rotation = Quaternion.identity;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;




    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.GetComponent<Rigidbody2D>() != null)
        {
            var rb = collision.GetComponent<Rigidbody2D>();
            rb.AddForce(( collision.transform.position - transform.position).normalized * ExplosionForse,
                ForceMode2D.Impulse);
        }
        


    }

    private void DestroyBomb()
    {
        Destroy(gameObject);
    }

}
