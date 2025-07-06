using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class damage : MonoBehaviour
{
    private string enemyTag = "Enemy";
    private string bossTag = "Boss";
    [SerializeField]
    GameObject _gameover;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            Destroy(gameObject);
            _gameover.SetActive(true);
          
        }
        if (collision.collider.tag == bossTag)
        {
            Destroy(gameObject);
            _gameover.SetActive(true);
            
        }
    }
}
