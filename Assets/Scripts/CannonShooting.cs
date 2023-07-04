using System.Collections;
using UnityEngine;

public class CannonShooting : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float time = 5f;
    [SerializeField] private GameObject CannonBall;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Shooting());
    }


    private IEnumerator Shooting()
    {
        while (true)
        {

            yield return new WaitForSeconds(time);
            animator.SetTrigger("Shooting");
            
        }
    }

    private void SpawnCannonBall()
    {
        Instantiate(CannonBall, transform.position, Quaternion.identity);

    }


}
