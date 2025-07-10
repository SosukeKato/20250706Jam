using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] int MoveSpeed;
    [SerializeField] float BulletInterval;
    [SerializeField] float SwordInterval;
    [SerializeField] float SwordRemoveTime;
    [SerializeField] float JumpForce = 350;
    [SerializeField] int _fallDeath;

    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Muzzle;
    [SerializeField] GameObject Slash;
    private GameObject SlashDeleat;

    private float _bulletTimer;
    private float _swordTimer;

    private Rigidbody2D _rig = null;
    private bool _isGrounded = false;
    private bool _isDoubleJump = true;
    // Start is called before the first frame update
    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
        _bulletTimer = BulletInterval;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        BulletShot();
        SwordSlash();
        FallDeath();
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-MoveSpeed * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(0, 10, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(MoveSpeed * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isDoubleJump = true;
            _isGrounded = true;
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
            Debug.Log("ジャンプ一段目");
        }
        if ((Input.GetKeyDown(KeyCode.W)) && !_isGrounded && _isDoubleJump)
        {
            _isDoubleJump = false;
            _rig.velocity = new Vector2(_rig.velocity.x, 0);
            _rig.AddForce(new Vector2(0, JumpForce));
            Debug.Log("ジャンプ二段目");
        }
    }

    private void BulletShot()
    {
        if (Input.GetKeyDown(KeyCode.J) && _bulletTimer < Time.time)
        {
            Instantiate(Bullet, Muzzle.transform.position,transform.rotation);
            _bulletTimer = Time.time + BulletInterval;
            Debug.Log($"{_bulletTimer}");
        }
    }
    private void SwordSlash()
    {
        if (Input.GetKeyDown(KeyCode.K) && _swordTimer < Time.time)
        {
            SlashDeleat = Instantiate(Slash, Muzzle.transform.position, transform.rotation);
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
}
