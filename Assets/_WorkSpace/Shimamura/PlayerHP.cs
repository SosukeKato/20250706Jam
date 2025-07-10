using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int Hp;

    [SerializeField]
    private int _fallDeath;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FallDeath();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Damage(1);
        }
    }

    public void Damage(int damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FallDeath()
    {
        if (transform.position.y < _fallDeath)
        {
            Destroy(gameObject);
        }
    }
}
