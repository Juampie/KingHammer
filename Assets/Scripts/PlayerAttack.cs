using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private bool isAttacking = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isAttacking)
        {
            if (Input.GetKey(KeyCode.Mouse0) &&
                !EventSystem.current.IsPointerOverGameObject())
            {   
                isAttacking = true;
                animator.SetBool("Jumping", false);
                animator.SetTrigger("isAttacking");
                StartCoroutine(Attack());

            }


        }

    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }

}
