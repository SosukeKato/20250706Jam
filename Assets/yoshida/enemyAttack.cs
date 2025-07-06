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

    // �G�̌����@false = �E�����@true = ������
    public bool isFacingLeft { get; set; } = false;

    // �ŏ��̓����ʒu�i�E�����̎��̈ʒu�j���L�^����
    private Vector3 defaultThrowPointLocalPos;

    private enemymove moveScript;

    void Start()
    {
        moveScript = GetComponent<enemymove>();
        defaultThrowPointLocalPos = throwPoint.localPosition;
        InvokeRepeating(nameof(ThrowHammer), 1f, throwInterval);
    }

    void Update()
    {
        if (moveScript != null)
        {
            isFacingLeft = moveScript.IsFacingLeft;
        }

        UpdateThrowPointPosition();
    }

    /// <summary>
    /// �G�̌����ɍ��킹�āA�n���}�[�̏o���ʒu�����E���]������
    /// </summary>
    void UpdateThrowPointPosition()
    {
        // �E�����Ȃ炻�̂܂܁A�������Ȃ�x���W�𔽓]
        float x = defaultThrowPointLocalPos.x * (isFacingLeft ? -1f : 1f);

        // ���]��̈ʒu��ݒ�iY��Z�͕ς��Ȃ��j
        throwPoint.localPosition = new Vector3(x, defaultThrowPointLocalPos.y, defaultThrowPointLocalPos.z);
    }

    /// <summary>
    /// �n���}�[�𐶐����āA�����ɍ��킹�Ĕ�΂�
    /// </summary>
    void ThrowHammer()
    {
        // �n���}�[���o��������
        GameObject hammer = Instantiate(hammerPrefab, throwPoint.position, Quaternion.identity);

        // �n���}�[�ɕ����iRigidbody�j�����Ă���Α��x��^����
        Rigidbody hammerRb = hammer.GetComponent<Rigidbody>();

        if (hammerRb != null)
        {
            // �E�����Ȃ琳�A�������Ȃ畉��X�����ɔ�΂�
            float direction = isFacingLeft ? -1f : 1f;

            // �����鑬�x��ݒ�
            Vector3 throwVelocity = new Vector3(throwForceX * direction, throwForceY, 0f);
            hammerRb.velocity = throwVelocity;

            // �n���}�[�̌����ڂ����E���]������i�K�v�Ȃ�j
            Vector3 hammerScale = hammer.transform.localScale;
            hammerScale.x = Mathf.Abs(hammerScale.x) * direction;
            hammer.transform.localScale = hammerScale;
        }
    }
}
