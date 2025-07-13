using UnityEngine;

public class enemymove : MonoBehaviour
{
    [Header("�ړ����x")]
    public float _speed;

    [Header("��ʊO�ł��s������")]
    public bool nonVisibleAct;

    [Header("�^�[������܂ł̎���")]
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
        if (_sr.isVisible || nonVisibleAct) // ��ʂɉf���Ă��� or �ݒ�ɂ���ɓ���
        {
            _timer += Time.deltaTime;

            if (_timer >= _turntime)
            {
                rightTleftF = !rightTleftF;
                _flipScale *= -1;
                _timer = 0f;
            }

            // �����𔽓]�i�X�P�[���j
            transform.localScale = new Vector3(_flipScale, 1, 1);

            // �ړ��iRigidbody2D�ɑΉ��j
            _rb.velocity = new Vector2(_speed * _flipScale, _rb.velocity.y);
        }
        else
        {
            // ��ʊO�Ŕ�A�N�e�B�u�ɂ���ꍇ�͒�~
            _rb.velocity = Vector2.zero;
        }
    }
}
