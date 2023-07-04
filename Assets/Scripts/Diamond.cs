using UnityEngine;


public class Diamond : MonoBehaviour
{
    [SerializeField] private Sprite YesSprite;
    private GameObject diamondGet;
    private SpriteRenderer diamondGetRenderer;
    private GameObject door;
    private void Start()
    {
        diamondGet = GameObject.Find("DiamondGet");
        door = GameObject.Find("Door");
        diamondGetRenderer = diamondGet.GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            diamondGetRenderer.sprite = YesSprite;
            diamondGetRenderer.color = Color.green;
            door.GetComponent<Finish>().DiamondIsGetting = true;



        }
    }


}

