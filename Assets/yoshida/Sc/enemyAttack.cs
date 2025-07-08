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
    private enemymove moveScript;
    private bool isFacingLeft = false;

    void Start()
    {
        moveScript = GetComponent<enemymove>();
        InvokeRepeating("ThrowHammer", 1f, throwInterval);
    }

    void Update()
    {
        if (moveScript != null)
        {
            isFacingLeft = moveScript.IsFacingLeft; // ←ここで最新の向きを取得しているか？
        }
    }
    
    void ThrowHammer()
    {
        GameObject hammer = Instantiate(hammerPrefab, throwPoint.position, Quaternion.identity);
        Rigidbody hammerRb = hammer.GetComponent<Rigidbody>();
        if (hammerRb != null)
        {
            float xDirection = 1f;

            if (isFacingLeft == true)
            {
                xDirection = -1f;
            }

            Vector3 speed = new Vector3(throwForceX * xDirection, throwForceY, 0f);
            hammerRb.velocity = speed;

            Vector3 scale = hammer.transform.localScale;

            if (xDirection < 0)
            {
                // 左向き用に反転（絶対値を取ってマイナスをかける）
                if (scale.x > 0)
                {
                    scale.x = -scale.x;
                }
            }
            else
            {
                // 右向きは正のスケールにする
                if (scale.x < 0)
                {
                    scale.x = -scale.x;
                }
            }
            hammer.transform.localScale = scale;
        }
    }
}
