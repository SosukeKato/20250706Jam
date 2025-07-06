using UnityEditor;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("投げるハンマーのPrefab")]
    [SerializeField] private GameObject hammerPrefab;

    [Header("ハンマーが出てくる位置（子オブジェクト）")]
    [SerializeField] private Transform throwPoint;

    [Header("ハンマーの飛ぶ速さ（X方向）")]
    [SerializeField] private float throwForceX = 5f;

    [Header("ハンマーの飛ぶ速さ（Y方向）")]
    [SerializeField] private float throwForceY = 7f;

    [Header("ハンマーを投げる間隔（秒）")]
    [SerializeField] private float throwInterval = 2f;

    // 敵の向き　false = 右向き　true = 左向き
    public bool isFacingLeft { get; set; } = false;

    // 最初の投げ位置（右向きの時の位置）を記録する
    private Vector3 defaultThrowPointLocalPos;

    private enemymove moveScript;

    void Start()
    {
        moveScript = GetComponent<enemymove>();
        defaultThrowPointLocalPos = throwPoint.localPosition;
        InvokeRepeating(nameof(ThrowHammer), 1f, throwInterval);
    }

    void Update()
    {
        if (moveScript != null)
        {
            isFacingLeft = moveScript.IsFacingLeft;
        }

        UpdateThrowPointPosition();
    }

    /// <summary>
    /// 敵の向きに合わせて、ハンマーの出現位置を左右反転させる
    /// </summary>
    void UpdateThrowPointPosition()
    {
        // 右向きならそのまま、左向きならx座標を反転
        float x = defaultThrowPointLocalPos.x * (isFacingLeft ? -1f : 1f);

        // 反転後の位置を設定（YとZは変わらない）
        throwPoint.localPosition = new Vector3(x, defaultThrowPointLocalPos.y, defaultThrowPointLocalPos.z);
    }

    /// <summary>
    /// ハンマーを生成して、向きに合わせて飛ばす
    /// </summary>
    void ThrowHammer()
    {
        // ハンマーを出現させる
        GameObject hammer = Instantiate(hammerPrefab, throwPoint.position, Quaternion.identity);

        // ハンマーに物理（Rigidbody）がついていれば速度を与える
        Rigidbody hammerRb = hammer.GetComponent<Rigidbody>();

        if (hammerRb != null)
        {
            // 右向きなら正、左向きなら負のX方向に飛ばす
            float direction = isFacingLeft ? -1f : 1f;

            // 投げる速度を設定
            Vector3 throwVelocity = new Vector3(throwForceX * direction, throwForceY, 0f);
            hammerRb.velocity = throwVelocity;

            // ハンマーの見た目も左右反転させる（必要なら）
            Vector3 hammerScale = hammer.transform.localScale;
            hammerScale.x = Mathf.Abs(hammerScale.x) * direction;
            hammer.transform.localScale = hammerScale;
        }
    }
}
