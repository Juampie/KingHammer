using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerHealthNS;


public class Finish : MonoBehaviour
{
    private Animator doorAnimator;
    private GameObject player;
    [SerializeField] private Animator blackScreanAnimator;
    public bool DiamondIsGetting = false;

    private void Start()
    {
        doorAnimator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && DiamondIsGetting)
        {
            if (Input.GetKey(KeyCode.E))
            {
                doorAnimator.SetTrigger("Opening");
                blackScreanAnimator.SetTrigger("LevelComplite");
                var playerHealth = player.GetComponent<PlayerHealth>();
                playerHealth.isInvincible = true;
                playerHealth.StartInvincible();
            }
        }
        


    }

    
}
