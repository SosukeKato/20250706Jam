using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Bossmove : MonoBehaviour
{   
    [SerializeField]
    private int maxHP = 10;
    private int currentHP;

    [SerializeField]
    GameObject _clear;

    [SerializeField, Tooltip("���E�̈ړ��X�s�[�h")]
    float MoveSpeed = 3.0f;
    #region
    //[SerializeField, Tooltip("Jamp")]
    //float Jamp = 5f;//�W�����v�̋���(������̑��x)

    //[SerializeField, Tooltip("JampInterval")]
    //float JumpInterval = 1.5f;//�W�����v�̊Ԋu(���b�����ɃW�����v���邩)

    //private float jumpTimer;//���ɃW�����v�ł���܂ł̎���
    #endregion
    [SerializeField, Tooltip("�{�X���g���F�̔z��")]
    private Color[] _sharedColorOptions = { Color.red, Color.blue, Color.green, Color.white };

    private Color myColor; // �{�X�̌��݂̐F
    #region
    //public Transform groundCheck;//�n�ʂɐG��Ă��邩�ǂ����𒲂ׂ�ʒu
    //public LayerMask groundLayer;//�n�ʂɐG��Ă��邩�ǂ����𒲂ׂ郌�C���[
    #endregion
    private string bulletTag = "Bullet";//�e�̃^�O
    private int direction = 1;//�ړ�����(1�Ȃ�E�A-1�Ȃ獶)

    [SerializeField]
    private Transform _LeftEdge;//�ړ��ł���͈͂̍��[
    [SerializeField]
    private Transform _RightEdge;//�ړ��ł���͈͂̉E�[

    private SpriteRenderer _sr = null;
    //private Rigidbody2D _rb = null;


    private enum BossState  //�{�X�̏�Ԃ�\��(�񋓌^)
    {
        StartEnsyutu,  //�o�ꉉ�o��
        Battle,�@�@�@�@//�o�g����
        ClearEnsyutu,�@//�|���ꂽ�Ƃ��̉��o
        //Jamp,�@�@�@�@�@//�W�����v��
        Idou,�@�@�@�@�@//�ړ���
        //Bullet,�@�@�@�@//�e��ł�
    }
    private BossState nowState = BossState.Battle;�@//���̏��
    private BossState SubState;�@�@�@�@�@�@�@�@�@�@ //�s���̎��(�o�g����)


    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        //_rb = GetComponent<Rigidbody2D>();
        currentHP = maxHP;

            if (_sharedColorOptions.Length > 0)
            {
                StartCoroutine(ChangeColorRoutine()); // �F�ύX�X�^�[�g
            }
            StartCoroutine(DoStartEnsyutu());
    }

    // Update is called once per frame
    void Update()
    {

        switch (nowState)  //��nowState�ɂ͌��݂̏�Ԃ������Ă���
        {
            case BossState.Battle://�퓬���̏���������
                switch (SubState)//�����_���ɑI�΂ꂽ�s�������s����
                {
                    //case BossState.Jamp:
                    //    Jump();
                        #region ��
                        //if (transform.position.x >= _RightEdge.position.x)
                        //{
                        //    direction = -1;
                        //}
                        //if (transform.position.x <= _LeftEdge.position.x)
                        //{
                        //    direction = 1;
                        //}
                        //jumpTimer -= Time.deltaTime;
                        //if (jumpTimer <= 0f && IsGrounded())
                        //{
                        //    _rb.velocity = new Vector2(_rb.velocity.x, Jamp); // AddForce�Ȃ��ŃW�����v�I
                        //    jumpTimer = JumpInterval;
                        //}

                        //transform.position = new Vector3(
                        //    transform.position.x + MoveSpeed * Time.deltaTime * direction,
                        //    transform.position.y,
                        //    transform.position.z);

                        //bool IsGrounded()
                        //        {
                        //            return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
                        //        }
                        #endregion
                        //break;

                    case BossState.Idou:
                        Move();
                        #region ��
                        //if (transform.position.x >= _RightEdge.position.x)
                        //{
                        //    direction = -1;
                        //}
                        //if (transform.position.x <= _LeftEdge.position.x)
                        //{
                        //    direction = 1;
                        //}
                        //transform.position = new Vector3(transform.position.x + MoveSpeed * Time.deltaTime * direction, -1.25f, 1);
                        #endregion
                        break;

                    //case BossState.Bullet:
                    //    Shoot();
                    //    break;
                }
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)//�e���Ԃ��������̏���
    {
        OnHitBullet(collision.gameObject);
    }
    private void OnHitBullet(GameObject obj)
    {
        if (obj.tag != bulletTag)
        {
            return;
        }

        if (obj.TryGetComponent<Renderer>(out Renderer bulletRenderer))
        {
            Color bulletColor = bulletRenderer.material.color;

            if (bulletColor != myColor)
            {
                return;
            }
            currentHP--;

            if (currentHP <= 0)
            {
                nowState = BossState.ClearEnsyutu;
                StartCoroutine(DoClearEnsyutu());
            }
            else
            {
                Debug.Log("�F���Ⴄ�̂Ŗ���");
            }
        }
    }
    #region ��
    /*
    private void OnCollisionEnter2D(Collision2D collision)//�e���Ԃ��������̏���
    {
        if (collision.collider.CompareTag(bulletTag))
        {
            if (collision.collider.TryGetComponent<Renderer>(out Renderer bulletRenderer))
            {
                Color bulletColor = bulletRenderer.material.color;

                if (bulletColor == myColor)
                {
                    currentHP--;
                    
                    if (currentHP <= 0)
                    {
                        nowState = BossState.ClearEnsyutu;
                        StartCoroutine(DoClearEnsyutu());
                    }
                    else
                    {
                        Debug.Log("�F���Ⴄ�̂Ŗ���");
                    }
                }
            }
        }
    }
    */
    #endregion
    IEnumerator ChangeColorRoutine()
    {
            while (nowState != BossState.ClearEnsyutu)
            {
                int randIndex = Random.Range(0, _sharedColorOptions.Length);
                myColor = _sharedColorOptions[randIndex];

                if (_sr != null)
                {
                    _sr.color = myColor; // �����ڂ�ς���
                }

                Debug.Log($"�{�X�̐F���ω��F{myColor}");
                yield return new WaitForSeconds(2f); // 2�b�҂�
            }
    }
    IEnumerator DoStartEnsyutu()//
    {
            Debug.Log("�o�ꉉ�o�J�n�I");
            yield return new WaitForSeconds(1f); // 1�b�܂�
            Debug.Log("�o�ꉉ�o�I��");

            nowState = BossState.Battle;//��Ԃ��o�g���ɂ���
            StartCoroutine(ChangeBattleSubState());//�o�g���̍s�����J�n
    }

    IEnumerator DoClearEnsyutu()// �N���A���o�i�G�t�F�N�g�Ȃǁj
    {
        yield return new WaitForSeconds(0f); 
        Destroy(gameObject); // �{�X���폜
        _clear.SetActive(true);
    }

    // --- �o�g�����̍s���������_���ɐ؂�ւ��� ---
    IEnumerator ChangeBattleSubState()
    {
        while (currentHP > 0 && nowState == BossState.Battle)
        {
            SubState = (BossState.Idou);
            yield return new WaitForSeconds(Random.Range(1f, 2f));//1�`2�b�ԑ҂��Ă��炤
            SubState = BossState.Battle; // �ꎞ��~���
            yield return new WaitForSeconds(1f);
        }
    }

    // --- �e�A�N�V�������� ---

    //void Jump()
    //{
    //    jumpTimer -= Time.deltaTime;
    //    if (jumpTimer <= 0f && IsGrounded())
    //    {
    //        _rb.velocity = new Vector2(_rb.velocity.x, Jamp);
    //        jumpTimer = JumpInterval;
    //    }
    //}

    void Move()
    {
        if (transform.position.x >= _RightEdge.position.x)
            direction = -1;
        else if (transform.position.x <= _LeftEdge.position.x)
            direction = 1;

        transform.position += new Vector3(MoveSpeed * Time.deltaTime * direction, 0, 0);
    }

    //void Shoot()
    //{
    //    // �e�̔��ˏ���
    //}

    //bool IsGrounded()
    //{
    //    return Physics2D.OverlapCircle(groundCheck.position, 0.1f) != null;//�����ɔ��a0.1�̉~�������Ă��̉~�ɉ����Ԃ����Ă�����true��Ԃ�    }
    //}
}

