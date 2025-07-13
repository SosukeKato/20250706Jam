using UnityEngine;

public class DestroyWhenOutOfView : MonoBehaviour
{
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (!rend.isVisible)
        {
            Destroy(gameObject);
        }
    }
}
