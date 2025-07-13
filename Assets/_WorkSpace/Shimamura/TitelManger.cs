using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitelManger : MonoBehaviour
{
    private AudioSource _audiosource;

    private AudioClip _Buttan;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartGame()//タイトルシーンへ移動
    {
        // "GameScene" は遷移先のシーン名
        SceneManager.LoadScene("StageScene");
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ビルド後にアプリケーションを終了
        Application.Quit();
#endif
    }
}
