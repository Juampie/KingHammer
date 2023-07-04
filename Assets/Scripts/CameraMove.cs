using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Camera Camera;
    private bool inSaveZone = true;
    [SerializeField] Transform TransformPlayer;
    [SerializeField] float smooting = 0.25f;
    private Vector3 offset = new Vector3(0, 3, -5);


    private void Start()
    {
        Camera = GetComponent<Camera>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") )
        {
            inSaveZone = false;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inSaveZone = true;
        }

    }
    private void Update()
    {
        if (!inSaveZone)
        {
            Camera.transform.position = Vector3.Lerp(Camera.transform.position,
                TransformPlayer.position + offset, smooting * Time.deltaTime);
        }

       
    }
}
