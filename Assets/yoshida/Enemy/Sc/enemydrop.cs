using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemydrop : MonoBehaviour
{
    [Header("�h���b�v����A�C�e���i1�j")]
    public GameObject dropItem;
    [Header("�A�C�e���̏o���ʒu�I�t�Z�b�g")]
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
