using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(CapsuleCollider2D))]
public class BossHp : MonoBehaviour
{
    [SerializeField]
    int _BossHealth;
    [SerializeField]
    int _BossMaxHealth;
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

        }
    }
}
