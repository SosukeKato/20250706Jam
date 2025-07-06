
using UnityEngine;

public class enemymove : MonoBehaviour
{
    [SerializeField, Tooltip("移動速度")]
    public float _speed;
    [SerializeField, Tooltip("画面外でも行動する")]
    public bool nonVisibleAct;

    [SerializeField, Tooltip("ターンするまでの距離")]
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


        if (_sr.isVisible || nonVisibleAct)//画面に写っているいるか判定
        {
            //前回との差を求めて、移動距離を保存
            movedDistance += Vector3.Distance(Lastpos, transform.position);
            Lastpos = transform.position; //前回の位置を更新

            //いっぱい歩いたらターンする
            if (movedDistance >= _turnDistance)
            {
                rightTleftF = !rightTleftF; //逆にする
                movedDistance = 0; //また数え始める
            }
      
            Vector3 velocity = new Vector3(_speed, _rb.velocity.y,0);

            if (rightTleftF) //左ならxを逆にする
            {
                velocity.x *= -1;
            }

            transform.localScale = new Vector3(Mathf.Sign(velocity.x), 1, 1); //速度が乗ってる方向を見る
            _rb.velocity = velocity;
        }
        else
        {
            _rb.Sleep();
        }
    }

}
