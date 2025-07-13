using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] GameObject PlayerHPUI;

    private player _player;
    private int _beforehp;
    // Start is called before the first frame update
    void Start()
    {
        _player = FindAnyObjectByType<player>();
        for (int i = 0; i < _player.PlayerHP; i++)
        {
            GameObject PlayerHPUIClone = Instantiate(PlayerHPUI);
            PlayerHPUIClone.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHPUI(int Damage)
    {
        Image[] icon = transform.GetComponentsInChildren<Image>();
        for (int i = 0; i < icon.Length; i++)
        {
            icon[i].gameObject.SetActive(i < _player.GetPlayerHP());
        }
        _beforehp = _player.GetPlayerHP();
    }
}
