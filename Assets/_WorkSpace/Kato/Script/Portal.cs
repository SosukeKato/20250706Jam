using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    bool _GetGemKey;
    bool _GetBossGemKey;
    [SerializeField]
    string _StageName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GemKey"))
        {
            _GetGemKey = true;
        }
        else
        {
            _GetGemKey = false;
        }

        if (collision.gameObject.CompareTag("BossGemKey"))
        {
            _GetBossGemKey = true;
        }
        else
        {
            _GetBossGemKey = false;
        }

        if ((collision.gameObject.CompareTag("Portal")) && _GetGemKey == true)
        {
            SceneManager.LoadScene("BossScene");
        }
        if ((collision.gameObject.CompareTag("EndPortal") && _GetBossGemKey == true))
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}
