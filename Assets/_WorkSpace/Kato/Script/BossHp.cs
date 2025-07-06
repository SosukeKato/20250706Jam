using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(CapsuleCollider2D))]
public class BossHp : MonoBehaviour
{
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
        
    }

    public void ModifyHealth(int amount)
    {
        _BossHealth -= amount;
        if (_BossHealth <= 0)
        {
            RemovedComponent BossAttack;
            StartCoroutine("BossDestroyInterval");
            gameObject.SetActive(false);
        }
    }

    IEnumerator BossDestroyInterval()
    {
        yield return new WaitForSeconds(_BossDestroyInterval);
        Destroy(gameObject);
    }
}
