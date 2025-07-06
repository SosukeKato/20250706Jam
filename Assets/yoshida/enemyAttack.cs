using UnityEngine;

public class enemyAttck : MonoBehaviour
{
    [SerializeField] private GameObject hammerPrefab; // 投げるハンマーのPrefab
    [SerializeField] private Transform throwPoint;    // 投げる位置
    [SerializeField] private float throwForceX = 5f;  // X方向の力
    [SerializeField] private float throwForceY = 7f;  // Y方向の力
    [SerializeField] private float throwInterval = 2f; // 投げる間隔（秒）

    private bool rightTleftF = false; // false:右, true:左

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(ThrowHammer), 1f, throwInterval);
    }
    void FixedUpdate()
    {
        // 向き反転処理（左右巡回してるならその変数使う）
        transform.localScale = new Vector3(rightTleftF ? -1 : 1, 1, 1);
    }

    void ThrowHammer()
    {
        GameObject hammer = Instantiate(hammerPrefab, throwPoint.position, Quaternion.identity);
        Rigidbody2D rb = hammer.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            float direction = rightTleftF ? -1f : 1f;
            rb.velocity = new Vector2(throwForceX * direction, throwForceY);
        }
    }
}
