using UnityEngine;

public class enemydamage : MonoBehaviour
{
    [Header("この敵の最大HP")]
    int _maxHP = 3;
    [Header("ドロップアイテム")]
    GameObject dropItem;
    private void OnTriggerEnter2D(Collider2D other)
    {
        TakeDamage(1); // ダメージ量は仮に1
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



