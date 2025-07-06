using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] int MoveSpeed;
    [SerializeField] float JumpForce = 350;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Muzzle;

    private Rigidbody2D _rig = null;
    private bool _isGrounded = false;
    private bool _isDoubleJump = true;
    // Start is called before the first frame update
    void Start()
    {
        _rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BulletShot();
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-MoveSpeed * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
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
        if (Input.GetKeyDown(KeyCode.W) && _isGrounded)
        {
            _rig.AddForce(new Vector2(0, JumpForce));
            Debug.Log("ジャンプ一段目");
        }
        if (Input.GetKeyDown(KeyCode.W) && !_isGrounded && _isDoubleJump)
        {
            _isDoubleJump = false;
            _rig.velocity = new Vector2(_rig.velocity.x, 0);
            _rig.AddForce(new Vector2(0, JumpForce));
            Debug.Log("ジャンプ二段目");
        }
    }

    private void BulletShot()
    {
        Instantiate(Bullet, Muzzle.transform.position,transform.rotation);
    }
}
