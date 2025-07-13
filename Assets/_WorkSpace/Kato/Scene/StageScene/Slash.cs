using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    [SerializeField] int SlashDamage;

    private enemydamage _enemydamage;
    // Start is called before the first frame update
    void Start()
    {
        _enemydamage = FindAnyObjectByType<enemydamage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _enemydamage.TakeDamage(SlashDamage);
            Destroy(gameObject);
        }
    }
}
