using UnityEngine;

public class enemydamage : MonoBehaviour
{
    [Header("���̓G�̍ő�HP")]
    int _maxHP = 3;
    [Header("�h���b�v�A�C�e��")]
    GameObject dropItem;
    private void OnTriggerEnter2D(Collider2D other)
    {
        TakeDamage(1); // �_���[�W�ʂ͉���1
    }
    public void TakeDamage(int damage)
    {
        _maxHP -= damage;
        if (_maxHP <= 0)
        {
            DropItem();
            Destroy(gameObject);
        }
    }
    void DropItem()
    {
        if (dropItem != null)
        {
            Vector3 spawnPos = transform.position;
            Instantiate(dropItem, spawnPos, Quaternion.identity);
        }
    }
}



