using UnityEngine;

public class enemyAttck : MonoBehaviour
{
    [SerializeField] private GameObject hammerPrefab; // ������n���}�[��Prefab
    [SerializeField] private Transform throwPoint;    // ������ʒu
    [SerializeField] private float throwForceX = 5f;  // X�����̗�
    [SerializeField] private float throwForceY = 7f;  // Y�����̗�
    [SerializeField] private float throwInterval = 2f; // ������Ԋu�i�b�j

    private bool rightTleftF = false; // false:�E, true:��

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(ThrowHammer), 1f, throwInterval);
    }
    void FixedUpdate()
    {
        // �������]�����i���E���񂵂Ă�Ȃ炻�̕ϐ��g���j
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
