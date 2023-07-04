using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerHealthNS;

public class BigHeart : MonoBehaviour
{   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            if (PlayerHealth.HealthNow < 3)
            {
                gameObject.SetActive(false);
                PlayerHealth.HealthNow++;
            }
            
        }
        
        

    }
}
