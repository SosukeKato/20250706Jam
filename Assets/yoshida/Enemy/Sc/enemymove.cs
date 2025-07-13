using UnityEngine;

public class enemymove : MonoBehaviour
{
    [Header("移動速度")]
    public float _speed;

    [Header("画面外でも行動する")]
    public bool nonVisibleAct;

    [Header("ターンするまでの時間")]
    public float _turntime = 5;

    private Rigidbody2D _rb = null;
    private Renderer _sr = null;

    private bool rightTleftF = false;
    private float _timer = 0f;
    private float _flipScale = 1;

    public bool IsFacingLeft => rightTleftF;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<Renderer>();
    }

    void Update()
    {
        if (_sr.isVisible || nonVisibleAct) // 画面に映っている or 設定により常に動く
        {
            _timer += Time.deltaTime;

            if (_timer >= _turntime)
            {
                rightTleftF = !rightTleftF;
                _flipScale *= -1;
                _timer = 0f;
            }

            // 向きを反転（スケール）
            transform.localScale = new Vector3(_flipScale, 1, 1);

            // 移動（Rigidbody2Dに対応）
            _rb.velocity = new Vector2(_speed * _flipScale, _rb.velocity.y);
        }
        else
        {
            // 画面外で非アクティブにする場合は停止
            _rb.velocity = Vector2.zero;
        }
    }
}
