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

    [SerializeField, Tooltip("左右の移動スピード")]
    float MoveSpeed = 3.0f;
    #region
    //[SerializeField, Tooltip("Jamp")]
    //float Jamp = 5f;//ジャンプの強さ(上方向の速度)

    //[SerializeField, Tooltip("JampInterval")]
    //float JumpInterval = 1.5f;//ジャンプの間隔(何秒おきにジャンプするか)

    //private float jumpTimer;//次にジャンプできるまでの時間
    #endregion
    [SerializeField, Tooltip("ボスが使う色の配列")]
    private Color[] _sharedColorOptions = { Color.red, Color.blue, Color.green, Color.white };

    private Color myColor; // ボスの現在の色
    #region
    //public Transform groundCheck;//地面に触れているかどうかを調べる位置
    //public LayerMask groundLayer;//地面に触れているかどうかを調べるレイヤー
    #endregion
    private string bulletTag = "Bullet";//弾のタグ
    private int direction = 1;//移動方向(1なら右、-1なら左)

    [SerializeField]
    private Transform _LeftEdge;//移動できる範囲の左端
    [SerializeField]
    private Transform _RightEdge;//移動できる範囲の右端

    private SpriteRenderer _sr = null;
    //private Rigidbody2D _rb = null;


    private enum BossState  //ボスの状態を表す(列挙型)
    {
        StartEnsyutu,  //登場演出中
        Battle,　　　　//バトル中
        ClearEnsyutu,　//倒されたときの演出
        //Jamp,　　　　　//ジャンプ中
        Idou,　　　　　//移動中
        //Bullet,　　　　//弾を打つ
    }
    private BossState nowState = BossState.Battle;　//今の状態
    private BossState SubState;　　　　　　　　　　 //行動の種類(バトル中)


    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        //_rb = GetComponent<Rigidbody2D>();
        currentHP = maxHP;

            if (_sharedColorOptions.Length > 0)
            {
                StartCoroutine(ChangeColorRoutine()); // 色変更スタート
            }
            StartCoroutine(DoStartEnsyutu());
    }

    // Update is called once per frame
    void Update()
    {

        switch (nowState)  //←nowStateには現在の状態が入っている
        {
            case BossState.Battle://戦闘中の処理を書く
                switch (SubState)//ランダムに選ばれた行動を実行する
                {
                    //case BossState.Jamp:
                    //    Jump();
                        #region 旧
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
                        //    _rb.velocity = new Vector2(_rb.velocity.x, Jamp); // AddForceなしでジャンプ！
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
                        #region 旧
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
    private void OnCollisionEnter2D(Collision2D collision)//弾がぶつかった時の処理
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
                Debug.Log("色が違うので無効");
            }
        }
    }
    #region 旧
    /*
    private void OnCollisionEnter2D(Collision2D collision)//弾がぶつかった時の処理
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
                        Debug.Log("色が違うので無効");
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
                    _sr.color = myColor; // 見た目を変える
                }

                Debug.Log($"ボスの色が変化：{myColor}");
                yield return new WaitForSeconds(2f); // 2秒待つ
            }
    }
    IEnumerator DoStartEnsyutu()//
    {
            Debug.Log("登場演出開始！");
            yield return new WaitForSeconds(1f); // 1秒まつ
            Debug.Log("登場演出終了");

            nowState = BossState.Battle;//状態をバトルにする
            StartCoroutine(ChangeBattleSubState());//バトルの行動を開始
    }

    IEnumerator DoClearEnsyutu()// クリア演出（エフェクトなど）
    {
        yield return new WaitForSeconds(0f); 
        Destroy(gameObject); // ボスを削除
        _clear.SetActive(true);
    }

    // --- バトル中の行動をランダムに切り替える ---
    IEnumerator ChangeBattleSubState()
    {
        while (currentHP > 0 && nowState == BossState.Battle)
        {
            SubState = (BossState.Idou);
            yield return new WaitForSeconds(Random.Range(1f, 2f));//1～2秒間待ってもらう
            SubState = BossState.Battle; // 一時停止状態
            yield return new WaitForSeconds(1f);
        }
    }

    // --- 各アクション処理 ---

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
    //    // 弾の発射処理
    //}

    //bool IsGrounded()
    //{
    //    return Physics2D.OverlapCircle(groundCheck.position, 0.1f) != null;//足元に半径0.1の円をだしてその円に何かぶつかっていたらtrueを返す    }
    //}
}

