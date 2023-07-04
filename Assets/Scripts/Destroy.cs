using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private float time;
    void Start()
    {
        Destroy(gameObject, time);
    }


}
