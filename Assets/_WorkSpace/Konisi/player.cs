using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] int MoveSpeed;
    [SerializeField] float JumpForce = 350;

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
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-MoveSpeed * Time.deltaTime, 0); 
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(MoveSpeed * Time.deltaTime, 0); 
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
}
