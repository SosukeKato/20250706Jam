using UnityEditor;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("������n���}�[��Prefab")]
    [SerializeField] private GameObject hammerPrefab;
    [Header("�n���}�[���o�Ă���ʒu�i�q�I�u�W�F�N�g�j")]
    [SerializeField] private Transform throwPoint;
    [Header("�n���}�[�̔�ԑ����iX�����j")]
    [SerializeField] private float throwForceX = 5f;
    [Header("�n���}�[�̔�ԑ����iY�����j")]
    [SerializeField] private float throwForceY = 7f;
    [Header("�n���}�[�𓊂���Ԋu�i�b�j")]
    [SerializeField] private float throwInterval = 2f;
    private enemymove moveScript;
    private bool isFacingLeft = false;

    void Start()
    {
        moveScript = GetComponent<enemymove>();
        InvokeRepeating("ThrowHammer", 1f, throwInterval);
    }

    void Update()
    {
        if (moveScript != null)
        {
            isFacingLeft = moveScript.IsFacingLeft; // �������ōŐV�̌������擾���Ă��邩�H
        }
    }
    
    void ThrowHammer()
    {
        GameObject hammer = Instantiate(hammerPrefab, throwPoint.position, Quaternion.identity);
        Rigidbody hammerRb = hammer.GetComponent<Rigidbody>();
        if (hammerRb != null)
        {
            float xDirection = 1f;

            if (isFacingLeft == true)
            {
                xDirection = -1f;
            }

            Vector3 speed = new Vector3(throwForceX * xDirection, throwForceY, 0f);
            hammerRb.velocity = speed;

            Vector3 scale = hammer.transform.localScale;

            if (xDirection < 0)
            {
                // �������p�ɔ��]�i��Βl������ă}�C�i�X��������j
                if (scale.x > 0)
                {
                    scale.x = -scale.x;
                }
            }
            else
            {
                // �E�����͐��̃X�P�[���ɂ���
                if (scale.x < 0)
                {
                    scale.x = -scale.x;
                }
            }
            hammer.transform.localScale = scale;
        }
    }
}
