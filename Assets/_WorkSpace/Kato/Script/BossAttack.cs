using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    int r;
    [SerializeField]
    List<GameObject> _BossAttack;
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
        r = Random.Range(0, _BossAttack.Count);
    }

    IEnumerator BossAttackInterval()
    {
        while (true)
        {
            yield return new WaitForSeconds(_BossAttackInterval);
            Debug.Log("çUåÇÇµÇΩÇ®");
            Instantiate(_BossAttack[r]);
        }
    }
}
