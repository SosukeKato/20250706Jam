using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] Image PlayerHPUI;

    private player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindAnyObjectByType<player>();
        for (int i = 0; i < _player.PlayerHP; i++)
        {
            Instantiate(PlayerHPUI);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
