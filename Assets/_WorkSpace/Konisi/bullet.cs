using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class bullet : MonoBehaviour
{
    [SerializeField] int BulletSpeed;
    [SerializeField] int BulletPower;

    private enemydamage _enemydamage;
    // Start is called before the first frame update
    void Start()
    {
        _enemydamage = FindAnyObjectByType<enemydamage>();
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(-BulletSpeed * Time.deltaTime,0,0);
    }
}
