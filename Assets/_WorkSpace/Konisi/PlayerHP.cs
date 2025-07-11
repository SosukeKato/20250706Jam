using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] GameObject PlayerHPUI;

    private List<GameObject> _players = new();

    private player _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindAnyObjectByType<player>();
        GameObject PlayerHPUIClone = null;
        for (int i = 0; i < _player.PlayerHP; i++)
        {
            PlayerHPUIClone = Instantiate(PlayerHPUI);
            _players.Add(PlayerHPUIClone);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHPUI(int Damage)
    {
        for (int i = _players.Count + 1; i > Damage; i--)
        {
            _players[i].SetActive(false);
        }
    }
}
