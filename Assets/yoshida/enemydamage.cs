using UnityEditor.SceneManagement;
using UnityEngine;

public class enemydamage : MonoBehaviour
{
    [SerializeField, Tooltip("���̓G�̍ő�HP")]
    private int _maxHP = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        TakeDamage(1); // �_���[�W�ʂ͉���1
    }
    private void TakeDamage(int damage)
    {
        _maxHP -= damage;

        if (_maxHP <= 0)
        {
            Destroy(gameObject);
        }

    }
}


