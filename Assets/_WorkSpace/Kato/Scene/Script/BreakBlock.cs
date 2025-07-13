using System.Collections;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("BreakWaitTime");
        }
    }

    IEnumerator BreakWaitTime()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
