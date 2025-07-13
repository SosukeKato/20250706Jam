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
<<<<<<< HEAD:Assets/_WorkSpace/Kato/Scene/Script/Portal.cs
        //else
        //{
        //    _GetGemKey = false;
        //}

=======
>>>>>>> cbe622cd644f3b4cb132664be8058795d2e80d3e:Assets/_WorkSpace/Kato/Script/Portal.cs
        if (collision.gameObject.CompareTag("BossGemKey"))
        {
            _GetBossGemKey = true;
        }
<<<<<<< HEAD:Assets/_WorkSpace/Kato/Scene/Script/Portal.cs
        //else
        //{
        //    _GetBossGemKey = false;
        //}

=======
>>>>>>> cbe622cd644f3b4cb132664be8058795d2e80d3e:Assets/_WorkSpace/Kato/Script/Portal.cs
        if ((collision.gameObject.CompareTag("Portal")) && _GetGemKey == true)
        {
            SceneManager.LoadScene("BossScene");
        }
<<<<<<< HEAD:Assets/_WorkSpace/Kato/Scene/Script/Portal.cs
        if ((collision.gameObject.CompareTag("EndPortal")/* && _GetBossGemKey == true*/))
=======
        if (collision.gameObject.CompareTag("EndPortal") && _GetBossGemKey == true)
>>>>>>> cbe622cd644f3b4cb132664be8058795d2e80d3e:Assets/_WorkSpace/Kato/Script/Portal.cs
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}
