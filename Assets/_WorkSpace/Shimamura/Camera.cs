using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Vector3 _Pos;

    private player _player;


    // Start is called before the first frame update
    void Start()
    {
        _player = FindAnyObjectByType<player>();
        _Pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _FollowPlayer();
    }

    private void _FollowPlayer()

    {
        if (_player == null)
        {
            return; // プレイヤーが存在しないなら何もしない
        }
        //プレイヤーのX座標をXに代入
        float x = _player.transform.position.x;

        float y = _player.transform.position.y;

        //ｘの値をカメラの初期位置から無限の間に制限
       // x = Mathf.Clamp(x, _Pos.x, Mathf.Infinity);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
