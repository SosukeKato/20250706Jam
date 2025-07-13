using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    int RandomAttack;
    int RandomPlace;
    [SerializeField]
    List<GameObject> _BossAttack;
    [SerializeField]
    List<Transform> _BossAttackPlace;
    [SerializeField]
    int _BossAttackInterval;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("BossAttackInterval");
    }

    // Update is called once per frame
    void Update()
    {
        RandomAttack = Random.Range(0, _BossAttack.Count);
        RandomPlace = Random.Range(0, _BossAttackPlace.Count);
    }

    IEnumerator BossAttackInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(_BossAttackInterval);
            Debug.Log("çUåÇÇµÇΩÇ®");
            Instantiate(_BossAttack[RandomAttack], _BossAttackPlace[RandomPlace].position,Quaternion.identity);
        }
    }
}
