using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    [SerializeField] private GameObject pieces;
    [SerializeField] private GameObject[] stafsInBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(pieces, transform.position, Quaternion.identity);
            foreach (var item in stafsInBox)
            {

                Instantiate(item, transform.position, Quaternion.identity);
                
            }

        }

    }
}
