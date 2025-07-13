using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("������n���}�[��Prefab")]
    public GameObject _hammerPrefab;

    [Header("�n���}�[���o�Ă���ʒu�i�q�I�u�W�F�N�g�j")]
    public Transform _throwPoint;

    [Header("�n���}�[�̔�ԑ����iX�����j")]
    public float _throwForceX = 5f;

    [Header("�n���}�[�̔�ԑ����iY�����j")]
    public float _throwForceY = 7f;

    [Header("�n���}�[�𓊂���Ԋu�i�b�j")]
    public float throwInterval = 2f;

    private enemymove moveScript;
    private bool isFacingLeft = false;
    public int _power = 1;

    void Start()
    {
        moveScript = GetComponent<enemymove>();
        InvokeRepeating(nameof(ThrowHammer), 1f, throwInterval);
    }

    void Update()
    {
        if (moveScript != null)
        {
            isFacingLeft = moveScript.IsFacingLeft;
        }
    }

    void ThrowHammer()
    {
        if (_hammerPrefab == null || _throwPoint == null) return;

        GameObject hammer = Instantiate(_hammerPrefab, _throwPoint.position, Quaternion.identity);
        Rigidbody2D hammerRb = hammer.GetComponent<Rigidbody2D>();
        if (hammerRb != null)
        {
            float xDirection = isFacingLeft ? -1f : 1f;
            hammerRb.velocity = new Vector2(_throwForceX * xDirection, _throwForceY);
        }
    }
}
