using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydrop : MonoBehaviour
{
    [Header("ドロップするアイテム（1つ）")]
    public GameObject dropItem;
    [Header("アイテムの出現位置オフセット")]
    public Vector3 dropOffset = Vector3.up;
    private void Start()
    {
        Die();
    }
    void Die()
    {
        DropItem();
        Destroy(gameObject);
    }
    void DropItem()
    {
        if (dropItem != null)
        {
            Vector3 spawnPos = transform.position + dropOffset;
            Instantiate(dropItem, spawnPos, Quaternion.identity);
        }
    }
}
