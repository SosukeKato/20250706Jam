using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }

    public void ModifyHealth(int amount)
    {
        _BossHealth -= amount;
    }
}
