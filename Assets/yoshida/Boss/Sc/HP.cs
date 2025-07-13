using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Slider _HPSlider;
    [SerializeField]
    private SpriteRenderer _bossrenderer;

    // Start is called before the first frame update
    void Start()
    {
        _HPSlider.value = 10;//スライダーの値を10にする
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (collision.collider.TryGetComponent<Renderer>(out Renderer bulletRenderer))
            {
                Color bulletColor = bulletRenderer.material.color;

                if (_bossrenderer != null)
                {
                    Color bossColor = _bossrenderer.color;

                    if (bulletColor == bossColor)
                    {
                        _HPSlider.value -= 1;
                    }
                }
            
            }
   
        }
    }
}

