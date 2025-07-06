using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(CapsuleCollider2D))]
public class BossHp : MonoBehaviour
{
    bool _BossExistence;
    [SerializeField]
    int _BossHealth;
    [SerializeField]
    int _BossMaxHealth;
    [SerializeField]
    float _BossDestroyInterval;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_BossHealth >= _BossMaxHealth)
        {
            _BossHealth = _BossMaxHealth;
        }
        if (_BossHealth <= 0)
        {
            StartCoroutine("BossDestroyInterval");
        }
    }

    IEnumerator BossDestroyInterval()
    {
        yield return new WaitForSeconds(_BossDestroyInterval);
    }
}
