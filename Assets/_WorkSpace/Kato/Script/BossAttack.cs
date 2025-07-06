using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    List<GameObject> _BossAttack;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("aaaa");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator aaaa()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("aaaa");
        }
    }
}
