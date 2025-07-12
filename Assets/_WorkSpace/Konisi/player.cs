using System.Collections;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] int PlayerMoveSpeed;
    public int PlayerHP;
    [SerializeField] float JumpForce = 350;
    [SerializeField] float BulletInterval;
    [SerializeField] float SwordInterval;
    [SerializeField] float SwordRemoveTime;
    [SerializeField] int _fallDeath;

    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Muzzle;
    [SerializeField] GameObject Slash;
    private GameObject SlashDeleat;

    private float _bulletTimer;
    private float _swordTimer;

    private Rigidbody2D _rig = null;
    private Animator _animator = null;
    private EnemyAttack _enemyAttck = null;
    private PlayerHP _playerHP;
    private bool _isGrounded = false;
    private bool _isDoubleJump = true;
    // Start is called before the first frame update
    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _enemyAttck = FindAnyObjectByType<EnemyAttack>();
        _playerHP = FindAnyObjectByType<PlayerHP>();
        _bulletTimer = BulletInterval;
        GetPlayerHP();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        BulletShot();
        SwordSlash();
        FallDeath();
        if (!Input.anyKey)
        {
            _animator.SetBool("Ninja_run", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-PlayerMoveSpeed * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(0, 10, 0);
            _animator.SetBool("Ninja_run",true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(PlayerMoveSpeed * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _animator.SetBool("Ninja_run",true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isDoubleJump = true;
            _isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage(_enemyAttck._power);
            _animator.SetTrigger("Ninja_hurt");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }
    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W)) &&_isGrounded)
        {
            _rig.AddForce(new Vector2(0, JumpForce));
            _animator.SetTrigger("Ninja_jump");
            Debug.Log("ジャンプ一段目");
        }
        if ((Input.GetKeyDown(KeyCode.W)) && !_isGrounded && _isDoubleJump)
        {
            _isDoubleJump = false;
            _rig.velocity = new Vector2(_rig.velocity.x, 0);
            _rig.AddForce(new Vector2(0, JumpForce));
            _animator.SetTrigger("Ninja_jump");
            Debug.Log("ジャンプ二段目");
        }
    }

    private void BulletShot()
    {
        if (Input.GetKeyDown(KeyCode.J) && _bulletTimer < Time.time)
        {
            _animator.SetTrigger("Ninja_Fireball");
            Instantiate(Bullet, Muzzle.transform.position,transform.rotation);
            _bulletTimer = Time.time + BulletInterval;
            Debug.Log($"{_bulletTimer}");
        }
    }
    private void SwordSlash()
    {
        if (Input.GetKeyDown(KeyCode.K) && _swordTimer < Time.time)
        {
            Transform parent = this.transform;
            _animator.SetTrigger("Ninja_Atk");
            SlashDeleat = Instantiate(Slash, Muzzle.transform.position, transform.rotation, parent);
            _swordTimer = Time.time + SwordInterval;
            Destroy( SlashDeleat,SwordRemoveTime);
            Debug.Log($"{_swordTimer}");
        }
    }
    private void FallDeath()
    {
        if (transform.position.y < _fallDeath)
        {
            Destroy(gameObject);
        }
    }
    private void Damage(int damage)
    {
        PlayerHP -= damage;
        GetPlayerHP();
        _playerHP.SetHPUI(damage);

        if (PlayerHP <= 0)
        {
            Debug.Log("死亡");
            Destroy(gameObject);
        }
    }
    public int GetPlayerHP()
    {
        return PlayerHP;
    }
}
