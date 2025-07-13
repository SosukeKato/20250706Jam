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
            return; // �v���C���[�����݂��Ȃ��Ȃ牽�����Ȃ�
        }
        //�v���C���[��X���W��X�ɑ��
        float x = _player.transform.position.x;

        float y = _player.transform.position.y;

        //���̒l���J�����̏����ʒu���疳���̊Ԃɐ���
       // x = Mathf.Clamp(x, _Pos.x, Mathf.Infinity);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
