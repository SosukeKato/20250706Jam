using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("投げるハンマーのPrefab")]
    public GameObject _hammerPrefab;

    [Header("ハンマーが出てくる位置（子オブジェクト）")]
    public Transform _throwPoint;

    [Header("ハンマーの飛ぶ速さ（X方向）")]
    public float _throwForceX = 5f;

    [Header("ハンマーの飛ぶ速さ（Y方向）")]
    public float _throwForceY = 7f;

    [Header("ハンマーを投げる間隔（秒）")]
    public float throwInterval = 2f;

    private enemymove moveScript;
    private bool isFacingLeft = false;
    public int _power = 1;

    void Start()
    {
        moveScript = GetComponent<enemymove>();
        InvokeRepeating(nameof(ThrowHammer), 1f, throwInterval);
    }

    void Update()
    {
        if (moveScript != null)
        {
            isFacingLeft = moveScript.IsFacingLeft;
        }
    }

    void ThrowHammer()
    {
        if (_hammerPrefab == null || _throwPoint == null) return;

        GameObject hammer = Instantiate(_hammerPrefab, _throwPoint.position, Quaternion.identity);
        Rigidbody2D hammerRb = hammer.GetComponent<Rigidbody2D>();
        if (hammerRb != null)
        {
            float xDirection = isFacingLeft ? -1f : 1f;
            hammerRb.velocity = new Vector2(_throwForceX * xDirection, _throwForceY);
        }
    }
}
