using UnityEngine;

public class Bossmove : MonoBehaviour
{
    [Header("ボスの最大HP")]
    [SerializeField] int maxHP = 10;

    [Header("移動スピード")]
    [SerializeField] float moveSpeed = 3f;
    int direction = 1;

    [Header("ジャンプ設定")]
    [SerializeField] float jumpForce = 10f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    [Header("突進設定")]
    [SerializeField] float chargeSpeed = 8f;
    [SerializeField] float chargeTime = 1.0f;
    float chargeTimer;

    [Header("火炎弾設定")]
    [SerializeField] GameObject flameBulletPrefab;
    [SerializeField] Transform flameSpawnPoint;
    bool flameShotDone = false;

    [Header("メテオ設定")]
    [SerializeField] GameObject meteorPrefab;
    [SerializeField] Transform[] meteorSpawnPoints; // メテオ位置をインスペクターで設定

    [Header("撃破時に出すオブジェクト")]
    [SerializeField] GameObject clearObject;

    [Header("左右の移動範囲")]
    [SerializeField] Transform leftEdge;
    [SerializeField] Transform rightEdge;

    Rigidbody2D _rb;
    private Renderer _renderer;

    enum BossState { Start, Battle, Clear }
    BossState nowState = BossState.Start;

    enum BattleState { Idle, Move, Jump, Meteor, Charge, Flame }
    BattleState _currentBattle = BattleState.Idle;

    float actionTimer;
    float idleTimer;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<Renderer>();
        Invoke(nameof(StartBattle), 1f);
        direction = 1;
    }

    void Update()
    {
        if (!_renderer.isVisible) return;
        if (nowState != BossState.Battle) return;

        switch (_currentBattle)
        {
            case BattleState.Idle:
                idleTimer -= Time.deltaTime;
                if (idleTimer <= 0f) SelectNextAction();
                break;

            case BattleState.Move:
                DoMove();
                actionTimer -= Time.deltaTime;
                if (actionTimer <= 0f) SetIdle();
                break;

            case BattleState.Jump:
                DoJump();
                break;

            case BattleState.Charge:
                DoCharge();
                break;

            case BattleState.Meteor:
                DoMeteor();
                break;

            case BattleState.Flame:
                DoFlame();
                actionTimer -= Time.deltaTime;
                if (actionTimer <= 0f) SetIdle();
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // タグではなく、名前に "Bullet" や "Attack" が含まれていたらダメージ
        if (collision.gameObject.name.Contains("Attack") || collision.gameObject.name.Contains("Bullet"))
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        maxHP -= damage;
        if (maxHP <= 0 && nowState != BossState.Clear)
        {
            nowState = BossState.Clear;
            Invoke(nameof(ClearBoss), 0.5f);
        }
    }

    void StartBattle()
    {
        nowState = BossState.Battle;
        idleTimer = 1f;
    }

    void ClearBoss()
    {
        Destroy(gameObject);
        if (clearObject != null) clearObject.SetActive(true);
    }

    void DoMove()
    {
        if (transform.position.x >= rightEdge.position.x)
            direction = -1;
        else if (transform.position.x <= leftEdge.position.x)
            direction = 1;

        Vector2 newPos = _rb.position + new Vector2(moveSpeed * direction * Time.deltaTime, 0f);
        _rb.MovePosition(newPos);
    }

    void DoJump()
    {
        if (IsGrounded())
        {
            _rb.velocity = new Vector2(moveSpeed * direction, jumpForce);
            SetIdle();
        }
    }

    void DoCharge()
    {
        chargeTimer -= Time.deltaTime;
        _rb.velocity = new Vector2(chargeSpeed * direction, _rb.velocity.y);

        if (chargeTimer <= 0f)
        {
            _rb.velocity = Vector2.zero;
            SetIdle();
        }
    }

    void DoFlame()
    {
        if (!flameShotDone && flameBulletPrefab != null && flameSpawnPoint != null)
        {
            GameObject flame = Instantiate(flameBulletPrefab, flameSpawnPoint.position, Quaternion.identity);
            Rigidbody2D rb = flame.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = new Vector2(5f * direction, 0);

            flameShotDone = true;
        }
    }

    void DoMeteor()
    {
        if (meteorPrefab == null || meteorSpawnPoints.Length == 0)
        {
            Debug.LogWarning("メテオプレハブまたは出現位置が未設定です");
            SetIdle();
            return;
        }

        foreach (Transform spawnPoint in meteorSpawnPoints)
        {
            if (spawnPoint != null)
                Instantiate(meteorPrefab, spawnPoint.position, Quaternion.identity);
        }

        SetIdle();
    }

    void SelectNextAction()
    {
        _currentBattle = (BattleState)Random.Range(0, 6);
        flameShotDone = false;

        switch (_currentBattle)
        {
            case BattleState.Move:
            case BattleState.Flame:
            case BattleState.Jump:
                actionTimer = 2f;
                break;

            case BattleState.Charge:
                chargeTimer = chargeTime;
                break;

            case BattleState.Meteor:
                break;
        }
    }

    void SetIdle()
    {
        _currentBattle = BattleState.Idle;
        idleTimer = 1f;
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
}
