using UnityEngine;

public class enemychase : MonoBehaviour
{
    [Header("追いかける対象（タグ名で指定）")]
    [SerializeField] private string playerTag = "Player";
    [Header("追いかけるスピード")]
    [SerializeField] private float moveSpeed = 3f;

    private Transform player;
    private Rigidbody rb;
    private int scaleX = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }
    void Update()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        Vector3 dir = direction.normalized;
        rb.velocity = new Vector3(dir.x * moveSpeed, rb.velocity.y);

        if (dir.x > 0)
        {
            scaleX = 1;
        }
        else if (dir.x < 0)
        {
            scaleX = -1;
        }
        transform.localScale = new Vector3(scaleX, 1f, 1f);
    }
}

