using UnityEngine;

public class BoxPieces : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private int x;
    [SerializeField] private int y;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetForce(x, y);
    }

    // Update is called once per frame

    void GetForce(int x, int y)
    {
        rb.AddForce(new Vector2(x, y), ForceMode2D.Impulse);

    }



}
