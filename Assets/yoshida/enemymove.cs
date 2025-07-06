
using UnityEngine;

public class enemymove : MonoBehaviour
{
    [SerializeField, Tooltip("�ړ����x")]
    public float _speed;
    [SerializeField, Tooltip("��ʊO�ł��s������")]
    public bool nonVisibleAct;

    [SerializeField, Tooltip("�^�[������܂ł̋���")]
    private float _turnDistance = 5;

    private Rigidbody _rb = null;
    private Renderer _sr = null;
    private bool rightTleftF = false;

    float movedDistance = 0;
    Vector3 Lastpos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _sr = GetComponent<Renderer>();
        Lastpos = transform.position;
    }

    void FixedUpdate()
    {


        if (_sr.isVisible || nonVisibleAct)//��ʂɎʂ��Ă��邢�邩����
        {
            //�O��Ƃ̍������߂āA�ړ�������ۑ�
            movedDistance += Vector3.Distance(Lastpos, transform.position);
            Lastpos = transform.position; //�O��̈ʒu���X�V

            //�����ς���������^�[������
            if (movedDistance >= _turnDistance)
            {
                rightTleftF = !rightTleftF; //�t�ɂ���
                movedDistance = 0; //�܂������n�߂�
            }
      
            Vector3 velocity = new Vector3(_speed, _rb.velocity.y,0);

            if (rightTleftF) //���Ȃ�x���t�ɂ���
            {
                velocity.x *= -1;
            }

            transform.localScale = new Vector3(Mathf.Sign(velocity.x), 1, 1); //���x������Ă����������
            _rb.velocity = velocity;
        }
        else
        {
            _rb.Sleep();
        }
    }

}
